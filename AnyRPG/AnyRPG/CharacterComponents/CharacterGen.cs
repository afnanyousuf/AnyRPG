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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace AnyRPG
{
    public class characterGenerator 
    {
        public enum CharClass { Ranger = 0, Mage = 1, Warrior = 2 }




        static string[] classNames = { "Ranger", "Mage", "Warrior" };


        protected string name;
        protected bool gender;
        protected int level = 1;


        protected characterAbilities abilities;
        protected String className;
        protected Game game;
        protected SpriteBatch spriteBatch;
        protected ContentManager Content;



        public String Name
        {
            get
            {
                return name;
            }
        }

        public String ClassName
        {
            get
            {
                return className;
            }
        }
        public static String[] ClassNames
        {
            get
            {
                return classNames;
            }
        }


        public characterAbilities Abilities
        {
            get
            {
                return abilities;
            }
        }


    }
}
