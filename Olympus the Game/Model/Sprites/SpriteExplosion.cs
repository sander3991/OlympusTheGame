using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    class SpriteExplosion : AnimatedSprite
    {
        public SpriteExplosion(GameObject entity) : base(entity.Width, entity.Height, entity.X, entity.Y)
        {
            Type = ObjectType.SPRITEEXPLOSION;
            duration = 1000;
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
        }

        public void OnUpdate()
        {
            if((Environment.TickCount - start) > duration)
            {
                OlympusTheGame.INSTANCE.Playfield.RemoveObject(this);
                OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
            }
        }
    }
}
