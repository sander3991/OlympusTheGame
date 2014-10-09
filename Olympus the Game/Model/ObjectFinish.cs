using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class ObjectFinish : GameObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public ObjectFinish(int width, int height, int x, int y)
            : base(width, height, x, y)
        {
            IsSolid = false;
            Type = ObjectType.FINISH;
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "De finish van het level";
        }

        /// <summary>
        /// Lege constructor
        /// </summary>
        public ObjectFinish() : this(0, 0, 0, 0) { }



        public override void OnCollide(GameObject gameObject)
        {
            EntityPlayer player = gameObject as EntityPlayer;
            if (player != null && player.X > X && player.Y > Y)
            {
                int xDistance = Math.Abs((X + Width / 2) - (player.X + player.Width / 2));
                int yDistance = Math.Abs((Y + Height / 2) - (player.Y + player.Height / 2));
                if (xDistance < 5 && yDistance < 5)
                    OlympusTheGame.Controller.OnPlayerReachedCake();
            }
        }

        public override string ToString()
        {
            return "Finish";
        }

        //TODO ??: OnCollide om te detecteren dat we gewonnen hebben!
    }
}
