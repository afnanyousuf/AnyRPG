using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AnyRPG
{
    class Button
    {

        Texture2D normalTexture;
        //Texture2D hoverTexture;
        String buttonText;
        Vector2 textPos;
        Color textColor;

        //bool click, hover;
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                value = textColor;
            }

        }


        //get id
        public int buttonId;
        public Rectangle bounds;


        //get bounds of button
        public Rectangle Bounds
        {

            get
            {
                return bounds;

            }


        }

        public Button(int newbuttonId, Rectangle newbounds, String newbuttonText, Color newtextColor)
        {
            this.buttonId = newbuttonId;
            this.bounds = newbounds;
            this.buttonText = newbuttonText;
            this.textColor = newtextColor;
        }

        public void Load(ContentManager Content)
        {
            normalTexture = Content.Load<Texture2D>("button");
            //hoverTexture = Content.Load<Texture2D>("hoverbutton");
        }


        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            textPos = new Vector2(bounds.X, bounds.Y);
            textPos += new Vector2((bounds.Width / 2) -
                (spriteFont.MeasureString(buttonText).X / 2), (bounds.Height / 2) -
                (spriteFont.MeasureString(buttonText).Y / 2));

            spriteBatch.Draw(normalTexture, bounds, Color.White);
            spriteBatch.DrawString(spriteFont, buttonText, textPos, this.textColor);
        }

        public void Update(GameTime time)
        {


            //handle change from normaltexture to hovertexture


        }



    }
}
