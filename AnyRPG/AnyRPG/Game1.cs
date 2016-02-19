using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using System.Text;


namespace AnyRPG
{
    /// <summary>
    /// Default Project Template
    /// </summary>
    public class Game1 : Game
    {

        



        
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
      
        public static SpriteFont font;
        
        
        
        static KeyboardState keyboardState;
        static KeyboardState oldKeyboardState;

        public static KeyboardState keyboardstate{
        get{return keyboardState;}
         }
        public static KeyboardState oldkeyboardstate
        {
            get { return oldKeyboardState; }
        }
        
        //active screen
        public static GameScreen activeScreen;
        //action screen
        public static ActionScreen actionScreen;
        //combat screen
        public static combatScreen CombatScreen;
        //start screen
        StartScreen startScreen;
        DifficultyScreen difficultyScreen;
        //player
        Player player;

       
        
       
        


        public Game1(Player newPlayer)
        {


            graphics = new GraphicsDeviceManager(this);

            this.player = newPlayer;

            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            graphics.IsFullScreen = false;
            oldKeyboardState = Keyboard.GetState();
        }


        /// <summary>
        /// Overridden from the base Game.Initialize. Once the GraphicsDevice is setup,
        /// we'll use the viewport to initialize some values.
        /// </summary>
        protected override void Initialize()
        {
           
            base.Initialize();
        }


        /// <summary>
        /// Load your graphics content.
        /// </summary>
        protected override void LoadContent()
        {


            spriteBatch = new SpriteBatch(GraphicsDevice);
                  
            Tiles.Content = Content;
            
            //create new instance of the startScreen
            startScreen = new StartScreen(
                spriteBatch,
                //loads the font to the screen
                font = Content.Load<SpriteFont>("Fonts/Dafunk2"),
                //loads the image to the screen
                Content.Load<Texture2D>("MAIN_MENU"), this);

            //adds the screen to components
            Components.Add(startScreen);
            //set active screen
            activeScreen = startScreen;
            activeScreen.Show();

            
            CombatScreen = new combatScreen(
                spriteBatch,
            font,
                Content.Load<Texture2D>("combatBackground"), this, Content);
            
            
            actionScreen = new ActionScreen(
                this,
                spriteBatch,
                Content.Load<SpriteFont>("Fonts/gamefont"), 
                Content, player);
            
             difficultyScreen = new DifficultyScreen(
                spriteBatch,
                 //loads the font to the screen
                font = Content.Load<SpriteFont>("Fonts/Dafunk2"),
                 //loads the image to the screen
                Content.Load<Texture2D>("MAIN_MENU"), this);

             Components.Add(difficultyScreen);
            Components.Add(CombatScreen);
            Components.Add(actionScreen);

            actionScreen.Hide();
            CombatScreen.Hide();
            difficultyScreen.Hide();


        }








        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>


        protected override void Update(GameTime gameTime)
        {
            //get the current state of the keyboard
            keyboardState = Keyboard.GetState();
            CheckStartScreenInput();
            CheckDifficultyScreenInput();



            base.Update(gameTime);
            oldKeyboardState = keyboardState;
        }


       



    

      


        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            spriteBatch.Begin();
            switch (activeScreen.ToString())
            {
                case "startScreen":
                    
                    startScreen.Draw(gameTime);
                    //StartScreen ();
                    break;
                case "charScreen":
                    
                    //charScreen.Draw(gameTime);
                    break;
                case "actionScreen":
                    //map.Draw(spriteBatch);
                    //statBar.Draw(spriteBatch);
                    break;
                case "classScreen":
                    
                    //classScreen.Draw(gameTime);
                    //statBar.Draw(spriteBatch);
                    break;
                case "genderScreen":
                   
                    //genderScreen.Draw(gameTime);

                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
            



}

        public static bool CheckKey(Keys theKey)
        {
            //returns if the key was pressed in the last frame
            return keyboardState.IsKeyUp(theKey) &&
            oldKeyboardState.IsKeyDown(theKey);
        }

        public void CheckStartScreenInput()
        {

            //checks if instances are the same
            if (activeScreen == startScreen)
            {
                //checks if enter key was pressed
                if (CheckKey(Keys.Enter))
                {
                    //if the selected index is on the first item (start game), the current active screen will hide adn it will be switched to the action screen
                    if (startScreen.SelectedIndex == 0)
                    {
                        activeScreen.Hide();
                        activeScreen = actionScreen;
                        activeScreen.Show();
                    }

                    //Difficulty
                    if (startScreen.SelectedIndex == 1)
                    {
                        activeScreen.Hide();
                        activeScreen = difficultyScreen;
                        activeScreen.Show();

                    }
                    //Exit
                    if (startScreen.SelectedIndex == 2)
                    {
                        this.Exit();
                    }
                }
            }


        }
        public static string WrapText(SpriteFont spriteFont, string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');

            StringBuilder sb = new StringBuilder();

            float lineWidth = 0f;

            float spaceWidth = spriteFont.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = spriteFont.MeasureString(word);

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }
        public void CheckDifficultyScreenInput()
        {
            //checks if instances are the same
            if (activeScreen == difficultyScreen)
            {
                //checks if enter key was pressed
                if (CheckKey(Keys.Enter))
                {
                    
                    if (difficultyScreen.SelectedIndex == 0)
                    {
                        Player.Difficulty = "Easy";
                    }

                    //Difficulty
                    if (difficultyScreen.SelectedIndex == 1)
                    {
                        Player.Difficulty = "Medium";

                    }
                   
                    if (difficultyScreen.SelectedIndex == 2)
                    {
                        Player.Difficulty = "Hard";
                        
                    }
                    if (difficultyScreen.SelectedIndex == 3)
                    {
                        activeScreen.Hide();
                        activeScreen = startScreen;
                        activeScreen.Show();

                    }
                    
                }
            }


        }



    }
}