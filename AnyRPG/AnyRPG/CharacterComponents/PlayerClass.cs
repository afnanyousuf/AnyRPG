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
using Microsoft.Xna.Framework.Net;

namespace AnyRPG
{
    public class Player : characterAbilities
    {

        protected String playerClass;
        protected bool playerInCombat = false;
        protected String gender;
        protected String name;
        protected String[] combatAbilities = new String[5];
        public int gold;
        public int level;
        public int[] hitPoints = new int[2];
        static String difficulty = "Easy";
        public bool inDialog = false;
        public int experiencePoints;
        protected characterAbilities abilities = new characterAbilities();

        public static String Difficulty
        {
            get { return difficulty; }
            set { value = difficulty; }

        }

        public String[] CombatAbilities
        {
            get { return combatAbilities; }
        }


        public bool PlayerInCombat
        {
            get { return playerInCombat; }
            set { value = playerInCombat; }
        }

        public characterAbilities Abilities
        {
            get { return abilities; }
           // set { value = abilities; }
        }
         
        public int Gold
        {
            get { return this.gold; }
        }
        public void AddGold(int gold)
        {
            this.gold += gold;
        }
        public void SubtractGold(int gold){
            this.gold -= gold;
        }
        public int HitPointsMax
        {
            get { return hitPoints[1]; }
        }

        public int HitPointsCurrent
        {
            get { return hitPoints[0]; }
            set { value = hitPoints[0]; }
        }

        public int XP
        {
            get { return this.experiencePoints; }
        }

        public void AddXP(int xp)
        {
            this.experiencePoints += xp;
        }



        public int PlayerLevel
        {
            get { return this.level; }
            set { value = this.level; }
        }

        public String PlayerClass
        {
            get { return playerClass; }
            set { value = playerClass; }
           
        }

        public String Gender
        {
            get { return gender; }
           
        }

        public String Name
        {
            get { return name; }
            set { value = name; }
        }



        public Player(String PlayerName, String classGender, String pclass){
            gender = classGender;
            name = PlayerName;
            playerClass = pclass;
            gold = 100;
            level = 1;
            experiencePoints = 0;
        
        }


       





    }
}

