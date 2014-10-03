using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public enum ObjectType
    {
        PLAYER,
        SLOWER,
        TIMEBOMB,
        OBSTACLE,
        CREEPER,
        EXPLODE,
        HOME,
        CAKE,
        UNKNOWN,
        SPRITEEXPLOSION,
        SKELETON,
        WEB
    }

    public abstract class GameObject
    {
        private int x;
        private int y;
        private int height;
        private int width;
        public ObjectType Type { get; protected set; }

        /// <summary>
        /// Geeft aan hoever dit GameObject is wat betreft de animatie. Waarde is tussen 0.0f (begin) en 1.0f (eind) of hoger.
        /// </summary>
        public virtual float Frame
        {
            get
            {
                return -1.0f;
            }
            set { }
        }

        public GameObject()
        {
            Type = ObjectType.UNKNOWN;
        }

        /// <summary>
        /// De hoogte van het GameObject
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value >= 0)
                    height = value;
                else
                    height = 0;
            }
        }
        /// <summary>
        /// De breedte van het GameObject
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value >= 0)
                    width = value;
                else
                    width = 0;
            }
        }
        /// <summary>
        /// De X positie van het GameObject
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value >= 0)
                    x = value;
                else
                    x = 0;
            }
        }
        /// <summary>
        /// De Y positie van het game-object.
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                    y = value;
                else
                    y = 0;
            }
        }

        /// <summary>
        /// Is het object een solide object. Dit defineert of er andere entities doorheen kunnen lopen.
        /// </summary>
        public bool IsSolid { get; protected set; }
        /// <summary>
        /// Initialiseert een GameObject
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public GameObject(int width, int height, int x, int y)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsSolid = true;
        }

        /// <summary>
        /// Wat is de afstand tussen dit object en het andere object
        /// </summary>
        /// <param name="entity">Een GameObject waarmee vergeleken moet worden</param>
        /// <returns>De afstand tussen de twee game-objecten</returns>
        public double DistanceToObject(GameObject entity)
        {
            int xDistance = entity.X + (entity.Width / 2) - X - (Width / 2); //bekijkt de afstand van het midden van beide objecten
            int yDistance = entity.Y + (entity.Height / 2) - Y - (Height / 2); //bekijkt de afstand van het midden van beide objecten
            double result = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
            return result;
        }
        /// <summary>
        /// Helper method om te bepalen of de Y assen van de objecten elkaar kruisen
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>True als ze elkaar kruisen, anders false</returns>
        public bool CollidesWithY(GameObject entity)
        {
            if (Y >= entity.Y)
                return (entity.Y + entity.Height) > Y;
            return (Y + Height) > entity.Y;
        }
        /// <summary>
        /// Helper method om te bepalen of de X assen van de objecten elkaar kruisen
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>True als ze elkaar kruisen, anders false</returns>
        public bool CollidesWithX(GameObject entity)
        {
            if (X >= entity.X)
                return (entity.X + entity.Width) > X;
            return (X + Width) > entity.X;
        }
        /// <summary>
        /// Kijkt of de gegeven GameObject kruist over het huidige object.
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>True als ze elkaar kruisen, anders false</returns>
        public bool CollidesWithObject(GameObject entity)
        {
            return CollidesWithX(entity) && CollidesWithY(entity);
        }

        /// <summary>
        /// Wat moet er gedaan worden als de method met het meegegeven object kruist.
        /// Deze method is standaard leeg, en kan overriden worden om functionaliteit toe te voegen.
        /// </summary>
        /// <param name="gameObject">Het object waarmee gekruist wordt</param>
        public virtual void OnCollide(GameObject gameObject)
        {

        }

        /// <summary>
        /// Wordt aangeroepen als een object verwijderd wordt van het speelveld
        /// </summary>
        public virtual void OnRemoved()
        {

        }
    }
}
