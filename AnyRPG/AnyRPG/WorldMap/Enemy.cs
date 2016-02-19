
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AnyRPG
{

    public class Enemy
    {

       







        // Possible enemy states
        public enum EnemyState
        {
            Wander = 0,
            attackPlayer,
            Dead
        }

        // Current enemy state (default = Wander)
        EnemyState state;

        // declare variables for Enemy 
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 position;
        public Vector2 motion;
        public String Name;
        public int currentHealth,health, power, moneyGiven, xPGiven, currentLvl, damageDone, monstersKilled, defence;
        float enemySpeed;
        public bool isVisible;

        public double time = 0.00;
        public double elapsedTime;
        public double respawnTime = 10000f;

       
        // Constructor
        public Enemy(Texture2D newTexture, Vector2 newPosition, String newName)
        {
            // initialize variables 
            texture = newTexture;
            position = newPosition;
            Name = newName;
            currentLvl = 50; // diffuculty level 
            health = 2500; // will decrease or increase 
            currentHealth = health;
            enemySpeed = 3f;
            defence = 5;// will increase as monslvl goes up 
            power = 100; // will increase as monslvl goes up too
            isVisible = true; // is monster Visible on screen 
            monstersKilled = 0;
            moneyGiven = 10;
            xPGiven = 20;
            motion = new Vector2(1, 1);
            boundingBox = new Rectangle((int)newPosition.X,(int)newPosition.Y,newTexture.Width,newTexture.Height);
            
        }
        // end constructor 
        
        public int CurrentHealth{
            get{ return this.currentHealth;}
            set { value = this.currentHealth; }

        }




        public void Update(bool isAttacked, GameTime time)
        {
            // Update Collision Rectangle (the map in this case) 
           // boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (!this.isVisible)
            {
                Respawn(time);
            }

            if (isAttacked)
            {

                

                Console.WriteLine("Displaying CombatScreen..");
                Game1.activeScreen.Hide();
                Game1.activeScreen = Game1.CombatScreen;
                Game1.activeScreen.Show();


            }
            // Move enemy back to map of it gets killed in the process
            //base.Update(gameTime);

        } // end Update time 

        public void Wander()
        {
            
           



        } // end Wander method

        public void Respawn(GameTime theTime)
        {
            elapsedTime = theTime.ElapsedGameTime.Milliseconds;
            time = time + elapsedTime;
            if (time >= respawnTime)
            {
                this.isVisible = true;
                time = 0.00;
            }
        }
        
        
       


        public int Health
        {

            get
            {

                //player.getPower - enemy.getPower = health; 
                return this.health;
            }

            set
            {
                this.health = value;

            }

        } // end getter for health 

       

    



        
        public void attackPlayer()
        {
            

        } // end attack back method 


        public void Dead()
        {
            this.isVisible = false;
            //this.boundingBox = new Rectangle(0,0,0,0);
           // Console.Write("You killed the enemy!");
            
            this.monstersKilled++;

            if (monstersKilled % 3 == 0)
            {
                currentDiffucultyLevel();
            }


            
        } // end Dead method 


        
       

        public void currentDiffucultyLevel()
        {
            // call monslvl when case is switched to Dead 
            // Monslvl goes up by one each time 3 monsters are killed
            // when it goes up by one each of health,speed, and power goes up by 1 

            this.currentLvl++;
            this.health += 10;
            this.currentHealth = health;
            this.enemySpeed += 1;
            this.power += 2;
            this.defence += 2;
            this.moneyGiven += 20;
            //this.xPGiven += 10;

        } //end monslvl */ 

        public void Draw(SpriteBatch spriteBatch)
        {
           
            if(isVisible)
                spriteBatch.Draw(texture, position, Color.White);


        }

 

       

    } 
} 


