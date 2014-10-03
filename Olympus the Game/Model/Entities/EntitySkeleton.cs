using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntitySkeleton : Entity
    {
        public EntitySkeleton(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.SKELETON;
            IsSolid = true;
            EntityControlledByAI = true;
        }
        public EntitySkeleton(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            // soon to be implemented
        }

        public override string ToString()
        {
            return "Skeleton";
        }
    }
}
