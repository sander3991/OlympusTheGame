using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    class SpriteExplosion : AnimatedSprite
    {
        /// <summary>
        /// Up-scaling factor of this explosion.
        /// </summary>
        private const float EXPLOSION_SCALE = 2.0f;

        /// <summary>
        /// Create a new SpriteExplosion, with the same location as the entity.
        /// </summary>
        /// <param name="entity"></param>
        public SpriteExplosion(GameObject entity)
            : base((int)((float)entity.Width * EXPLOSION_SCALE),
            (int)((float)entity.Height * EXPLOSION_SCALE), 
            entity.X - (int)((float)entity.Width * (EXPLOSION_SCALE - 1.0f)) / 2 , 
            entity.Y - (int)((float)entity.Height * (EXPLOSION_SCALE - 1.0f)) / 2 )
        //TODO Ruben : Entity standaard 1.5/2 keer zo groot maken
        public SpriteExplosion(int width, int height, int x, int y) : base(width, height, x, y)
        {
            Type = ObjectType.SPRITEEXPLOSION;
            duration = 1000;
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
        }

        /// <summary>
        /// Update this explosion.
        /// </summary>
        public SpriteExplosion(GameObject entity) : this(entity.Width, entity.Height, entity.X, entity.Y){ }

        public void OnUpdate()
        {
            // If explosion is over, remove from PlayField.
            if ((Environment.TickCount - start) > duration)
            {
                OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
                OlympusTheGame.INSTANCE.Playfield.RemoveObject(this);
            }
        }
    }
}
