using System;
using System.Collections.Generic;
using System.Text;

namespace MagicDestroyers.Equipment.Weapons
{
    public class Staff
    {
        private int damage;

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                if (value > 1)
                    damage = value;
                else
                    damage = 1;
            }
        }

        private void Empower()
        {

        }
    }
}
