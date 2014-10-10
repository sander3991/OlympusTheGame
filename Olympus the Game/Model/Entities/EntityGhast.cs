using System;
using System.Diagnostics;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityGhast : Entity
    {
        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
        private int _propDetectrange = 150;
        private int _propFirespeed = 1050;

        static EntityGhast()
        {
            RegisterWithEditor(ObjectType.GHAST, () => { return new EntityGhast(50, 50, 0, 0); });
                // TODO Maak waarden standaard
        }

        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityGhast(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            Type = ObjectType.GHAST;
            EntityControlledByAi = true;
        }

        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityGhast(int width, int height, int x, int y) : this(width, height, x, y, 0, 0)
        {
        }

        /// <summary>
        /// Vuursnelheid van de ghast. MIN = 0, DEFAULT = 1000
        /// </summary>
        public int FireSpeed
        {
            get { return _propFirespeed; }
            set { _propFirespeed = Math.Max(0, value); }
        }

        /// <summary>
        /// Afstand van wanneer de Ghast begint met aanvallen. MIN = 50, DEFAULT = 150
        /// </summary>
        public int DetectRange
        {
            get { return _propDetectrange; }
            set { _propDetectrange = Math.Max(50, value); }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Ghast schiet vuurballen";
        }

        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Wanneer de speler in de buurt van dit object komt:
                if (DistanceToObject(Playfield.Player) <= DetectRange)
                {
                    // Vuur dan een vuurbal af om de x aantal seconden
                    if (_stopwatch.ElapsedMilliseconds >= FireSpeed)
                    {
                        EntityFireBall fireball = new EntityFireBall(25, 25, X, Y, 0, 0, this, Playfield.Player);
                        Playfield.AddObject(fireball);
                        _stopwatch.Restart();
                    }
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
            return "Ghast";
        }
    }
}