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
    class StartScreen : GameScreen
    {
        MenuComponent menuComponent;
        //background image
        Texture2D RPGLogo;
        //used to make the image fill the game window
        Rectangle rectangleScreen;
        ContentManager Content;
        SpriteBatch spriteBatch;

        //gets the users menu choice
        public int SelectedIndex
        {
            //gets what the user chooses which is set to SelectedIndex
            get
            {
                return menuComponent.SelectedIndex;
            }
            set
            {
                menuComponent.SelectedIndex = value;
            }
        }


        public StartScreen(SpriteBatch cspriteBatch, SpriteFont spriteFont, Texture2D image,Game game)
           : base(game, cspriteBatch)
        {
            this.spriteBatch = cspriteBatch;
            RPGLogo = image;
            //  LoadContent(Content);
            //constructor creates menu with start and exit options
            string[] menuOptions = { "Start Game","Difficulty","Leave Game" };
            //the menu is added to the list of components
            menuComponent = new MenuComponent(game,
                spriteBatch,
                spriteFont,
                menuOptions, new Vector2(250,320));
            Components.Add(menuComponent);
           
            
            // a rectangle is created which fill the game screen
            rectangleScreen = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }
        


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(RPGLogo, rectangleScreen, Color.AntiqueWhite);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}