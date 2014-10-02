using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    class SpriteExplosion : AnimatedSprite
    {
        private static int frameCount = 25;
        public override int FrameID
        {
            get
            {
                return frameCount * (Environment.TickCount - start) / duration;
            }
            set { }
        }
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
