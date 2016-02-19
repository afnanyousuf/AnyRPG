using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AnyRPG
{
    public class rangerCharacter : Player
    {
       
        const int startingStrength = 1;
        const int startingSpeed = 5;
        const int startingIntelligence = 6;
        const int startingDefense = 5;
        const int startingAttack = 4;
        const int startingHealth = 10;
        const int startingRanging = 5;
        const int startingArmor = 5;
        const int startingMagic = 1;



        public rangerCharacter(String name, String gender, String pclass)
            :base(name, gender, pclass)
        {




            this.name = name;
            this.gender = gender;
            this.PlayerClass = pclass;
            hitPoints[0] = startingHealth;
            hitPoints[1] = startingHealth;
            combatAbilities[0] = "Rain of Arrows";
            combatAbilities[1] = "Flaming Arrow";
            combatAbilities[2] = "Enchanted Bow";
            combatAbilities[3] = "BloodThirst Arrow";
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
            



        }
    }
}

