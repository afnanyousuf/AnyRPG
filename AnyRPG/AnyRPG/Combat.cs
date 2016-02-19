using System;
//using RolePlayingGameData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using System.IO;
using System.Reflection;

namespace AnyRPG
{
    /// <summary>
    /// Encapsulates all of the combat-runtime data for a particular monster combatant.
    /// </summary>
    /// <remarks>
    /// There may be many of a particular Monster in combat.  This class adds the 
    /// statistics and AI data that are particular to this particular combatant.
    /// </remarks>
    public class Combat
    {
      

        Enemy enemy;
        Player player;
        Random rnd;

        public String Result = "Prepare To Battle!";
       SpriteFont font;
       Color turnColor = Color.White;
       public bool playersTurn;

       //StatBar playerBar, enemyBar;
       public Vector2 characterPos = new Vector2(150, 400);
       public Vector2 enemyPos = new Vector2(450, 400);

       public int playerCurrentHealth;
       public int enemyCurrentHealth;

       public static bool finalResult;
        public static int moneyGiven;
        public static int XPGiven;

       public Player CombatPlayer
       {
           get { return this.player; }
       }
       public Enemy CombatEnemy
       {
           get { return this.enemy; }
       }

        public void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>(@"Fonts\gamefont");
            

        } // end content method 


       
        public Combat(Enemy currentEnemy, Player currentPlayer)
        {
            this.enemy = currentEnemy;
            this.player = currentPlayer;
            playerCurrentHealth = player.HitPointsCurrent;
            enemyCurrentHealth = enemy.CurrentHealth;
            moneyGiven = enemy.moneyGiven;
            XPGiven = enemy.xPGiven;
            rnd = new Random();
            SetCombatTurn();
        }

        public void SetCombatTurn()
        {
            int roll = rnd.Next(1, 101);
            if (roll > 50)
            {
                playersTurn = true;
            }
            else
            {
                playersTurn = false;
            }
            if (!playersTurn)
                EnemyAttack();
        }

        public void drawCombantants(SpriteBatch spriteBatch)
        {
           
            
            
            if (playersTurn)
                turnColor = Color.Red;
            spriteBatch.Draw(playerTexture(), characterPos, turnColor);
            spriteBatch.Draw(enemy.texture, 
                enemyPos,
                null,
                Color.White, 
                0f, 
                new Vector2(0, 0), 
                2.0f, 
                SpriteEffects.None, 
                0f);

            
            
         
           
        }

        public Texture2D playerTexture()
        {
            String imageName = "";
            Stream stream;
            
            if(player.PlayerClass=="Warrior" && player.Gender == "Male")
                imageName = "MaleWarrior";
            if (player.PlayerClass == "Warrior" && player.Gender == "Female")
                imageName = "FemaleWarrior";
            if (player.PlayerClass == "Mage" && player.Gender == "Male")
                imageName = "MaleMage";
            if (player.PlayerClass == "Mage" && player.Gender == "Female")
                imageName = "FemaleMage";
            if (player.PlayerClass == "Ranger" && player.Gender == "Male")
                imageName = "MaleRanger";
            if (player.PlayerClass == "Ranger" && player.Gender == "Female")
                imageName = "FemaleRanger";


            stream = Assembly.GetCallingAssembly().GetManifestResourceStream("AnyRPG.Resources."+ imageName + ".png");
            return Texture2D.FromStream(Game1.graphics.GraphicsDevice, stream);  

        }



        public void Update(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
            

        } 

      

        public void AnimateDamagePlayer(int damage)
        {

            if (playerCurrentHealth - damage != playerCurrentHealth)
                playerCurrentHealth -= 1;



        }

