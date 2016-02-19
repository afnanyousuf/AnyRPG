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
    class NPC
    {
        //declatations 
        Texture2D npcImage;
        String Name;
        Rectangle bounds;
        Vector2 NPClocation;
        
        public String[,] dialogue;


        //constructor
        public NPC(Vector2 location, Texture2D npcTexture, String name, String[,] dialog)
        {
            this.NPClocation = location;
            this.bounds = new Rectangle((int)NPClocation.X, (int)NPClocation.Y, npcTexture.Width, npcTexture.Height);
            this.npcImage = npcTexture;
            this.Name = name;
            this.dialogue = dialog;


        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.npcImage, this.NPClocation, Color.White);
        }

        public void SpeakDialog(int PlayerLevel){
            if ( PlayerLevel == 1)
            {

                ActionScreen.dialogueText = this.dialogue[0, 0];
                }



            

    }

        public void DrawText(String text)
        {

            Game1.spriteBatch.DrawString(Game1.font, text, new Vector2(20, 540), Color.Black);


        }


    }
}
