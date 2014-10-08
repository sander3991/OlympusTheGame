using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    class EntityWebMissile : Entity
    {
        /// <summary>
        /// De X locatie van de target
        /// </summary>
        private int targetX;
        /// <summary>
        /// De Y Locatie van de target
        /// </summary>
        private int targetY;
        private int prop_missilespeed = 6;
        /// <summary>
        /// De snelheid van de missile
        /// </summary>
        public int MissileSpeed
        {
            get
            {
                return prop_missilespeed;
            }
            set
            {
                prop_missilespeed = Math.Max(0, value);
            }
        }
        /// <summary>
        /// Wie heeft deze missile geschoten
        /// </summary>
        private EntitySlower source;
        /// <summary>
        /// Maakt een Missile object
        /// </summary>
        /// <param name="spider">Wie schiet dit object</param>
        /// <param name="target">Wie is de target van het object</param>
        public EntityWebMissile(EntitySlower spider, GameObject target)
            : base(spider.Width / 4, spider.Height / 4, spider.X, spider.Y)
        {
            Type = ObjectType.WEBMISSILE;
            //TODO: -25 berekenen via variabelen.
            targetX = (target.X + target.Width / 2) - 25;
            targetY = (target.Y + target.Height / 2) - 25;
            int distanceX = Math.Abs(targetX - spider.X);
            int distanceY = Math.Abs(targetY - spider.Y);
            if (distanceX > distanceY)
            {
                DX = MissileSpeed;
                DY = Convert.ToInt32(MissileSpeed * distanceY / distanceX);
            }
            else
            {
                DY = MissileSpeed;
                DX = Convert.ToInt32(MissileSpeed * distanceX / distanceY);
            }
            if (targetX < X)
                DX = -DX;
            if (targetY < Y)
                DY = -DY;
            EntityControlledByAI = false;
            OnMoved += EntityWebMissile_OnMoved;
            source = spider;
        }

        /// <summary>
        /// Deze entity collide nooit met een object, de afhandeling gaat via OnMoved
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override CollisionType CollidesWithObject(GameObject entity)
        {
            return CollisionType.NONE;
        }
        /// <summary>
        /// Controleerd of de missile z'n target gehaald heeft
        /// </summary>
        /// <param name="e">De entity die beweegd, zou alleen zichzelf moeten zijn</param>
        private void EntityWebMissile_OnMoved(Entity e)
        {
            if (Math.Abs(targetX - X) < 5 || Math.Abs(targetY - Y) < 5)
            {
                Playfield.RemoveObject(this);
            }
        }

        /// <summary>
        /// Zorg ervoor dat deze missile weg gaat, en maak een cobweb op de target
        /// </summary>
        /// <param name="fieldRemoved"></param>
        public override void OnRemoved(bool fieldRemoved)
        {
            OnMoved -= EntityWebMissile_OnMoved;
            if (!fieldRemoved)
                Playfield.AddObject(new EntityWeb(source.Width + 5, source.Height + 5, targetX, targetY)); //REMOVETHIS IF READ.. + 5 zodat je de spinnenweb niet wordt verstopt onder de speler
        }

        public override string ToString()
        {
            return "Cobweb Missile";
        }
    }
}
