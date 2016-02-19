
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace AnyRPG
{
    public class CharMovement
    {
        //The asset name for the Sprite's Texture
        List<Texture2D> CharSprites = new List<Texture2D>();
        public Rectangle Size;
        private float mScale = 1.0f;
        public Vector2 Position = new Vector2(50, 500); //start position
        public Vector2 lastPosition;
        public Texture2D charTexture;
        public Color playerColor = Color.White;
        
        

        //Load the texture for the sprite using the Content Pipeline
        public void LoadContent(ContentManager theContentManager, Player player)
        {
            //loads the image of the sprite

            String folder = player.PlayerClass;
            String gender = player.Gender;
            

            CharSprites.Add(theContentManager.Load<Texture2D>("characterSprites/" + folder + "/" + gender + "/" + "WalkingFront"));
            CharSprites.Add(theContentManager.Load<Texture2D>("characterSprites/" + folder + "/" + gender + "/" + "WalkingBack"));
            CharSprites.Add(theContentManager.Load<Texture2D>("characterSprites/" + folder + "/" + gender + "/" + "WalkingLeft"));
            CharSprites.Add(theContentManager.Load<Texture2D>("characterSprites/" + folder + "/" + gender + "/" + "WalkingRight"));


            charTexture = CharSprites[0];

            //creates a new rectangle the size of the sprite
            Size = new Rectangle(0, 0, (int)(charTexture.Width * mScale), (int)(charTexture.Height * mScale));
        }

        //Update the Sprite and change it's position based on the set speed, direction and elapsed time.
        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection, String face, Player player)
        {
          
            //calculates the position of the sprite using the speed and direction from the MageChar class
            lastPosition = Position;
            Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
            //return bounding box of player
            Size = new Rectangle((int)Position.X, (int)Position.Y, (int)(charTexture.Width), (int)(charTexture.Height));




            switch (face)
            {

                case "WalkingFront":
                    charTexture = CharSprites[0];
                    break;
                case "WalkingBack":
                    charTexture = CharSprites[1];
                    break;

                case "WalkingLeft":
                    charTexture = CharSprites[2];
                    break;

                case "WalkingRight":
                    charTexture = CharSprites[3];
                    break;

            }


            /*
            switch (player.PlayerClass)
            {
                case "Warrior":
                    playerColor = UserInfo.Warrior.color;
                    break;
                case "Mage":
                    playerColor = UserInfo.Mage.color;
                    break;
                case "Ranger":
                    playerColor = UserInfo.Ranger.color;
                    break;
            }
             */
           
         


        }

        //Draw the sprite to the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            //draw the sprite to the screen inside a rectangle     
            theSpriteBatch.Draw(charTexture, Position,
                new Rectangle(0, 0, charTexture.Width, charTexture.Height),
                playerColor, 0.0f, Vector2.Zero, mScale, SpriteEffects.None, 0);
        }





    }

}
