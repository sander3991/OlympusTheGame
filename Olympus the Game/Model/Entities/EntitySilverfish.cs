using System.Diagnostics;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    /// <summary>
    /// Silverfish entity
    /// </summary>
    public class EntitySilverfish : Entity
    {
        private static Stopwatch stopwatch;
        private bool HasHitPlayer;
        private int _propAggroRange;
        private int _propSpotRange;
        private int prop_removetime = 3000;

        static EntitySilverfish()
        {
            RegisterWithEditor(ObjectType.Silverfish, () => new EntitySilverfish(50, 50, 0, 0));
        }

        /// <summary>
        /// Een silverfish die zichtbaar word zodra de speler in een configureerbare radius loopt
        /// </summary>
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

        [ExcludeFromEditor]
        public int RemoveTime
        {
            get { return prop_removetime; }
            set { if (value >= 0) prop_removetime = value; }
        }

        [EditorTooltip("Spot afstand", "Op welke afstand spot de silverfish de speler.")]
        public int SpotRange
        {
            get { return _propSpotRange; }
            set
            {
                if (value >= 0)
                    _propSpotRange = value;
            }
        }

        [EditorTooltip("Detectie afstand", "Hoe dichtbij moet een speler zijn om de silverfish te laten verschijnen.")]
        public int AggroRange
        {
            get { return _propAggroRange; }
            set
            {
                if (value >= 0)
                    _propAggroRange = value;
            }
        }

        public void OnUpdate() {
            EntityPlayer player = Playfield.Player;
            if(player != null){
                if(DistanceToObject(player) < SpotRange) {
                    // Komt tevoorschijn
                    Visible = true;
                    if (DistanceToObject(player) < AggroRange)
                    {
                        if (X - player.X > 0)
                        {
                            DX = -1;
                        }
                        else
                        {
                            DX = 1;
                        }

                        if (Y - player.Y > 0)
                        {
                            DY = -1;
                        }
                        else
                        {
                            DY = 1;
                        }

                        if (X == player.X)
                        {
                            DX = 0;
                        }

                        if (Y == player.Y)
                        {
                            DY = 0;
                        }
                    }

                    if(DistanceToObject(player) > AggroRange) {
                        DX = 0;
                        DY = 0;
                        Visible = false;
                    }

                    if (HasHitPlayer)
                    {
                        if (stopwatch.ElapsedMilliseconds >= RemoveTime)
                        {
                            HasHitPlayer = false;
                        }
                    }
                }
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            var player = gameObject as EntityPlayer;
            if (player != null)
            {
                if (!HasHitPlayer)
                {
                    Playfield.Player.Health--;
                    HasHitPlayer = true;
                    stopwatch = Stopwatch.StartNew();
                }
            }
        }

        /// <summary>
        ///     Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Is onzichtbaar tot je te dichtbij bent.";
        }

        /// <summary>
        /// Naam van de entity
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Silverfish";
        }

        /// <summary>
        /// Wat er gebeurd wanneer de entity verwijderd wordt
        /// </summary>
        /// <param name="fieldRemoved"></param>
        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
        }
    }
}