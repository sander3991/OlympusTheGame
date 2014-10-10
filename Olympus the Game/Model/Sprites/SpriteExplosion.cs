namespace Olympus_the_Game.Model.Sprites
{
    class SpriteExplosion : AnimatedSprite
    {
        /// <summary>
        /// Up-scaling factor of this explosion.
        /// </summary>
        private const float EXPLOSION_SCALE = 2.0f;

        /// <summary>
        /// Create a new SpriteExplosion, with the same location as the entity.
        /// </summary>
        /// <param name="entity"></param>
        public SpriteExplosion(GameObject entity) : this(entity.Width, entity.Height, entity.X, entity.Y) { }

        public SpriteExplosion(int width, int height, int x, int y)
            : base((int)((float)width * EXPLOSION_SCALE),
                (int)((float)height * EXPLOSION_SCALE),
                x - (int)((float)width * (EXPLOSION_SCALE - 1.0f)) / 2,
                y - (int)((float)height * (EXPLOSION_SCALE - 1.0f)) / 2)
        {
            Type = ObjectType.SPRITEEXPLOSION;
            duration = 1000;
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
        }

        /// <summary>
        /// Update this explosion.
        /// </summary>s
        public void OnUpdate()
        {
            // If explosion is over, remove from PlayField.
            if ((OlympusTheGame.GameTime - start) > duration)
            {
                OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
                OlympusTheGame.Playfield.RemoveObject(this);
            }
        }
    }
}
