using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model
{
    public class ObjectObstacle : GameObject
    {
        static ObjectObstacle()
        {
            new ObjectObstacle(50, 50, 0, 0).RegisterWithEditor(ObjectType.Obstacle);
        }

        /// <summary>
        /// Initialiseert een obstakel object waar de speler niet doorheen kan.
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public ObjectObstacle(int width, int height, int x, int y)
            : base(width, height, x, y)
        {
            Type = ObjectType.Obstacle;
        }

        public override string ToString()
        {
            return "Obstacle";
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Een niet doorgaanbaar obstakel";
        }
    }
}