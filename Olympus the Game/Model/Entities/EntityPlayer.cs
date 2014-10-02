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
        private double speedModifier = 1;
        private int dx;
        private int dy;
        public double SpeedModifier
        {
            get
            {
                return speedModifier;
            }
            set
            {
                double prevSpeed = speedModifier;
                speedModifier = value;
                DX = Convert.ToInt32(DX / prevSpeed * speedModifier);
                DY = Convert.ToInt32(DY / prevSpeed * speedModifier);
            }
        }
        public override int DX
        {
            get
            {
                return dx;
            }
            set
            {
                dx = Convert.ToInt32(value * speedModifier);
            }
        }
        public override int DY
        {
            get
            {
                return dy;
            }
            set
            {
                dy = Convert.ToInt32(value * speedModifier);
            }
        }
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = Math.Max(0, value);
                health = Math.Min(MAXHEALTH, value);
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
            Type = ObjectType.PLAYER;
        }

    }
}
