using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;


namespace AnyRPG
{
    public class StatBar
    {
        // initialize variables
        //container is the image frame that holds the health bar
        Texture2D container, healthBar;
        Vector2 position;
        Color barColor = Color.Green;
       // Vector2 positionB;
        //int fullDamage;
        //set to what ever damage increases by
        //int currentDamage;
       // int increaseDamage = 1;
        
        public StatBar(ContentManager content)
        {
            //sets ‘position’ to a certain vector on the screen
            //position of the health bar
            position = new Vector2(100, 100);
            //position of the damage bar
            //positionB = new Vector2(100, 200);
            //calls the LoadContent method 
            LoadContent(content);
            // fullHealth is when the character has full health and the health bar will be drawn the width of the healthBar image
          
           // currentDamage = fullDamage;
        }//end StatBar

        private void LoadContent(ContentManager content)
        {

            //load the container and health bar images
            container = content.Load<Texture2D>("container");
            healthBar = content.Load<Texture2D>("healthBar");
        }//end LoadContent

        public void Update(SpriteBatch spriteBatch, Rectangle playerBound, Vector2 playerPos,int cHealth, int MaxHealth )
        {

            if (cHealth <= 3)
                barColor = Color.Red;
            else
                barColor = Color.Green;
            

            spriteBatch.Begin();
            spriteBatch.Draw(container, new Vector2(playerPos.X-30,playerBound.Top - 20), Color.White);
            spriteBatch.Draw(healthBar, new Vector2(playerPos.X-30, playerBound.Top - 20), new Rectangle((int)playerPos.X, (int)playerBound.Top + 10, (int)(healthBar.Width * ((double)cHealth / MaxHealth)), healthBar.Height), Color.Green);
            //draws the container 
            
            // makes sure that the current health is not below zero, then subtracts the amount of health lost, from the current health
            spriteBatch.End();
            
          
            /*
            if (currentHealth >= 0)
            {
                currentHealth -= decreaseHealth;
            }//end if 
             */
             
            //checks is the damage is not below zero, then adds the amount of damage gained, to the current damage
          /*  if (currentDamage >= 0)
            {

                currentDamage += increaseDamage;
                //stops damage bar from going past the length of the container
                if (currentDamage >= healthBar.Width)
                {//if it is greater than or equal to the width,set the length of the damage bar to the width of the container
                    currentDamage = healthBar.Width;
                }//end if
            }//end if 
           */
        }//end Update




        public void Draw(SpriteBatch spriteBatch,Rectangle playerBound, Vector2 playerPos, int cHealth, int MaxHealth)
        {
            if (cHealth <= 3)
                barColor = Color.Red;
            else
                barColor = Color.Green;
            spriteBatch.Draw(container, new Vector2(playerPos.X-30, playerBound.Top - 20), Color.White);
            spriteBatch.Draw(healthBar, new Vector2(playerPos.X-30, playerBound.Top - 20), new Rectangle((int)playerPos.X, (int)playerBound.Top + 10, (int)(healthBar.Width * ((double)cHealth / MaxHealth)), healthBar.Height), barColor);





          
            //same structure as the one above, but controls the damage bar.
            //spriteBatch.Draw(healthBar, positionB, new Rectangle((int)position.X, (int)position.Y, currentDamage, healthBar.Height), Color.Red);
            //draws the container
           // spriteBatch.Draw(container, positionB, Color.White);

        }//end draw


        //overloads.. 


        public void Draw(SpriteBatch spriteBatch ,Vector2 position, int cHealth, int MaxHealth)
        {
            if (cHealth <= 3)
                barColor = Color.Red;
            else
                barColor = Color.Green;
           
                     
            spriteBatch.Draw(container, position, Color.White);
            spriteBatch.Draw(healthBar, position, new Rectangle((int)position.X, (int)position.Y, (int)(healthBar.Width * ((double)cHealth / MaxHealth)), healthBar.Height), barColor);
             
        }
        public void Update(SpriteBatch spriteBatch ,Vector2 position, int cHealth, int MaxHealth)
        {

            
            spriteBatch.Begin();
            spriteBatch.Draw(container, position, Color.White);
           spriteBatch.Draw(healthBar, position, new Rectangle((int)position.X, (int)position.Y, (int)(healthBar.Width * ((double)cHealth / MaxHealth)), healthBar.Height), barColor);
            spriteBatch.End();
        }





    }// end StatBar
}//end AnyRPG


