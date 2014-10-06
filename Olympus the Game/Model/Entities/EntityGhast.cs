using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Olympus_the_Game
{
    //TODO Elmar: Commentaar
    public class EntityGhast : Entity
    {
        Stopwatch stopwatch = Stopwatch.StartNew(); //TODO Elmar: Access modifier toevoegen (private/public)
        //TODO Elmar: Kan dit niet een prop zijn? Zorgt gelijk voor limitaties!
        public int firespeed = 1000, detectRange = 250; //Aanpasbaar in editor

        public EntityGhast(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.GHAST;
            EntityControlledByAI = true;
            IsSolid = false;
        }

        public EntityGhast(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player; //TODO Elmar: Gebruik interne PlayField
            if (player != null)
            {
                if (DistanceToObject(player) < detectRange)
                {
                    //Maak een nieuwe fireball aan wanneer er 3 seconden verstreken zijn
                    if (stopwatch.ElapsedMilliseconds >= firespeed)
                    {
                        EntityFireBall arrow = new EntityFireBall(25, 25, this.X, this.Y, 0, 0); //TODO Elmar: Naam veranderen, is duidelijker.
                        Playfield.AddObject(arrow);
                        stopwatch.Restart();
                    }
                }
                else
                    this.EntityControlledByAI = true;
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }
        public override string ToString()
        {
            return "Ghast";
        }
    }
}
