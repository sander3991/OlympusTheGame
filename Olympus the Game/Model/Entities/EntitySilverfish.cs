namespace Olympus_the_Game.Model.Entities
{
    //TODO: Deze entity inbouwen
    public class EntitySilverfish : Entity
    {
        private int SpotRange = 75;
        private int AggroRange = 50;

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

        public void OnUpdate() {
            EntityPlayer player = Playfield.Player;
            if(player != null){
                if(DistanceToObject(player) < SpotRange){
                    // Komt tevoorschijn
                    if(DistanceToObject(player) < AggroRange){
                        EntityControlledByAi = false;

                        if(X - player.X > 0) {
                            DX = -1;
                        } else {
                            DX = 1;
                        }

                        if(Y - player.Y > 0) {
                            DY = -1;
                        } else {
                            DY = 1;
                        }

                        if(X == player.X) {
                            DX = 0;
                        }

                        if(Y == player.Y) {
                            DY = 0;
                        }
                    }
                } else {
                    EntityControlledByAi = false;
                }
            }

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