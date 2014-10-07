using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    //TODO: Deze entity inbouwen
    public class EntitySilverfish : Entity
    {
        public EntitySilverfish(int width, int height, int x, int y, int dx, int dy) : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = false;
            Type = ObjectType.SILVERFISH;
        }

        public EntitySilverfish(int width, int height, int x, int y, double explodeStrength) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate() {
            // Komt tevoorschijn als je minder dan 75 pixels dichtbij bent
            // Valt je aan als je 50 pixels dichtbij bent
            // Loopt weer terug na de aanval en wacht tot je weer 50 pixels in de buurt bent
        }

        public override void OnCollide(GameObject gameObject) {

        }

        public override string ToString()
        {
            return "Silverfish";
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.Controller.UpdateGameEvents -= OnUpdate;
        }
    }
    }

