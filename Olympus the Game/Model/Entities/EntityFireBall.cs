using System;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model.Sprites;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityFireBall : Entity
    {
        private readonly EntityGhast _owner;
        private int _propFireballspeed = 50; // Factor van maken

        /// <summary>
        ///     FILL THIS IN
        /// </summary>
        public EntityFireBall(int width, int height, int x, int y, int dx, int dy, EntityGhast owner, GameObject target)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            if (target == null || owner == null)
            {
                throw (new ArgumentException("Een entity heeft altijd een target/owner nodig!"));
            }
            // Bepaald de verandering in de x en y van de vuurbal (de snelheid)
            DX = -(((X - target.X) - 25)/FireballSpeed);
            DY = -(((Y - target.Y) - 25)/FireballSpeed);

            EntityControlledByAi = false;
            Type = ObjectType.Fireball;
            IsSolid = false;
            _owner = owner;
        }

        /// <summary>
        ///     FILL THIS IN
        /// </summary>
        public EntityFireBall(int width, int height, int x, int y, EntityGhast owner, GameObject target)
            : this(width, height, x, y, 0, 0, owner, target)
        {
        }

        /// <summary>
        ///     Vuursnelheid van de ghast. MIN = 0, DEFAULT = 40
        /// </summary>
        public int FireballSpeed
        {
            get { return _propFireballspeed; }
            set { _propFireballspeed = Math.Max(0, value); }
        }

        /// <summary>
        ///     Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Vuurbal van Ghast";
        }

        public override CollisionType CollidesWithObject(GameObject entity)
        {
            if (entity == _owner)
                return CollisionType.None;
            var sprite = entity as AnimatedSprite;
            return sprite != null ? CollisionType.None : base.CollidesWithObject(entity);
        }

        private void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Verwijderd de fireball als het de randen van het spel raakt
                if (X + DX < 0 || X + DX + Width > Playfield.Width || Y + DY < 0 || Y + DY + Height > Playfield.Height)
                    Playfield.RemoveObject(this);
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            // Ontplof niet wanneer het object collide met de eigenaar van de vuurbal of met een andere vuurbal
            if (gameObject == _owner) // removed:  || gameObject.Type == ObjectType.FIREBALL
            {
                return;
            }
            // Ontplof wanneer het de speler raakt (en verwijder het object meteen van het speelveld)
            if (gameObject.Type == ObjectType.Player)
            {
                Playfield.Player.Health--;
                Playfield.RemoveObject(this);
            }
            else
            {
                Playfield.RemoveObject(this);
                var e = gameObject as Entity;
                // Verwijder het object waar het mee in aanraking is gekomen. Onder voorwaarde dat het een entity is
                if (e != null)
                {
                    Playfield.RemoveObject(gameObject);
                    switch (e.Type)
                    {
                        case ObjectType.Slower:
                            Scoreboard.AddScore(ScoreType.Slower);
                            break;
                        case ObjectType.Timebomb:
                        case ObjectType.Explode:
                            Scoreboard.AddScore(ScoreType.Explode);
                            break;
                        case ObjectType.Creeper:
                            Scoreboard.AddScore(ScoreType.Creeper);
                            break;
                        case ObjectType.Ghast:
                            Scoreboard.AddScore(ScoreType.Ghast);
                            break;
                        case ObjectType.Silverfish:
                            Scoreboard.AddScore(ScoreType.Silverfish);
                            break;
                    }
                }
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop met een mooie explosie
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
            if (!fieldRemoved)
            {
                Playfield.AddObject(new SpriteExplosion(this));
                SoundEffects.PlaySound(Resources.bomb);
            }
        }

        public override string ToString()
        {
            return "Fireball";
        }
    }
}