        public void EnemyAttack()
        {
            //Enemy Damage = EnemyCurrentLevel + EnemyPower + rand(-EnemyLevel,EnemyLevel) - PlayerDefence
            Random rnd = new Random();
            int chanceToHitZero = rnd.Next(0, 101);
            int Damage;
            int playerDefence; 
            int powerChance = rnd.Next(-enemy.currentLvl, enemy.currentLvl + 1);
            if (combatScreen.defend)
                playerDefence = player.Abilities.Defense + 10;
            else
                playerDefence = player.Abilities.Defense;
            
            Damage = enemy.currentLvl + enemy.power + powerChance - playerDefence;
            
            Console.WriteLine("lvl:" + enemy.currentLvl);
            Console.WriteLine("Power:" + enemy.power);
            Console.WriteLine("Chance:" + powerChance);
            Console.WriteLine("Def:" + playerDefence);
            Console.WriteLine(Damage);
            if (chanceToHitZero > 90 || Damage < 0)
                    Damage = 0;

                combatScreen.Result = enemy.Name + " attacked and hit " + Damage;
                playerCurrentHealth -= Damage;
                combatScreen.defend = false;
                playersTurn = true;
            


        }
        public void PlayerAttack()
        {
            //Player Damage =	PlayerAttack + PlayerAbilityPower + random(-PlayerLevel,PlayerLevel) - EnemyDefence
            
            int playerAbilityPower = 1;
            int Damage;
            int classAbility = GetClassAbility();
            Random rnd = new Random();
            String newAbility = getRandomAbility();
            if (player.CombatAbilities[0] == newAbility)
                playerAbilityPower = 10;
            if (player.CombatAbilities[1] == newAbility)
                playerAbilityPower = 15;
            if (player.CombatAbilities[2] == newAbility)
                playerAbilityPower = 20;

           
            if (player.CombatAbilities[4] == newAbility)
            {
                combatScreen.Result = "Your attack missed!";
                playersTurn = false;
            }


            else if (newAbility == "HP Steal")
            { 
                playerAbilityPower = 10;
                Damage = classAbility + playerAbilityPower + rnd.Next(-player.PlayerLevel, player.PlayerLevel + 1) - enemy.defence;
                //incase formula fails..
                if (Damage < 0)
                {
                    Damage = 0;
                }
                combatScreen.Result = "You used HP Steal and stole " + Damage + " HP";
                if (Damage + playerCurrentHealth > player.Abilities.Health)
                {
                    playerCurrentHealth = player.Abilities.Health;
                    enemyCurrentHealth -= Damage;
                }
                else
                {
                    playerCurrentHealth += Damage;
                    enemyCurrentHealth -= Damage;
                }
                playersTurn = false;
                
            }

            else if (newAbility == "BloodThirst Arrow")
            {
                playerAbilityPower = 10;
                Damage = classAbility + playerAbilityPower + rnd.Next(-player.PlayerLevel, player.PlayerLevel + 1) - enemy.defence;
                //incase formula fails..
                if (Damage < 0)
                {
                    Damage = 0;
                }
                combatScreen.Result = "You used BloodThirst Arrow and stole " + Damage + " HP";
                if (Damage + playerCurrentHealth > player.Abilities.Health)
                {
                    playerCurrentHealth = player.Health;
                    enemyCurrentHealth -= Damage;
                }
                else
                {
                    playerCurrentHealth += Damage;
                    enemyCurrentHealth -= Damage;
                }
                playersTurn = false;
               
            }



            else if (newAbility == "Heal")
            {
                int healamount = rnd.Next(1, player.Abilities.Health);
                healamount = (int)MathHelper.Clamp(healamount, 1, player.Abilities.Health);
                combatScreen.Result = "You used Heal and gained " + healamount + " HP";
                if (healamount + playerCurrentHealth > player.Abilities.Health)
                    playerCurrentHealth = player.Abilities.Health;
                else
                    playerCurrentHealth += healamount;
                playersTurn = false;


            }
            else
            {
                Damage = classAbility + playerAbilityPower + rnd.Next(-player.PlayerLevel, player.PlayerLevel + 1) - enemy.defence;

                //incase formula fails..
                if (Damage < 0)
                {
                    Damage = 0;
                }



                combatScreen.Result = "You used " + newAbility + " and hit " + Damage;
                enemyCurrentHealth -= Damage;
                playersTurn = false;

            }

           
            

            
            
        }

        public int GetClassAbility()
        {
            switch (player.PlayerClass)
            {
                case "Ranger":
                    return player.Abilities.Ranging;
                case "Warrior":
                    return player.Abilities.Strength;
                case "Mage":
                    return player.Abilities.Magic;

            }
            return player.Abilities.Attack;

        }

        public void CheckWinner()
        {
            if (playerCurrentHealth <= 0)
            {
                combatScreen.playerdead = true;
                combatScreen.result = false;
                finalResult = true;

            }
            if (enemyCurrentHealth <= 0)
            {
                combatScreen.result = true;
                finalResult = false;
            }



            

        }


        public String getRandomAbility()
        {
            Random rnd = new Random();
            int abilityPower = rnd.Next(0, 1001);

            if (abilityPower <= 400)
                abilityPower = 0;
            if (abilityPower > 400 && abilityPower <= 600)
                abilityPower = 1;
            if (abilityPower > 600 && abilityPower <= 700)
                abilityPower = 2;
            if (abilityPower > 700 && abilityPower <= 900)
                abilityPower = 3;
            if (abilityPower > 900)
                abilityPower = 4;

            return player.CombatAbilities[abilityPower];


        }

        public void PlayerDefend()
        {
            combatScreen.defend = true;
            combatScreen.Result = "You used defend on enemys next attack..";
            playersTurn = false;

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            drawCombantants(spriteBatch);

        }
       


    } // end Combat class 

} // end namepsace 

