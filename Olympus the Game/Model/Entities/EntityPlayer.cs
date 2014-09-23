using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityPlayer : Entity
    {
        public const int MAXHEALTH = 5;
        private int health = MAXHEALTH;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value >= 0 && value <= MAXHEALTH)
                {
                    health = value;
                }
            }
        }

        public override void PaintObject()
        {
            throw new System.NotImplementedException();
}
    }
}
