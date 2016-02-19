using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace AnyRPG
{
   public class combatScreen : GameScreen
    {
       

       MenuComponent mainCombat;

        //background image for mini combat Screen
        Texture2D background;
        //rectangle that fills quarter of the gameScren
        Rectangle rectangleScreen;
        ContentManager Content;
        public static String Result = "";
        SpriteFont font;
        SpriteFont font2;
        Combat combat;
        StatBar playerBar, enemyBar;
        public double time = 0.00;
        public double elapsedTime;
        public double waitTime = 5000f;
        bool flee;
        public static bool defend = false;
        public static bool playerdead = false;
        public static bool result;
        public static int money = 100;
        public static int XP = 0;

        public Vector2 ResultPostion = new Vector2(100, 300);
        
        public combatScreen(SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image, Game game, ContentManager dacontent)
            : base(game, spriteBatch)
        {
            this.background = image;
            this.Content = dacontent;
            font = spriteFont;
            font2 = Content.Load<SpriteFont>(@"Fonts\combatfont");
            //  LoadContent(Content);
            //constructor creates menu with start and exit options
            string[] menuOptions1 = { "Attack", "Defend", "Flee" };




            //the menu is added to the list of components
            mainCombat = new MenuComponent(game,
                spriteBatch,
                spriteFont,
                menuOptions1, new Vector2(300, 50));



            Components.Add(mainCombat);
            
            
            // a rectangle is created which fill the game screen
            rectangleScreen = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }


       public void InitiateCombat(Combat newcombat){
           this.combat = newcombat;
           combat.LoadContent(Content);
           playerBar = new StatBar(Content);
           enemyBar = new StatBar(Content);
            

       }

        public override void Update(GameTime gameTime)

        {
            combat.CheckWinner();
            if (result && !playerdead)
            {
                mainCombat.Hide();
                Win(gameTime);
            }
            else if (!result && playerdead)
            {
                mainCombat.Hide();
                Lost(gameTime);
            }
            else{
           

                combat.Update(gameTime, spriteBatch);


                if (!combat.playersTurn)
                    mainCombat.Hide();



                if (flee)
                    Flee(gameTime);

                if (Game1.activeScreen == Game1.CombatScreen)
                {
                    if (!combat.playersTurn)
                        CallNextEnemyAttack(gameTime);
                    if (combat.playersTurn)
                    {
                        mainCombat.Show();

                        if (Game1.CheckKey(Keys.Enter))
                        {



                            if (mainCombat.SelectedIndex == 0) //Attack
                            {

                                combat.PlayerAttack();

                            }

                            if (mainCombat.SelectedIndex == 1) //Defend
                            {
                                combat.PlayerDefend();



                            }


                            //Flee
                            if (mainCombat.SelectedIndex == 2)
                            {
                                flee = true;
                            }





                        } // end if statement 2 

                    }

                } // end if statement 1

            }

            base.Update(gameTime);
            
        }

        public void CallNextEnemyAttack(GameTime theTime)
        {
            elapsedTime = theTime.ElapsedGameTime.Milliseconds;
            time = time + elapsedTime;
            if (time >= waitTime)
            {
                combat.EnemyAttack();
                time = 0.00;
            }
        }

       public int UpdateGold{
           get { return combat.CombatPlayer.gold; }
       }

        public void Win(GameTime theTime)
        {
            ResultPostion = new Vector2(300, 50);
            Result = Game1.WrapText(font2, "Congrats You Won! Gold Earned:" + combat.CombatEnemy.moneyGiven + "XP Earned: " + combat.CombatEnemy.xPGiven, 10f);
            elapsedTime = theTime.ElapsedGameTime.Milliseconds;
            time = time + elapsedTime;
            
            if (time >= 3000f)
            {
                Result = "";
                ResultPostion = new Vector2(100, 300);
                result = false;
                combat.CombatEnemy.Dead();
                combat.CombatPlayer.gold += combat.CombatEnemy.moneyGiven;
                combat.CombatPlayer.experiencePoints += combat.CombatEnemy.xPGiven;
                money = combat.CombatPlayer.gold;
                XP = combat.CombatPlayer.experiencePoints;
                Game1.activeScreen.Hide();
                Game1.activeScreen = Game1.actionScreen;
                Game1.activeScreen.Show();
                time = 0.00;
            }
        }

       
        public void Lost(GameTime theTime)
        {
            Result = "Oh dear, You're Dead! Respawning..";
            elapsedTime = theTime.ElapsedGameTime.Milliseconds;
            time = time + elapsedTime;
            if (time >= waitTime)
            {
                Result = "";
                result = false;
                Game1.activeScreen.Hide();
                Game1.activeScreen = Game1.actionScreen;
                Game1.activeScreen.Show();
                time = 0.00;
            }
        }

        public void Flee(GameTime theTime)
        {
           
                Result = "Running away... You will not recieve any XP points.";
                elapsedTime = theTime.ElapsedGameTime.Milliseconds;
                time = time + elapsedTime;
                if (time >= waitTime)
                {
                    Result = "";
                    Game1.activeScreen.Hide();
                    Game1.activeScreen = Game1.actionScreen;
                    Game1.activeScreen.Show();
                    flee = false;
                    time = 0.00;
                }
            

        }
     

        public override void Draw(GameTime gameTime)
        {
           
            spriteBatch.Begin();
            spriteBatch.Draw(background, rectangleScreen, Color.White);
            combat.Draw(spriteBatch);
            playerBar.Draw(spriteBatch, new Vector2(combat.characterPos.X, combat.characterPos.Y - 50), combat.playerCurrentHealth, combat.CombatPlayer.Abilities.Health);
            enemyBar.Draw(spriteBatch, new Vector2(combat.enemyPos.X, combat.enemyPos.Y - 50), combat.enemyCurrentHealth, combat.CombatEnemy.Health);
            spriteBatch.DrawString(font, combat.CombatPlayer.Name, new Vector2(30, 30), Color.Gold);
            spriteBatch.DrawString(font, combat.CombatEnemy.Name, new Vector2(500, 30), Color.Red);
            DrawEnemyStats();
            spriteBatch.DrawString(font2, Result, new Vector2(ResultPostion.X, ResultPostion.Y), Color.Red);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void DrawEnemyStats()
        {
          spriteBatch.DrawString(font2, "Level: " + combat.CombatEnemy.currentLvl, new Vector2(500, 100), Color.Red);
          spriteBatch.DrawString(font2, "Power: " + combat.CombatEnemy.power, new Vector2(500, 150), Color.Red);
          spriteBatch.DrawString(font2, "Defense: " + combat.CombatEnemy.defence, new Vector2(500, 200), Color.Red);
        }

        public void AnimateDamagePlayer(int damage)
        {
           
            if(combat.playerCurrentHealth - damage != combat.playerCurrentHealth)
                    combat.playerCurrentHealth -= 1;
                    
                

        }
       
      


    }
}




