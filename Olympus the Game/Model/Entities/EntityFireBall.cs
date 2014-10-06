using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityFireBall : Entity
    {
        public int fireballSpeed = 50; // Aanpasbaar in editor
        private EntityGhast owner;

        public EntityFireBall(int width, int height, int x, int y, int dx, int dy, EntityGhast owner, GameObject target)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            if (target == null || owner == null)
            {
                throw (new ArgumentException("Een entity heeft altijd een target/owner nodig!"));
            }

            int destinyX = target.X;
            int destinyY = target.Y;
            DX = -((this.X - destinyX) / fireballSpeed);
            DY = -((this.Y - destinyY) / fireballSpeed);
            EntityControlledByAI = false;
            Type = ObjectType.FIREBALL;
            IsSolid = false;
            this.owner = owner;
        }
        public EntityFireBall(int width, int height, int x, int y, EntityGhast owner, GameObject target) : this(width, height, x, y, 0, 0, owner, target) { }

        public override CollisionType CollidesWithObject(GameObject entity)
        {
            if (entity == owner)
            {
                return CollisionType.NONE;
            }
            return base.CollidesWithObject(entity);

        }
        public void OnUpdate()
        {
            // Fireball uit het veld halen wanneer het het speelveld verlaat
            if (this.X <= 3 || this.Y <= 3 || this.X >= (Playfield.Width - 25) || this.Y >= (Playfield.Height - 25))
                Playfield.RemoveObject(this);
        }

        public override void OnCollide(GameObject gameObject)
        {
            // Explodeer onder bepaalde voorwaarden
            if (gameObject == owner || gameObject.Type == ObjectType.FIREBALL)
            {
            }
            else if (gameObject.Type == ObjectType.PLAYER)
            {
                Playfield.Player.Health--;
                Playfield.RemoveObject(this);
            }
            else
            {
                Entity e = gameObject as Entity;
                Playfield.RemoveObject(this);
                if (e != null)
                    Playfield.RemoveObject(gameObject);
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            Playfield.AddObject(new SpriteExplosion(this));
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Fireball";
        }
    }
}
