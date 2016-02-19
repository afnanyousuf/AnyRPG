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
    public class MageChar : CharMovement
    {
        ContentManager theContentManager;
        SpriteBatch spriteBatch;
        //variable where sprite file name is stored
        public String MageAssetName = "WalkingFront";
        //starting x position
        const int StartPositionX = 0;
        //starting y position
        const int StartPositionY = 0;
        //speed that the sprite will move on screen
        const int MageSpeed = 160;
        //move sprite 1 up/down when the arrow key is pressed
        const int MoveUp = -1;
        const int MoveDown = 1;
        const int MoveLeft = -1;
        const int MoveRight = 1;
        
        //used to store the current state of the sprite
        enum State
        {
            WalkingLeft,
            WalkingRight,
            WalkingFront,
            WalkingBack
        }
        //set to current state of the sprite. initally set to walking
        State CurrentState = State.WalkingFront;

        //stores direction of sprite
        Vector2 Direction = Vector2.Zero;

        //stores speed of sprite
        Vector2 Speed = Vector2.Zero;

        //stores previous state of keyboard
        KeyboardState PreviousKeyboardState;

        public void Loadcontent(ContentManager theContentManager)
        {
            //sets position to the top left corner of the screen
            Position = new Vector2(StartPositionX, StartPositionY);

            //calls the load content method of the CharMovement class, passing in the content manager, and the name of the sprite image
           // base.LoadContent(theContentManager);
        }

        //checks state of the keyboard
        private void Update(KeyboardState aCurrentKeyboardState)
        {

            //run if the sprite is walking
            if (CurrentState != null)
            {
                
                //sets direction and speed to zero
                Speed = Vector2.Zero;
                Direction = Vector2.Zero;

                //if left key is pressed, move left
                if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                {
                    CurrentState = State.WalkingLeft;
                    MageAssetName = "WalkingLeft";
                    //speed of sprite movement
                    Speed.X -= MageSpeed;
                    //moves the sprite left
                    Direction.X -= MoveLeft;
                }
                //if right key is pressed, move right
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                {
                    CurrentState = State.WalkingRight;
                    MageAssetName = "WalkingRight";
                    //speed of sprite movement
                    Speed.X += MageSpeed;
                    //moves the sprite right
                    Direction.X += MoveRight;
                }
                //if up key is pressed, move up
                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    CurrentState = State.WalkingBack;
                    MageAssetName = "WalkingBack";
                    //speed of sprite movement
                    Speed.Y += MageSpeed;
                    //moves sprite up
                    Direction.Y += MoveUp;
                }
                //if down key is pressed, move down
                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    CurrentState = State.WalkingFront;
                    MageAssetName = "WalkingFront";
                    //speed of sprite movement
                    Speed.Y -= MageSpeed;
                    //moves sprite down
                    Direction.Y -= MoveDown;
                }

            }
        }

       


        public void Update(GameTime theGameTime, Player player)
        {
            //obtains current state of the keyboard
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();

            //calls in UpdateMovement and passes in current keyboard state
            Update(aCurrentKeyboardState);

            //set previous state to current state
            PreviousKeyboardState = aCurrentKeyboardState;

            //call update method of the charMovement class, passing in the gametime, speed and direction of the sprite
            base.Update(theGameTime, Speed, Direction, MageAssetName, player);
        }


    }
}





