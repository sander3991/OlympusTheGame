using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    class SpriteExplosion : AnimatedSprite
    {
        public override float Frame
        {
            get
            {
                return (float)(Environment.TickCount - start) / (float)duration;
            }
            set { }
        }
        public SpriteExplosion(GameObject entity) : base(entity.Width, entity.Height, entity.X, entity.Y)
        {
            Type = ObjectType.SPRITEEXPLOSION;
            duration = 1000;
        }
    }
}
