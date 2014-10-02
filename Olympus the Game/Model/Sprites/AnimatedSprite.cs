﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public abstract class AnimatedSprite : GameObject
    {
        protected int duration;
        protected int start;

        public override float Frame
        {
            get
            {
                return (float)(Environment.TickCount - start) / (float)duration;
            }
            set { }
        }

        public AnimatedSprite(int width, int height, int x, int y)
            : base(width, height, x, y)
        {
            IsSolid = false;
            start = Environment.TickCount;
        }
    }
}
