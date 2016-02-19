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
    public class warriorCharacter : Player
    {
       
        const int startingStrength = 5;
        const int startingSpeed = 7;
        const int startingIntelligence = 4;
        const int startingDefense = 5;
        const int startingAttack = 5;
        const int startingHealth = 10;
        const int startingArmor = 5;
        const int startingRanging = 1;
        const int startingMagic = 1;



        public warriorCharacter(String name, String gender, String pclass)
            : base(name, gender, pclass)
        {
            this.name = name;
            this.gender = gender;
            this.PlayerClass = pclass;
            hitPoints[0] = startingHealth;
            hitPoints[1] = startingHealth;
            combatAbilities[0] = "Slash";
            combatAbilities[1] = "Stab";
            combatAbilities[2] = "Smash";
            combatAbilities[3] = "HP Steal";
            combatAbilities[4] = "Miss";
            abilities.Strength = startingStrength;
            abilities.Speed = startingSpeed;
            abilities.Intelligence = startingIntelligence;
            abilities.Defense = startingDefense;
            abilities.Attack = startingAttack;
            abilities.Health = startingHealth;
            abilities.Magic = startingMagic;
            abilities.Armor = startingArmor;
            abilities.Ranging = startingRanging;


        }//end warrior character
    }
}

