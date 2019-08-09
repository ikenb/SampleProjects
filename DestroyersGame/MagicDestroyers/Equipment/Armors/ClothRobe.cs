using System;
using System.Collections.Generic;
using System.Text;

namespace MagicDestroyers.Equipment.Armors
{
    public class ClothRobe
    {
        private int armorPoints;

        public int ArmorPoints
        {
            get
            {
                return armorPoints;
            }
            set
            {
                if (value > 1)
                    armorPoints = value;
                else
                    armorPoints = 1;
            }
        }
        public ClothRobe()
        {

        }
    }
}
