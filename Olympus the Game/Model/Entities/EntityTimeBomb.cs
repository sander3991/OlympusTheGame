using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus_the_Game;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntityTimeBomb : EntityExplode
    {
        private Stopwatch stopwatch;
        private bool isTimerStarted = false;
        private int prop_explodetime = 3000;
        private int prop_detectradius = 100;
        private int prop_exploderadius = 100;

        public override float Frame
        {
            get
            {
                if (stopwatch == null)
                    return 0.0f;
                else
                    return (float)(stopwatch.ElapsedMilliseconds % ExplodeTime) / 500.0f;
            }
            protected set
            {
                base.Frame = value;
            }
        }

        public EntityTimeBomb() : this(0, 0, 0, 0, 0) { }

        /// <summary>
        /// Tijd voordat dit object explodeert na contact met speler (in msec). MIN = 0, DEFAULT = 3000
        /// </summary>
        public int ExplodeTime
        {
            get { return prop_explodetime; }
            set
            {
                prop_explodetime = Math.Max(0, value);
            }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Tijdbom ontploft na een paar seconden";
        }

        /// <summary>
        /// De afstand waarin de timebom de speler herkend. MIN = 50, DEFAULT = 100
        /// </summary>
        public int DetectRadius
        {
            get { return prop_detectradius; }
            set
            {
                prop_detectradius = Math.Max(50, value);
            }
        }
        /// <summary>
        /// De afstand waarin de explosie plaatsvindt. MIN = 0, DEFAULT = 100
        /// </summary>
        public int ExplodeRadius
        {
            get { return prop_exploderadius; }
            set
            {
                prop_exploderadius = Math.Max(0, value);
            }
        }

        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntityTimeBomb(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy, effectStrength)
        {
            EntityControlledByAI = false;
            OlympusTheGame.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.TIMEBOMB;
        }
        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Staat vanaf het begin stil.
        /// </summary>
        public EntityTimeBomb(int width, int height, int x, int y, double effectStrength)
            : this(width, height, x, y, 0, 0, effectStrength)
        {

        }

        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Start de timer wanneer een speler zich in de buurt bevindt
                if (!isTimerStarted && DistanceToObject(Playfield.Player) <= DetectRadius)
                {
                    stopwatch = Stopwatch.StartNew();
                    isTimerStarted = true;
                }

                // Ontplof als de timer langer dan x seconden aanstaat en de speler zich NIET in de buurt bevindt
                if (isTimerStarted && stopwatch.ElapsedMilliseconds >= ExplodeTime && DistanceToObject(Playfield.Player) >= DetectRadius)
                    Playfield.RemoveObject(this);
                // Ontplof als de timer langer dan x seconden aanstaat en de speler zich WEL in de buurt bevindt
                else if (isTimerStarted && stopwatch.ElapsedMilliseconds >= ExplodeTime && DistanceToObject(Playfield.Player) <= DetectRadius)
                {
                    Playfield.Player.Health--;
                    Playfield.RemoveObject(this);
                }

            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop na een mooie explosie
            Playfield.AddObject(new SpriteExplosion(75, 75, this.X, this.Y));
            OlympusTheGame.Controller.UpdateGameEvents -= OnUpdate;
            if (!fieldRemoved)
                SoundEffects.PlaySound(Properties.Resources.bomb);
        }

        public override void OnCollide(GameObject gameObject)
        {
            // Voorkomt dat de bom ontploft als het in aanraking komt door te overriden
        }

        public override string ToString()
        {
            return "TimeBomb";
        }
    }
}
