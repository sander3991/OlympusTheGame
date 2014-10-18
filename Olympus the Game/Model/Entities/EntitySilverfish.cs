using System.Diagnostics;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    //TODO: Deze entity inbouwen
    public class EntitySilverfish : Entity
    {
        private bool HasHitPlayer;
        private static Stopwatch stopwatch;
        private int prop_removetime = 3000;
        [EditorTooltip("TODO JOEL - NAAM", "TODO JOEL OMSCHRIJVING")]
        public int RemoveTime {
            get { return prop_removetime; }
        }

        private int _propSpotRange;
        public int SpotRange {
            get {
                return _propSpotRange;
            }
            set {
                if(value >= 0)
                    _propSpotRange = value;
            }
        }
        private int _propAggroRange;

        [EditorTooltip("Detectie afstand", "Hoe dichtbij moet een speler zijn om de silverfish te laten verschijnen.")]
        public int AggroRange {
            get {
                return _propAggroRange;
            }
            set {
                if(value >= 0)
                    _propAggroRange = value;
            }
        }
        
        static EntitySilverfish()
        {
            RegisterWithEditor(ObjectType.Silverfish, () => new EntitySilverfish(50,50,0,0));
        }

        public EntitySilverfish(int width, int height, int x, int y, int dx = 0, int dy = 0)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            EntityControlledByAi = false;
            Type = ObjectType.Silverfish;
            Visible = false;
            SpotRange = 150;
            AggroRange = 100;
        }

        public void OnUpdate() {
            EntityPlayer player = Playfield.Player;
            if(player != null){
                if(DistanceToObject(player) < SpotRange) {
                    // Komt tevoorschijn
                    Visible = true;
                    if(DistanceToObject(player) < AggroRange){
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

                    if(DistanceToObject(player) > AggroRange) {
                        DX = 0;
                        DY = 0;
                        Visible = false;
                    }

                    if(HasHitPlayer) {
                        if(stopwatch.ElapsedMilliseconds >= RemoveTime) {
                            HasHitPlayer = false;
                        }
                    }
                }
            }

            // Komt tevoorschijn als je minder dan 75 pixels dichtbij bent
            // Valt je aan als je 50 pixels dichtbij bent
            // Loopt weer terug na de aanval en wacht tot je weer 50 pixels in de buurt bent
        }

        public override void OnCollide(GameObject gameObject) {
            EntityPlayer player = gameObject as EntityPlayer;
            PlayField pf = Playfield;
            if(player != null) {
                if(!HasHitPlayer) {
                    Playfield.Player.Health--;
                    HasHitPlayer = true;
                    stopwatch = Stopwatch.StartNew();
                }
            }
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