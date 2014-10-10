using System;
using System.Diagnostics;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityWeb : Entity
    {
        private static bool isSlowingPlayer;
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();
        private double prop_SlowStrength = 2;
        private int prop_removetime = 3000;

        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid.
        /// </summary>
        public EntityWeb(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            EntityControlledByAi = false;
            Type = ObjectType.WEB;
            IsSolid = false;
        }

        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, staat vanaf het begin stil.
        /// </summary>
        public EntityWeb(int width, int height, int x, int y) : this(width, height, x, y, 0, 0)
        {
        }

        /// <summary>
        /// Hoe hoger de waarde hoe langzamer je door een web loopt. MIN: 1, DEFAULT = 3000
        /// </summary>
        public double SlowStrength
        {
            get { return prop_SlowStrength; }
            set { prop_SlowStrength = Math.Max(1, value); }
        }

        /// <summary>
        /// Hoe hoger de waarde hoe langzamer je door een web loopt. MIN: 0, DEFAULT = 2
        /// </summary>
        public int RemoveTime
        {
            get { return prop_removetime; }
            set { prop_removetime = Math.Max(0, value); }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Een web van spider";
        }


        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                if (CollidesWithObject(Playfield.Player) == CollisionType.NONE)
                {
                    if (isSlowingPlayer)
                    {
                        Playfield.Player.SpeedModifier *= SlowStrength;
                        isSlowingPlayer = false;
                    }

                    // Object uit de gameloop halen na een bepaalde tijdsduur
                    if (stopwatch.ElapsedMilliseconds >= RemoveTime)
                    {
                        OlympusTheGame.Playfield.RemoveObject(this);
                    }
                }
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            if (gameObject.Type == ObjectType.Player)
            {
                // Maak de speler langzamer wanneer hij door een cobweb loopt
                if (!isSlowingPlayer)
                {
                    Playfield.Player.SpeedModifier = Playfield.Player.SpeedModifier/SlowStrength;
                    isSlowingPlayer = true;
                }
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Cobweb";
        }
    }
}