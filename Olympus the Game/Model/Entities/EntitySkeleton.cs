using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntitySkeleton : Entity
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        EntityArrow arrow;
        public EntitySkeleton(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.SKELETON;
            IsSolid = true;
            EntityControlledByAI = false;
        }
        public EntitySkeleton(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            if (player != null)
            {
                if (DistanceToObject(player) < 500)
                {
                    if (stopwatch.IsRunning == false)
                    {
                        stopwatch.Start();
                    }
                    if (stopwatch.ElapsedMilliseconds >= 5000)
                    {
                        if(arrow != null)arrow.OnRemoved();
                        arrow = new EntityArrow(50, 50, this.X, this.Y, 0, 0);
                        OlympusTheGame.INSTANCE.Playfield.AddObject(arrow);
                        stopwatch.Restart();
                    }
                }
                else
                    this.EntityControlledByAI = true;
            }
        }

        public override string ToString()
        {
            return "Skeleton";
        }
    }
}
