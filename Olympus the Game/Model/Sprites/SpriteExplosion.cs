namespace Olympus_the_Game.Model.Sprites
{
    internal class SpriteExplosion : AnimatedSprite
    {
        /// <summary>
        ///     Up-scaling factor of this explosion.
        /// </summary>
        private const float ExplosionScale = 2.0f;

        /// <summary>
        ///     Create a new SpriteExplosion, with the same location as the entity.
        /// </summary>
        /// <param name="entity"></param>
        public SpriteExplosion(GameObject entity) : this(entity.Width, entity.Height, entity.X, entity.Y)
        {
        }

        public SpriteExplosion(int width, int height, int x, int y)
            : base((int) (width*ExplosionScale),
                (int) (height*ExplosionScale),
                x - (int) (width*(ExplosionScale - 1.0f))/2,
                y - (int) (height*(ExplosionScale - 1.0f))/2)
        {
            Type = ObjectType.Spriteexplosion;
            Duration = 1000;
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
        }

        /// <summary>
        ///     Update this explosion.
        /// </summary>
        /// s
        public void OnUpdate()
        {
            // If explosion is over, remove from PlayField.
            if ((OlympusTheGame.GameTime - Start) > Duration)
            {
                OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
                OlympusTheGame.Playfield.RemoveObject(this);
            }
        }
    }
}