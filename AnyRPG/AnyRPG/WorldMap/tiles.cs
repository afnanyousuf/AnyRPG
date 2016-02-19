using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace AnyRPG
{
    public class Tiles
    {

       
        protected Texture2D texture;

        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            protected set { rectangle = value; }

        }

        private static ContentManager content;

        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, rectangle, Color.White);
           
        }

    }

   public class gameTiles : Tiles
    {

  
        public gameTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(@"Tiles\Tile" + i);
            this.Rectangle = newRectangle;

        }
        public gameTiles(int i, int PosX, int PosY, bool Layer2)
        {
            texture = Content.Load<Texture2D>(@"TileObjs\Object" + i);
            this.Rectangle = new Rectangle(PosX,PosY,texture.Width-5, texture.Height-10);

        }
        public gameTiles(Texture2D newtexture)
        {
            texture = newtexture;
        }

    }


   public class TriggerTile
   {
     public Vector2 locationTile, triggerTile, returnTile;

       public TriggerTile(Vector2 newtriggerTile, Vector2 newlocationTile, Vector2 newreturnTile)
       {
           this.triggerTile = newtriggerTile;
           this.locationTile = newlocationTile;
           this.returnTile = newreturnTile;
       }

   


   }


}
