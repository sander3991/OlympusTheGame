using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityArrow : Entity
    {
        int destinyX;
        int destinyY;
        int i;
        int j;
        double distance;
        bool targetFound = false;
        bool targetHit = false;

        public EntityArrow(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = false;
            Type = ObjectType.ARROW;
            IsSolid = false;
        }
        public EntityArrow(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            if (player != null)
            {
                if (!targetFound)
                {
                    destinyX = player.X;
                    destinyY = player.Y;
                    distance = DistanceToObject(player);
                    //stapjes per verandering bepalen in de x- en y-as
                    i = -((this.X - destinyX) / 50);
                    j = -((this.Y - destinyY) / 50);
                    targetFound = true;
                }
                // Haal de arrow uit het scherm als hij de randen raakt
                if (this.X <= 0 || this.Y <= 0 || this.X >= 978 || this.Y >= 489)
                    OnRemoved();

                this.X = this.X + i;
                this.Y = this.Y + j;
            }
        }
        public override void OnRemoved()
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }
    }
}
