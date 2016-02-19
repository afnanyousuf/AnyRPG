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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Collections.Specialized;
namespace AnyRPG
{
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<GameComponent> components = new List<GameComponent>();
        string[] menuItems;
        int selectedIndex;
        public string[] MenuItems{
            set { value = this.menuItems; }
        }

        

        Color normal = Color.AntiqueWhite;
        Color hilite = Color.Gold;


     

        //drawing text to the menu
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;


        //used to position the menu on the screen
        Vector2 position;
        float width = 0f;
        float height = 0f;


        //menu items are stored in an array. tries to keep it in bounds of the screen
        public int SelectedIndex
        {
            //returns the value of selectedIndex field
            get { return selectedIndex; }
            set
            {
                //sets selectedIndex to the value passed to the property
                selectedIndex = value;
                //is selectedIndex is less than 0, set it to 0
                if (selectedIndex < 0)
                    selectedIndex = 0;
                //if selectedIndex is greater or equal to the array, set it to the length of the array minus 1
                if (selectedIndex >= menuItems.Length)
                    selectedIndex = menuItems.Length - 1;
            }
        }
        //constructor. requires a game b/c class DrawableGameComponents inherits from requires a game
        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont spriteFont,
            string[] menuItems, Vector2 pos)
            : base(game)
        {
            //sets the fields
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.menuItems = menuItems;
            //calls the MeasureMenu method
            MeasureMenu(pos);
        }
        //measure width and height of screen, also to center it
        private void MeasureMenu(Vector2 pos)
        {
            //sets height and width to 0 so that each time its called, the screen will be centered
            height = 0;
            width = 0;


            //goes through the items in the menu
            foreach (string item in menuItems)
            {
                //gets the size of the string, returns a Vector2 with X as th ewidth and Y the height
                Vector2 size = spriteFont.MeasureString(item);
                //if value of X is greater than the width, set it to the width
                if (size.X > width)
                    width = size.X;
                //calculate the height from the spriteFont class and adds 5 pixels to space it out
                height += spriteFont.LineSpacing + 5;
            }
            //centers the object
            position = pos;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
      
        public override void Update(GameTime gameTime)
        {
            
            //if the down key is pressed, increase the selectedIndex field by 1
            if (Game1.CheckKey(Keys.Down))
            {
                //if true, add 1 to selectedIndex field
                selectedIndex++;
                //checks that it is not the length of the menu items
                if (selectedIndex == menuItems.Length)
                    //if so, sets it to 0 (top of list)
                    selectedIndex = 0;
            }
            //if the up key was pressed, the selectedIndex decreases by 1, moving it up
            if (Game1.CheckKey(Keys.Up))
            {
                //moves selectedIndex up by 1
                selectedIndex--;
                //if it is less than zero(off the screen) it will be set to the bottom item
                if (selectedIndex < 0)
                    selectedIndex = menuItems.Length - 1;
            }
            base.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Vector2 location = position;
            //determines what color to draw the text
            Color tint;
            //loops through all of the menu items
            for (int i = 0; i < menuItems.Length; i++)
            {
                //if i is = to the selectedIndex, then the tint will change to yellow
                if (i == selectedIndex)
                    tint = hilite;
                else
                    //otherwise, set the tint ot normal
                    tint = normal;

                spriteBatch.Begin();
                //calls the DrawString method of the spriteBatch to drawthe string
                spriteBatch.DrawString(
                    spriteFont,
                    menuItems[i],
                    location,
                    tint);
                //makes lines of the menu appear on different lines
                location.Y += spriteFont.LineSpacing + 5;
                spriteBatch.End();
            }
        }


        public virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;


            foreach (GameComponent component in components)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = true;
            }


        }


        public virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;


            foreach (GameComponent component in components)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                    ((DrawableGameComponent)component).Visible = false;
            }
        }
    
    
    
    
    
    }


}