using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;


namespace AnyRPG
{
    public class Map
    {


        private List<gameTiles> normalTiles = new List<gameTiles>();
        private List<gameTiles> collidingTiles = new List<gameTiles>();
        private List<gameTiles> layer2 = new List<gameTiles>();

        public List<gameTiles> NormalTiles
        {
            get { return normalTiles; }
        }

        public List<gameTiles> CollidingTiles
        {
            get { return collidingTiles; }
        }

        public List<gameTiles> Layer2
        {
            get { return layer2; }
        }

        private int width, height;


        public int Width
        {
            get { return width; }

        }

        public int Height
        {
            get { return height; }
        }





        public Map()
        {

        }






        private void LoadContent(ContentManager Content)
        {

            








        }

        public void Update(GameTime gameTime)
        {
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (gameTiles tile in NormalTiles)
                tile.Draw(spriteBatch);

            




        }
        public void DrawLayer2(SpriteBatch spriteBatch)
        {
            foreach (gameTiles objs in Layer2)
                objs.Draw(spriteBatch);

        }

        public void Generate(int[,] map, int size, int[,] objectLayer)
        {

            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0)
                        normalTiles.Add(new gameTiles(number, new Rectangle(x * size, y * size, size, size)));
                   
                    if (number >= 3)
                        collidingTiles.Add(new gameTiles(number, new Rectangle(x * size, y * size, size, size)));
                    
                    width = (x + 1) * size;
                    height = (y + 1) * size;


                }

            for (int x = 0; x < objectLayer.GetLength(1); x++)
                for (int y = 0; y <  objectLayer.GetLength(0); y++)
                {
                    int number = objectLayer[y, x];

                    if (number > 0)
                        layer2.Add(new gameTiles(number, x*size,y*size,true));


                }


        }






    }
}
