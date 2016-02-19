using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AnyRPG
{
    class gameObject
    {
        public Vector2 position;
        public Rectangle bounds;
        public Texture2D image;
        public bool passable;
        public String interactableText = "";




        public gameObject(Vector2 location, Texture2D objectImage, bool gothru, String text)
        {
            this.position = location;
            this.bounds = new Rectangle((int)position.X, (int)position.Y, objectImage.Width, objectImage.Height);
            this.image = objectImage;
            this.passable = gothru;
            this.interactableText = text;

         

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image, this.position, Color.White);
            //spriteBatch.DrawString(ActionScreen.gameFont, this.interactableText, new Vector2(ActionScreen.camera.center.X, ActionScreen.camera.center.Y), Color.Gold);


        }

        public void Update(bool interact)
        {
           

        }


    }
}


