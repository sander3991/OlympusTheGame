using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntitySilverfish : Entity
    {
        public EntitySilverfish(int width, int height, int x, int y, int dx, int dy, double explodeStrength) : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = false;
            Type = ObjectType.SILVERFISH;
        }

        public EntitySilverfish(int width, int height, int x, int y, double explodeStrength) : this(width, height, x, y, 0, 0, explodeStrength) { }

        public void OnUpdate() {
            
        }

        public override void OnCollide(GameObject gameObject) {

        }

        public override string ToString()
        {
            return "Silverfish";
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }
    }
    }

