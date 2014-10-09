using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityPlayer : Entity
    {
        /// <summary>
        /// De maximum health van een speler
        /// </summary>
        public const int MAXHEALTH = 5;
        private int health;
        private double speedModifier = 1;
        private int dx;
        private int dy;
        private float prop_frame = 0;
        private int frameCount = 1;

        public override float Frame
        {
            get
            {
                //return 0.5f;
                if (prop_frame == 0.5f)
                {
                    frameCount++;
                    if (frameCount % 20 == 0)
                        prop_frame = 0f;
                    return 0.5f;
                }
                return prop_frame;
            }
            protected set
            {
                prop_frame = Math.Min(value, 1f);
                prop_frame = Math.Max(value, 0f);
            }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "De speler";
        }


        /// <summary>
        /// De snelheid van de speler
        /// </summary>
        public static int PlayerSpeed { get; set; }
        /// <summary>
        /// In hoeverre wordt de snelheid van de speler aangepast. Zodra deze wordt aangepast wordt de DX en DY van de speler direct aangepast.
        /// </summary>
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
        /// <summary>
        /// Custom DX omdat wij bij de EntityPlayer de speedmodifier ook mee moeten nemen in de snelheid.
        /// </summary>
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
        /// <summary>
        /// Custom DY omdat wij bij de EntityPlayer de speedmodifier ook mee moeten nemen in de snelheid.
        /// </summary>
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
        /// <summary>
        /// De Health van de speler
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                int prevHealth = health;
                health = Math.Max(0, value);
                health = Math.Min(MAXHEALTH, value);
                if (prevHealth != health)
                {
                    OlympusTheGame.Controller.PlayerHealthChanged(this, this.Health, prevHealth);
                    Frame = 0.5f;
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
            Type = ObjectType.PLAYER;
        }
    }
}
