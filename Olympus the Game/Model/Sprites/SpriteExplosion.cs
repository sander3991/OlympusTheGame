using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    // TODO Ruben: commentaar
    class SpriteExplosion : AnimatedSprite
    {
        //TODO Ruben : Entity standaard 1.5/2 keer zo groot maken
        public SpriteExplosion(int width, int height, int x, int y) : base(width, height, x, y)
        {
            Type = ObjectType.SPRITEEXPLOSION;
            duration = 1000;
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
        }

        public SpriteExplosion(GameObject entity) : this(entity.Width, entity.Height, entity.X, entity.Y){ }

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
