using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public abstract class AnimatedSprite : GameObject
    {
        /// <summary>
        /// Sprites mogen altijd overal zijn omdat de animatie deels buiten beeld mag zijn
        /// </summary>
        public override int X { get; set; }
        /// <summary>
        /// Sprites mogen altijd overal zijn omdat de animatie deels buiten beeld mag zijn
        /// </summary>
        public override int Y { get; set; }
        /// <summary>
        /// Hoe lang deze animatie duurt in milliseconden.
        /// </summary>
        protected int duration;

        /// <summary>
        /// Wanneer deze animatie is gestart, op een schaal van milliseconden.
        /// </summary>
        protected long start;

        /// <summary>
        /// Het hoeveelste frame deze animatie zit. Tussen 0.0f en 1.0f als deze nog draait. Hoger als de animatie voorbij is (of cyclisch is).
        /// </summary>
        public override float Frame
        {
            get
            {
                return (float)(OlympusTheGame.GameTime - start) / (float)duration;
            }
            protected set { }
        }

        /// <summary>
        /// Maak een nieuw AnimatedSprite aan.
        /// </summary>
        /// <param name="width">Breedte</param>
        /// <param name="height">Hoogte</param>
        /// <param name="x">X-coordinaat</param>
        /// <param name="y">Y-coordinaat</param>
        protected AnimatedSprite(int width, int height, int x, int y)
            : base(width, height, x, y)
        {
            IsSolid = false;
            start = OlympusTheGame.GameTime;
        }

        public override CollisionType CollidesWithObject(GameObject entity)
        {
            return CollisionType.NONE;
        }
    }
}
