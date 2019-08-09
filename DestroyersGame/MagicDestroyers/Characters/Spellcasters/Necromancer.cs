using MagicDestroyers.Equipment.Armors;
using MagicDestroyers.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicDestroyers.Characters.Spellcasters
{
    public class Necromancer
    {
        #region Fields
        private int abilityPoints;
        private int healthPoints;
        private int level;

        private string faction; 
        private string name;

        private LightLeatherVest bodyArmor;
        private Sword weapon;
        #endregion

        #region Proprties

        public int AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            set
            {
                if (value > 0)
                    abilityPoints = value;
                else
                    abilityPoints = 0;
            }
        }
        public int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            set
            {
                if (value > 0)
                    healthPoints = value;
                else
                    healthPoints = 0;
            }
        }
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                if (value > 0)
                    level = value;
                else
                    level = 0;
            }
        }
        public string Faction
        {
            get
            {
                return faction;
            }
            set
            {
                if (value == "Gabriel" || value == "Diablo")
                    faction = value;
                else
                    faction = "Unknow faction";
            }
        }
        #endregion
        #region Constructor
        public Necromancer()
            :this("Necromancer",15)
        {

        }
        public Necromancer(string name, int level)
            :this(name,level,26)
        {

        }
    public Necromancer(string name, int level, int healthPoints)
    {
        this.name = name;
        this.HealthPoints = healthPoints;
        this.level = level;
        this.faction = "Melee";
        this.abilityPoints = 100;
        this.bodyArmor = new LightLeatherVest();
        this.weapon = new Sword();
    }
    
        #endregion

        #region Methods
        private void ShadowRage()
        {

        }

        private void VampireTouch()
        {

        }

        private void BoneShield()
        {

        }
        #endregion

    }
}

