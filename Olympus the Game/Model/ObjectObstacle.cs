namespace Olympus_the_Game
{
    public class ObjectObstacle : GameObject
    {

        static ObjectObstacle()
        {
            RegisterWithEditor(ObjectType.OBSTACLE, () => { return new ObjectObstacle(50, 50, 0, 0); });
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
            Type = ObjectType.OBSTACLE;
        }

        public override string ToString()
        {
            return "Obstacle";
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Een niet doorgaanbaar obstakel";
        }
    }
}
