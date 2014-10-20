using System;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model.Sprites;
using Olympus_the_Game.Properties;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityExplode : Entity
    {
        static EntityExplode()
        {
            RegisterWithEditor(ObjectType.Explode, () => new EntityExplode(50, 50, 0, 0, 1f));
                // TODO Maak waarden standaard
        }

        /// <summary>
        /// Initialiseert een exploderend object dat explodeert als spelers daarmee in contact komen, hij beweegt gelijk na initialisatie
        /// </summary>
        public EntityExplode(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy)
        {
            EffectStrength = Math.Max(0, effectStrength);
            EntityControlledByAi = false;
            Type = ObjectType.Explode;
        }

        /// <summary>
        /// Initialiseert een exploderend object dat explodeert als spelers daarmee in contact komen, hij beweegt niet na initialisatie
        /// </summary>
        public EntityExplode(int width, int height, int x, int y, double effectStrength)
            : this(width, height, x, y, 0, 0, effectStrength)
        {
        }

        /// <summary>
        /// De sterkte van het exploderende object
        /// </summary>
        [EditorTooltip("Explosie sterkte", "Hoe sterk is de explosie in aantal healthpunten.")]
        public double EffectStrength { get; set; }

        public override void OnCollide(GameObject gameObject)
        {
            EntityPlayer player = gameObject as EntityPlayer;
            PlayField pf = Playfield;
            if (player != null)
            {
                player.Health -= Convert.ToInt32(EffectStrength);
                pf.RemoveObject(this);
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            PlayField pf = OlympusTheGame.Playfield;
            if (!fieldRemoved)
            {
                pf.AddObject(new SpriteExplosion(this));
                SoundEffects.PlaySound(Resources.bomb);
            }
        }

        public override string ToString()
        {
            return "Explode";
        }
    }
}