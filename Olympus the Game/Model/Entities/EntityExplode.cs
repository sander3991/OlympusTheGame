using System;
namespace Olympus_the_Game
{
    public class EntityExplode : Entity
    {

        static EntityExplode()
        {
            RegisterWithEditor(ObjectType.EXPLODE, () => { return new EntityExplode(50, 50, 0, 0, 1f); }); // TODO Maak waarden standaard
        }

        /// <summary>
        /// De sterkte van het exploderende object
        /// </summary>
        public double EffectStrength { get; set; }

        /// <summary>
        /// Initialiseert een exploderend object dat explodeert als spelers daarmee in contact komen, hij beweegt gelijk na initialisatie
        /// </summary>
        public EntityExplode(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy)
        {
            EffectStrength = Math.Max(0, effectStrength);
            EntityControlledByAI = false;
            Type = ObjectType.EXPLODE;
        }
        /// <summary>
        /// Initialiseert een exploderend object dat explodeert als spelers daarmee in contact komen, hij beweegt niet na initialisatie
        /// </summary>
        public EntityExplode(int width, int height, int x, int y, double effectStrength) : this(width, height, x, y, 0, 0, effectStrength) { }

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
            Controller contr = OlympusTheGame.Controller;
            PlayField pf = OlympusTheGame.Playfield;
            if (!fieldRemoved)
            {
                pf.AddObject(new SpriteExplosion(this));
                SoundEffects.PlaySound(Properties.Resources.bomb);
            }
        }

        public override string ToString()
        {
            return "Explode";
        }
    }
}
