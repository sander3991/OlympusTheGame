using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityPlayer : Entity
    {
        public const int MAXHEALTH = 5;
        private int health;
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
        /// <summary>
        /// Initialiseert een spelerobject, een speler begint standaard met <paramref name="=MAXHEALTH"/> health.
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public EntityPlayer(int width, int height, int x, int y)
            : base(width, height, x, y, 0, 0)
        {
            health = MAXHEALTH;
        }

        public override void PaintObject()
        {
            throw new System.NotImplementedException();
}
    }
}
