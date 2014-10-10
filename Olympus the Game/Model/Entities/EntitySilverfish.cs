namespace Olympus_the_Game.Model.Entities
{
    //TODO: Deze entity inbouwen
    public class EntitySilverfish : Entity
    {
        public EntitySilverfish(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            EntityControlledByAi = false;
            Type = ObjectType.Silverfish;
        }

        public EntitySilverfish(int width, int height, int x, int y) : this(width, height, x, y, 0, 0)
        {
        }

        public void OnUpdate()
        {
            // Komt tevoorschijn als je minder dan 75 pixels dichtbij bent
            // Valt je aan als je 50 pixels dichtbij bent
            // Loopt weer terug na de aanval en wacht tot je weer 50 pixels in de buurt bent
        }

        public override void OnCollide(GameObject gameObject)
        {
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Silverfish - coming soon";
        }


        public override string ToString()
        {
            return "Silverfish";
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
        }
    }
}