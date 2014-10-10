using System;
using System.Diagnostics;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model.Sprites;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityTimeBomb : EntityExplode
    {
        private bool isTimerStarted;
        private int prop_detectradius = 100;
        private int prop_exploderadius = 100;
        private int prop_explodetime = 3000;
        private Stopwatch stopwatch;

        static EntityTimeBomb()
        {
            RegisterWithEditor(ObjectType.Timebomb, () => new EntityTimeBomb(50, 50, 0, 0, 1f));
                // TODO Maak waarden standaard
        }

        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntityTimeBomb(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy, effectStrength)
        {
            EntityControlledByAi = false;
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            Type = ObjectType.Timebomb;
        }

        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Staat vanaf het begin stil.
        /// </summary>
        public EntityTimeBomb(int width, int height, int x, int y, double effectStrength)
            : this(width, height, x, y, 0, 0, effectStrength)
        {
        }

        public override float Frame
        {
            get
            {
                if (stopwatch == null)
                    return 0.0f;
                return stopwatch.ElapsedMilliseconds%ExplodeTime/500.0f;
            }
            protected set { base.Frame = value; }
        }

        /// <summary>
        /// Tijd voordat dit object explodeert na contact met speler (in msec). MIN = 0, DEFAULT = 3000
        /// </summary>
        public int ExplodeTime
        {
            get { return prop_explodetime; }
            set { prop_explodetime = Math.Max(0, value); }
        }

        /// <summary>
        /// De afstand waarin de timebom de speler herkend. MIN = 50, DEFAULT = 100
        /// </summary>
        public int DetectRadius
        {
            get { return prop_detectradius; }
            set { prop_detectradius = Math.Max(50, value); }
        }

        /// <summary>
        /// De afstand waarin de explosie plaatsvindt. MIN = 0, DEFAULT = 100
        /// </summary>
        public int ExplodeRadius
        {
            get { return prop_exploderadius; }
            set { prop_exploderadius = Math.Max(0, value); }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Tijdbom ontploft na een paar seconden";
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
                if (isTimerStarted && stopwatch.ElapsedMilliseconds >= ExplodeTime &&
                    DistanceToObject(Playfield.Player) >= DetectRadius)
                    Playfield.RemoveObject(this);
                    // Ontplof als de timer langer dan x seconden aanstaat en de speler zich WEL in de buurt bevindt
                else if (isTimerStarted && stopwatch.ElapsedMilliseconds >= ExplodeTime &&
                         DistanceToObject(Playfield.Player) <= DetectRadius)
                {
                    Playfield.Player.Health--;
                    Playfield.RemoveObject(this);
                }
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop na een mooie explosie
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
            if (!fieldRemoved)
            {
                Playfield.AddObject(new SpriteExplosion(75, 75, X, Y));
                SoundEffects.PlaySound(Resources.bomb);
            }
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