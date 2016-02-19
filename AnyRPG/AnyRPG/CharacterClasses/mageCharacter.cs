using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace AnyRPG
{
    public class mageCharacter : Player
    {

        
        //variables are intialized       
        
        const int startingStrength = 1;
        const int startingSpeed = 2;
        const int startingIntelligence = 5;
        const int startingDefense = 4;
        const int startingAttack = 3;
        const int startingHealth = 20;
        const int startingMagic = 5;
        const int startingArmor = 5;
        const int startingRanging = 1;
     

        public mageCharacter(String name, String gender, String pclass)
            :base(name, gender,pclass)
        {

            this.name = name;
            this.gender = gender;
            this.PlayerClass = pclass;
            hitPoints[0] = startingHealth;
            hitPoints[1] = startingHealth;
            combatAbilities[0] = "Water Strike";
            combatAbilities[1] = "Earth Strike";
            combatAbilities[2] = "Fire Strike";
            combatAbilities[3] = "Heal";
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
