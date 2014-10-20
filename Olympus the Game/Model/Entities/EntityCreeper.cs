using Olympus_the_Game.Controller;
using Olympus_the_Game.Model.Sprites;
using Olympus_the_Game.Properties;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityCreeper : EntityExplode
    {

        private int prop_creeperrange;
        
        [EditorTooltip("Volg afstand", "Vanaf welke afstand gaat de creeper de speler volgen.")]
        public int CreeperRange
        {
            get
            {
                return prop_creeperrange;
            }
            set
            {
                if (value > 0)
                    prop_creeperrange = value;
            }
        }
        static EntityCreeper()
        {
            RegisterWithEditor(ObjectType.Creeper, () => new EntityCreeper(50, 50, 0, 0, 1));
                // TODO Maak waarden standaard
        }

        /// <summary>
        /// Een Creeper object met een beginsnelheid
        /// </summary>
        public EntityCreeper(int width, int height, int x, int y, int dx, int dy, int explodeStrength)
            : base(width, height, x, y, dx, dy, explodeStrength)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            EntityControlledByAi = true;
            Type = ObjectType.Creeper;
        }

        /// <summary>
        /// Een creeper object die stil staat op het begin
        /// </summary>
        public EntityCreeper(int width, int height, int x, int y, int explodeStrength)
            : this(width, height, x, y, 0, 0, explodeStrength)
        {
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Volgt je en explodeert bij aanraken";
        }

        /// <summary>
        /// Update het object.
        /// Wanneer dit object te dichtbij een speler is zal deze richting de speler lopen.
        /// </summary>
        public void OnUpdate()
        {
            EntityPlayer player = Playfield.Player;
            if (player != null)
            {
                if (DistanceToObject(player) < CreeperRange)
                {
                    EntityControlledByAi = false;

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


                    /**
                     *Als de X of Y waarde van de speler of het object gelijk is zal het object in een rechte lijn achter de speler aan lopen.
                    **/
                    if (X == player.X)
                    {
                        DX = 0;
                    }

                    if (Y == player.Y)
                    {
                        DY = 0;
                    }
                }
                else
                {
                    EntityControlledByAi = true;
                }
            }
        }

        public override string ToString()
        {
            return "Creeper";
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            GameController contr = OlympusTheGame.GameController;
            PlayField pf = Playfield;
            contr.UpdateGameEvents -= OnUpdate;
            if (!fieldRemoved)
            {
                pf.AddObject(new SpriteExplosion(this));
                SoundEffects.PlaySound(Resources.bomb);
            }
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
        }
    }
}