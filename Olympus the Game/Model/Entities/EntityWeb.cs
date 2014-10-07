using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntityWeb : Entity
    {
        private static bool isSlowingPlayer = false;
        private Stopwatch stopwatch = Stopwatch.StartNew();
        private double prop_SlowStrength = 2;
        private int prop_removetime = 3000;
        /// <summary>
        /// Hoe hoger de waarde hoe langzamer je door een web loopt. MIN: 1, DEFAULT = 3000
        /// </summary>
        public double SlowStrength
        {
            get { return prop_SlowStrength; }
            set
            {
                prop_SlowStrength = Math.Max(1, value);
            }
        }
        /// <summary>
        /// Hoe hoger de waarde hoe langzamer je door een web loopt. MIN: 0, DEFAULT = 2
        /// </summary>
        public int RemoveTime
        {
            get { return prop_removetime; }
            set
            {
                prop_removetime = Math.Max(0, value);
            }
        }

        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid.
        /// </summary>
        public EntityWeb(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = false;
            Type = ObjectType.WEB;
            IsSolid = false;
        }
        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, staat vanaf het begin stil.
        /// </summary>
        public EntityWeb(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            if (this.CollidesWithObject(Playfield.Player) == CollisionType.NONE)
            {
                if (isSlowingPlayer)
                {
                    Playfield.Player.SpeedModifier *= SlowStrength;
                    isSlowingPlayer = false;
                }

                // Object uit de gameloop halen na een bepaalde tijdsduur
                if (stopwatch.ElapsedMilliseconds >= RemoveTime)
                {
                    OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
                    OlympusTheGame.INSTANCE.Playfield.RemoveObject(this);
                }
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            // Maak de speler langzamer wanneer hij wanneer hij door een cobweb loopt
            if (!isSlowingPlayer)
            {
                Playfield.Player.SpeedModifier = Playfield.Player.SpeedModifier / SlowStrength;
                isSlowingPlayer = true;
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }
        public override string ToString()
        {
            return "Cobweb";
        }
    }
}
