using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityFireBall : Entity
    {
        private EntityGhast owner;
        private int prop_fireballspeed = 50; // Factor van maken
        /// <summary>
        /// Vuursnelheid van de ghast. MIN = 0, DEFAULT = 40
        /// </summary>
        public int FireballSpeed
        {
            get { return prop_fireballspeed; }
            set
            {
                prop_fireballspeed = Math.Max(0, value);
            }
        }

        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityFireBall(int width, int height, int x, int y, int dx, int dy, EntityGhast owner, GameObject target)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.Controller.UpdateGameEvents += OnUpdate;
            if (target == null || owner == null)
            {
                throw (new ArgumentException("Een entity heeft altijd een target/owner nodig!"));
            }
            // Bepaald de verandering in de x en y van de vuurbal (de snelheid)
            DX = -((this.X - target.X) / FireballSpeed);
            DY = -((this.Y - target.Y) / FireballSpeed);

            EntityControlledByAI = false;
            Type = ObjectType.FIREBALL;
            IsSolid = false;
            this.owner = owner;
        }
        /// <summary>
        /// FILL THIS IN
        /// </summary>
        public EntityFireBall(int width, int height, int x, int y, EntityGhast owner, GameObject target) : this(width, height, x, y, 0, 0, owner, target) { }

        public override CollisionType CollidesWithObject(GameObject entity)
        {
            if (entity == owner)
                return CollisionType.NONE;
            AnimatedSprite sprite = entity as AnimatedSprite;
            if(sprite != null)
                return CollisionType.NONE;
            return base.CollidesWithObject(entity);
        }

        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Verwijderd de fireball als het de randen van het spel raakt
                //if (this.X <= 10 || this.Y <= 10 || this.X >= (Playfield.Width - 25) || this.Y >= (Playfield.Height - 25))
                  //  Playfield.RemoveObject(this);
                if (this.X + DX < 0 || this.X + DX + Width > Playfield.Width || this.Y + DY < 0 || this.Y + DY + Height > Playfield.Height)
                    Playfield.RemoveObject(this);
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            // Ontplof niet wanneer het object collide met de eigenaar van de vuurbal of met een andere vuurbal
            if (gameObject == owner) // removed:  || gameObject.Type == ObjectType.FIREBALL
            {
                return;
            }
            // Ontplof wanneer het de speler raakt (en verwijder het object meteen van het speelveld)
            else if (gameObject.Type == ObjectType.PLAYER)
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
                    Playfield.RemoveObject(gameObject);
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {            
            // Verwijder dit object uit de gameloop met een mooie explosie
            OlympusTheGame.Controller.UpdateGameEvents -= OnUpdate;
            Playfield.AddObject(new SpriteExplosion(this));
        }

        public override string ToString()
        {
            return "Fireball";
        }
    }
}
