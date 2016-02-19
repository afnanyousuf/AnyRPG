using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;




namespace AnyRPG
{
    public class characterAbilities
    {
        String[] abilityNames = {
            "STRENGTH",
            "SPEED",
            "INTELLIGENCE",
            "DEFENSE",
            "ATTACK",
            "HEALTH",
            "MAGIC",
            "RANGING",
            "ARMOR"
        };


        public enum Abilities {
            Strength = 0,
            Speed = 1,
            Intelligence = 2,
            Defense = 3,
            Attack = 4,
            Health = 5,
            Magic = 6,
            Ranging = 7,
            Armor = 8,
        };


        int strength;
        int speed;
        int intelligence;
        int defense;
        int attack;
        int health;
        int magic;
        int ranging;
        int armor;
        Color color;
      


        const float minimumAbility = 1f;
        const float maximumAbility = 30f;


        public int Attack{
            get{
                return this.attack;
            }
            
            set{
                value = this.attack;
            }


        }

      

        public int Strength
        {
            get{
                return this.strength;
            }
            set{
                this.strength = value;
            }
        }
        public int Speed
        {
            get{
                return this.speed;
            }
            set{
                this.speed = value;
            }
        }
        public int Intelligence
        {
            get{
                return this.intelligence;
            }
            set{
                this.intelligence = value;
            }
        }
        public int Defense
        {
            get{
                return this.defense;
            }
            set{
                this.defense = value;
            }
        }
        public int Health
        {
            get{
                return health;
            }
            set{
                this.health = value;
            }
        }
        public int Magic
        {
            get{
                return this.magic;
            }
            set{
                this.magic = value;
            }
        }
        public int Ranging
        {
            get{
                return this.ranging;
            }
            set{
                this.ranging = value;
            }
        }
        public int Armor
        {
            get{
                return this.armor;
            }
            set{
                this.armor = value;
            }
        }




    }
}