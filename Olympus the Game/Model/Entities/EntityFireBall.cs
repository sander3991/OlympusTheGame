using System;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model.Sprites;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityFireBall : Entity
    {
        private readonly EntityGhast _owner;
        private int _propFireballspeed = 50; // Factor van maken
        /// <summary>
        /// Vuursnelheid van de ghast. MIN = 0, DEFAULT = 40
        /// </summary>
        public int FireballSpeed
        {
            get { return _propFireballspeed; }
            set
            {
                _propFireballspeed = Math.Max(0, value);
            }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Vuurbal van Ghast";
        }

        /// <summary>
        /// FILL THIS IN
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
            DX = -(((this.X - target.X) - 25) / FireballSpeed);
            DY = -(((this.Y - target.Y) - 25) / FireballSpeed);

            EntityControlledByAi = false;
            Type = ObjectType.FIREBALL;
            IsSolid = false;
            this._owner = owner;
        }
        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityFireBall(int width, int height, int x, int y, EntityGhast owner, GameObject target) : this(width, height, x, y, 0, 0, owner, target) { }

        public override CollisionType CollidesWithObject(GameObject entity)
        {
            if (entity == _owner)
                return CollisionType.NONE;
            AnimatedSprite sprite = entity as AnimatedSprite;
            return sprite != null ? CollisionType.NONE : base.CollidesWithObject(entity);
        }

        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Verwijderd de fireball als het de randen van het spel raakt
                if (this.X + DX < 0 || this.X + DX + Width > Playfield.Width || this.Y + DY < 0 || this.Y + DY + Height > Playfield.Height)
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
            else if (gameObject.Type == ObjectType.Player)
            {
                Playfield.Player.Health--;
                Playfield.RemoveObject(this);
            }
            else
            {
                Playfield.RemoveObject(this);
                Entity e = gameObject as Entity;
                // Verwijder het object waar het mee in aanraking is gekomen. Onder voorwaarde dat het een entity is
                if (e != null)
                {
                    Playfield.RemoveObject(gameObject);
                    switch (e.Type)
                    {
                        case ObjectType.SLOWER:
                            Scoreboard.AddScore(ScoreType.Slower);
                            break;
                        case ObjectType.TIMEBOMB:
                        case ObjectType.EXPLODE:
                            Scoreboard.AddScore(ScoreType.Explode);
                            break;
                        case ObjectType.CREEPER:
                            Scoreboard.AddScore(ScoreType.Creeper);
                            break;
                        case ObjectType.GHAST:
                            Scoreboard.AddScore(ScoreType.Ghast);
                            break;
                        default:
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
                SoundEffects.PlaySound(Properties.Resources.bomb);
            }
        }

        public override string ToString()
        {
            return "Fireball";
        }
    }
}
