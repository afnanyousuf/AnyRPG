using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace AnyRPG
{
   public class ActionScreen : GameScreen
    {


        /* 1 = Grass
         * 51 = NorthWest Grass to Water
         * 52 = Water
         * 53 = East Grass to Water
         * 54 = North Grass to Water
         * 55 = South East Grass to Water
         * 56 = West Grass to Water
        */


    int[,] WorldMap = new int[,]{
                {1,1,1,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52},
                {1,1,1,1,1,1,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54,54},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {52,52,52,54,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {52,52,56,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {52,52,56,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {52,52,56,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {52,52,56,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {54,54,51,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52},
                {52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52},
                {52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52,52},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,52,52,52,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,52,2,2,2,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,52,2,2,2,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,52,2,2,2,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,52,2,2,2,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,52,52,52,52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                
                

            };



    int[,] WorldLayer2 = new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},


            };





      
       //gamefont
        SpriteFont gameFont;
       //screen bounds
        Rectangle screenRectangle;
       //create new map
         Map map = new Map();
         SpriteFont playerinfofont;
        List<Texture2D> gameObjects = new List<Texture2D>();
        Vector2 charPosition = new Vector2(0, 0);
        
        MageChar characterSprite = new MageChar();

        StatBar statBar;
        int oldlvl;
        Player player;
        Combat combat;
       public Player ActionPlayer{
           get { return player; }
}
        public static Camera camera;

        List<TriggerTile> triggertiles = new List<TriggerTile>();

        List<gameObject> gameObjs = new List<gameObject>();
        gameObject house, bigHouse;
        List<Enemy> enemies = new List<Enemy>();
        Enemy alien;
        int currentHealth;
        Texture2D healthicon, defenseicon, intelligenceicon, magicicon, rangingicon, speedicon, swordicon;
        public String playerClass;
        public int defense, intelligence, health, speed, ranging, magic, sword;
        Texture2D userstats, playerinfo;
        public bool XPUpdated = false;
        NPC RAJ;
        public static String dialogueText = "";
      
        public ActionScreen(Game game, SpriteBatch spriteBatch, SpriteFont newfont, ContentManager Content, Player getPlayer)
            : base(game, spriteBatch)
        {
            //sets image to the contents that was loaded 
            this.player = getPlayer;
            gameFont = newfont;
            map.Generate(WorldMap, 48, WorldLayer2);


            currentHealth = playerHealth(player);
            
            // gameObjects.Add(Content.Load<Texture2D>("gameObjects\\house"));
           // gameObjects.Add(Content.Load<Texture2D>("gameObjects\\bighouse"));
            gameObjects.Add(Content.Load<Texture2D>("gameObjects\\fountain"));
            gameObjects.Add(Content.Load<Texture2D>("gameObjects\\tree"));
            gameObjects.Add(Content.Load<Texture2D>("gameObjects\\deadtree"));
            gameObjects.Add(Content.Load<Texture2D>("king"));



            
            userstats = Content.Load<Texture2D>("statsbar");
            playerinfo = Content.Load<Texture2D>("playerInfo");
            playerinfofont = Content.Load<SpriteFont>(@"Fonts\player");
            house = new gameObject(new Vector2(200, 100), Content.Load<Texture2D>("gameObjects\\house"), false, "House");
            bigHouse = new gameObject(new Vector2(600, 100), Content.Load<Texture2D>("gameObjects\\bighouse"), false, "Press Space to Enter House");

            gameObjs.Add(house);
            gameObjs.Add(bigHouse);


            alien = new Enemy(Content.Load<Texture2D>("npc5"), new Vector2(300, 300), "Mr. Alien");
            enemies.Add(alien);

            CreateTriggerTiles();
            
           
            statBar = new StatBar(Content);
            camera = new Camera(Game1.graphics.GraphicsDevice.Viewport);
            Texture2D guy = Content.Load<Texture2D>("gg");

            RAJ = new NPC(new Vector2(100, 300),guy, "RAJ", new String[,] { { "Greetings young one, how are you feeling this morning?", "If you feel the need to fullfil this quest of yours then so be it.", "But remember, King Dyden is a very strong and reknowned adversary. You will not be able to defeat him easily.", "If you are going to go on this journey you will need tools and information.", "Go and find the local blacksmith and talk to him" }, { "sdfsd", "sdfsdf", "sdfsdf", " ", " " }, { "Hello /* player.getname */ how are ", "here da key", "finish da game boi", " ", " " }, { "sd", "raj", "sdfsd", " ", " " }, { "sdfsd", "sdfsdf", "sdfsdf", " ", " " }, { "Hello /* player.getname */ how are ", "here da key", "finish da game boi", " ", " " }, { "sd", "raj", "sdfsd", " ", " " }, { "sdfsd", "sdfsdf", "sdfsdf", " ", " " }, { "Hello /* player.getname */ how are ", "here da key", "finish da game boi", " ", " " } });
            
            
            characterSprite.LoadContent(Content, player);
            
         
            //creates a rectangle game screen the same dimensions as the window
            screenRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
        }

        public void CreateTriggerTiles()
        {
            triggertiles.Add(new TriggerTile(new Vector2(13, 4), new Vector2(20, 30), new Vector2(20, 32)));
        }


        public override void Update(GameTime gameTime)
        {
            
            foreach (gameTiles tile in map.CollidingTiles)
                CheckRectangles(tile.Rectangle);
            /*
            foreach (gameTiles gameObj in map.Layer2)
                CheckRectangles(gameObj.Rectangle);
            */

            if (combatScreen.playerdead)
            {
                characterSprite.Position = new Vector2(50, 500);
                combatScreen.playerdead = false;
            }

            UpdateLevel();

            

            Console.Write("oldlvl: " + oldlvl + " Currentlvl: " + player.PlayerLevel);
        
            
            characterSprite.Update(gameTime, player);
           
           //Health Bar Testing
            if (Game1.CheckKey(Keys.K))
            {
                currentHealth -= 1;
                player.inDialog = true;
                RAJ.SpeakDialog(player.PlayerLevel);
                
            }
            
            if (Game1.CheckKey(Keys.L))
            {
                currentHealth += 1;
                player.Abilities.Magic += 5;
                player.Abilities.Health += 100;
                currentHealth = player.Abilities.Health;

            }

            currentHealth = (int)MathHelper.Clamp(currentHealth, 0, player.Abilities.Health);
            player.hitPoints[0] = currentHealth;
            
            statBar.Update(spriteBatch, characterSprite.Size, characterSprite.Position, currentHealth, player.Abilities.Health);
            camera.Update(characterSprite.Position, map.Width+userstats.Width, map.Height,1.0f);

            //update player from combat
            player.gold = combatScreen.money;
            player.experiencePoints = combatScreen.XP;
          
               


            foreach (Enemy enemy in enemies)
            {
                    enemy.Update(false,gameTime);
                    if (characterSprite.Size.Intersects(enemy.boundingBox) && enemy.isVisible)
                    {
                        stopCharacter(characterSprite);
                
                      
                        if (Game1.CheckKey(Keys.Space))
                        {
                            enemy.Update(true, gameTime);
                            combat = new Combat(enemy, ActionPlayer);
                            Game1.CombatScreen.InitiateCombat(combat);


                            }
                       
                    }
                }
            


            foreach (TriggerTile tile in triggertiles)
            {


                    if (playerPos() == tile.triggerTile)
                    {
                        characterSprite.Position = tileToVector(tile.locationTile);
                    }

                    if (playerPos() == tile.returnTile)
                    {
                        characterSprite.Position = tileToVector((int)tile.triggerTile.X,(int)tile.triggerTile.Y+1);
                    }

                }
                   


            
            


            foreach (gameObject objects in gameObjs)
            {
                    objects.Update(false);

                    if (characterSprite.Size.Intersects(objects.bounds))
                    {
                        stopCharacter(characterSprite);
                       
                    }
                

            }

            base.Update(gameTime);
            oldlvl = player.PlayerLevel;
        }

        private void LoadContent(ContentManager Content)
        { }
        
      

        public override void Draw(GameTime gameTime)
        {
           
            //end previous spritebatch and draw new one
            
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            //draw map..
            map.Draw(spriteBatch);

            RAJ.Draw(spriteBatch);

            //draw gameobjects..
            foreach (gameObject objects in gameObjs)
            {
                objects.Draw(spriteBatch);

            }
                    
            if(player.inDialog == true){
                spriteBatch.DrawString(gameFont, dialogueText, new Vector2(20, 540), Color.Red);

                }
            
            //draw monsters..

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
                
            }

           
            
            
            //draw character..
            characterSprite.Draw(spriteBatch);
            map.DrawLayer2(spriteBatch);




           
            
            spriteBatch.DrawString(gameFont, playerPos().ToString(), new Vector2((int)characterSprite.Position.X, (int)characterSprite.Size.Bottom + 10), Color.White);
            statBar.Draw(spriteBatch, characterSprite.Size, characterSprite.Position, currentHealth, player.Abilities.Health);
            DrawText();


            spriteBatch.End();
            base.Draw(gameTime);
        }

     


        public void stopCharacter(MageChar Character)
        {
            Character.Position = Character.lastPosition;

        }

        public int playerHealth(Player currentplayer)
        {
            return currentplayer.HitPointsCurrent;
        }



        private void CheckRectangles(Rectangle TileRect)
        {
            if (characterSprite.Size.Intersects(TileRect))
            {
                characterSprite.Position = characterSprite.lastPosition;

            }

        }




        private Vector2 playerPos()
        {
            float tileX = characterSprite.Position.X / 48;
            float tileY = characterSprite.Position.Y / 48;
            return new Vector2((float)Math.Round(tileX, 0), (float)Math.Round(tileY, 0));
        }

        private Vector2 tileToVector(int tileX, int tileY)
        {
            float vectorX = tileX * 48;
            float vectorY = tileY * 48;

            return new Vector2(vectorX, vectorY);

        }
        private Vector2 tileToVector(Vector2 tile)
        {

            return new Vector2(tile.X * 48, tile.Y * 48);

        }












        //draws the name and the stats of the character to the screen
        private void DrawText()
        {
            
            spriteBatch.Draw(userstats, new Vector2(camera.center.X + 325, camera.center.Y - 310), Color.White);
            spriteBatch.Draw(playerinfo, new Vector2(camera.center.X + 260, camera.center.Y + 180), Color.White);
            spriteBatch.DrawString(playerinfofont, player.gold.ToString(), new Vector2(camera.center.X + 350, camera.center.Y + 200), Color.Red);
            spriteBatch.DrawString(playerinfofont, player.XP.ToString(), new Vector2(camera.center.X + 355, camera.center.Y + 230), Color.Red);
            spriteBatch.DrawString(playerinfofont, player.level.ToString(), new Vector2(camera.center.X + 355, camera.center.Y + 265), Color.Red);

            //draw the current stats and player name to the screen
            spriteBatch.DrawString(gameFont, player.Name, new Vector2(characterSprite.Position.X, characterSprite.Position.Y + 50)
                , Color.Gold);
            //Statistic Information
            spriteBatch.DrawString(gameFont, player.Abilities.Defense.ToString(), new Vector2(camera.center.X + 370, camera.center.Y - 260)
                , Color.Gold);
            spriteBatch.DrawString(gameFont, currentHealth + "/" + player.Abilities.Health.ToString(), new Vector2(camera.center.X + 365, camera.center.Y - 195)
                , Color.Gold, 0.5f, new Vector2(0,0),0.7f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(gameFont, player.Abilities.Intelligence.ToString(), new Vector2(camera.center.X + 370, camera.center.Y - 130)
                , Color.Gold);
            spriteBatch.DrawString(gameFont, player.Abilities.Speed.ToString(), new Vector2(camera.center.X + 370, camera.center.Y - 65)
                , Color.Gold);
            spriteBatch.DrawString(gameFont, player.Abilities.Magic.ToString(), new Vector2(camera.center.X + 370, camera.center.Y)
                , Color.Gold);
            spriteBatch.DrawString(gameFont, player.Abilities.Strength.ToString(), new Vector2(camera.center.X + 370, camera.center.Y + 65)
                , Color.Gold);
            spriteBatch.DrawString(gameFont, player.Abilities.Ranging.ToString(), new Vector2(camera.center.X + 370, camera.center.Y + 130)
                , Color.Gold);
            




        }



        public void UpdateLevel()
        {
            
            
            if (player.XP != 0)
            {
                if (player.XP % 100 == 0 && XPUpdated==false)
                {
                    

                        player.level += 1;


                        switch (player.PlayerClass)
                        {
                            case "Ranger":
                                player.Abilities.Strength += 5;
                                player.Abilities.Speed += 5;
                                player.Abilities.Intelligence += 5;
                                player.Abilities.Defense += 5;
                                player.Abilities.Attack += 5;
                                player.Abilities.Health += 5;
                                player.Abilities.Magic += 5;
                                player.Abilities.Armor += 5;
                                player.Abilities.Ranging += 5;
                                break;

                            case "Mage":

                                player.Abilities.Strength += 5;
                                player.Abilities.Speed += 5;
                                player.Abilities.Intelligence += 5;
                                player.Abilities.Defense += 5;
                                player.Abilities.Attack += 5;
                                player.Abilities.Health += 5;
                                player.Abilities.Magic += 5;
                                player.Abilities.Armor += 5;
                                player.Abilities.Ranging += 5;
                                break;

                            case "Warrior":

                                player.Abilities.Strength += 5;
                                player.Abilities.Speed += 5;
                                player.Abilities.Intelligence += 5;
                                player.Abilities.Defense += 5;
                                player.Abilities.Attack += 5;
                                player.Abilities.Health += 5;
                                player.Abilities.Magic += 5;
                                player.Abilities.Armor += 5;
                                player.Abilities.Ranging += 5;
                                break;
                        }
                        currentHealth = player.Abilities.Health;
                        XPUpdated = true;

                    }
            }
            
            

            
        }

        















       









    }
}
