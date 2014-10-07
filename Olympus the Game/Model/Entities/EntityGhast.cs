using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntityGhast : Entity
    {
        private Stopwatch stopwatch = Stopwatch.StartNew();
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
        /// FILL THIS IN
        /// </summary>
        public EntityGhast(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.Controller.UpdateGameEvents += OnUpdate;
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
                if (DistanceToObject(Playfield.Player) <= prop_detectrange)
                {
                    // Vuur dan een vuurbal af om de x aantal seconden
                    if (stopwatch.ElapsedMilliseconds >= prop_firespeed)
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
            OlympusTheGame.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Ghast";
        }
    }
}
