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

        public EntitySkeleton(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.SKELETON;
            EntityControlledByAI = true;
            IsSolid = true;
        }

        public EntitySkeleton(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            //todo: arrow mee laten bewegen
            //todo: vierkant om arrow weghalen
            //todo: arrow's automatisch laten verwijderen

            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            if (player != null)
            {
                if (DistanceToObject(player) < 300)
                {
                    //Maak een nieuwe pijl aan wanneer er 3 seconden verstreken zijn
                    if (stopwatch.ElapsedMilliseconds >= 3000)
                    {
                        EntityArrow arrow = new EntityArrow(50, 50, this.X, this.Y, 0, 0);
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
