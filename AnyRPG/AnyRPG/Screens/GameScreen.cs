using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;




namespace AnyRPG
{
    public abstract class GameScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<GameComponent> components = new List<GameComponent>();
        //hold the current game object
        protected Game game;
        //allows you to draw in the inherited classess
        protected SpriteBatch spriteBatch;


        public List<GameComponent> Components
        {
            get { return components; }


        }


        public GameScreen(Game game, SpriteBatch spriteBatch)
            //calls to the constructor of the base class
            : base(game)
        {
            //sets the game and spriteBatch fields to the parameters passed into the constructor
            this.game = game;
            this.spriteBatch = spriteBatch;
        }


        public override void Initialize()
        {
            base.Initialize();


        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            //loops through the game components in the components field
            foreach (GameComponent component in components)
                //checks if property of the enabled component is true
                if (component.Enabled == true)
                    //if true, call the update method, with gameTime 
                    component.Update(gameTime);


        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (GameComponent component in components)
                //checks if the component is a DrawableGameComponent
                if (component is DrawableGameComponent &&
                    ((DrawableGameComponent)component).Visible)
                    ((DrawableGameComponent)component).Draw(gameTime);
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