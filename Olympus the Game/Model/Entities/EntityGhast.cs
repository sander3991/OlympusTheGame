using System;
using System.Diagnostics;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityGhast : Entity
    {
        static EntityGhast()
        {
            RegisterWithEditor(ObjectType.GHAST, () => { return new EntityGhast(50, 50, 0, 0); }); // TODO Maak waarden standaard
        }

        private readonly Stopwatch stopwatch = Stopwatch.StartNew();
        private int prop_firespeed = 1050;
        private int prop_detectrange = 150;
        /// <summary>
        /// Vuursnelheid van de ghast. MIN = 0, DEFAULT = 1000
        /// </summary>
        public int FireSpeed
        {
            get { return prop_firespeed; }
            set
            {
                prop_firespeed = Math.Max(0, value);
            }
        }
        /// <summary>
        /// Afstand van wanneer de Ghast begint met aanvallen. MIN = 50, DEFAULT = 150
        /// </summary>
        public int DetectRange
        {
            get { return prop_detectrange; }
            set
            {
                prop_detectrange = Math.Max(50, value);
            }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Ghast schiet vuurballen";
        }

        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityGhast(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            Type = ObjectType.GHAST;
            EntityControlledByAI = true;
        }

        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityGhast(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Wanneer de speler in de buurt van dit object komt:
                if (DistanceToObject(Playfield.Player) <= DetectRange)
                {
                    // Vuur dan een vuurbal af om de x aantal seconden
                    if (stopwatch.ElapsedMilliseconds >= FireSpeed)
                    {
                        EntityFireBall fireball = new EntityFireBall(25, 25, this.X, this.Y, 0, 0, this, Playfield.Player);
                        Playfield.AddObject(fireball);
                        stopwatch.Restart();
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
