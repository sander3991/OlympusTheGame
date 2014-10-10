using System;
using Olympus_the_Game.Model.Entities;

namespace Olympus_the_Game.Model
{
    public class ObjectFinish : GameObject
    {
        static ObjectFinish()
        {
            RegisterWithEditor(ObjectType.FINISH, () => { return new ObjectFinish(50, 50, 0, 0); });
        }

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

        public override void OnCollide(GameObject gameObject)
        {
            EntityPlayer player = gameObject as EntityPlayer;
            if (player != null && player.X > X && player.Y > Y)
            {
                int xDistance = Math.Abs((X + Width/2) - (player.X + player.Width/2));
                int yDistance = Math.Abs((Y + Height/2) - (player.Y + player.Height/2));
                if (xDistance < 5 && yDistance < 5)
                    OlympusTheGame.GameController.OnPlayerReachedCake();
            }
        }

        public override string ToString()
        {
            return "Finish";
        }

        //TODO ??: OnCollide om te detecteren dat we gewonnen hebben!
    }
}