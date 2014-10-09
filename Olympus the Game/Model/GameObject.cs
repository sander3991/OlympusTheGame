﻿using System;
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
        START,
        FINISH,
        UNKNOWN,
        SPRITEEXPLOSION,
        WEB,
        FIREBALL,
        GHAST,
        SILVERFISH,
        WEBMISSILE
    }
    [Flags]
    public enum CollisionType : byte
    {
        NONE = 0,
        X = 1,
        Y = 2,
    }

    public abstract class GameObject
    {
        private int x;
        private int y;
        private int height;
        private int width;
        private string description;
        public ObjectType Type
        {
            get
            {
                return prop_type;
            }
            protected set
            {
                prop_type = value;
                if (!TypeLijst.ContainsKey(value))
                    TypeLijst.Add(value, this.GetType());
            }
        }
        private ObjectType prop_type = ObjectType.UNKNOWN;
        private PlayField prop_playfield;
        private static Dictionary<ObjectType, Type> TypeLijst = new Dictionary<ObjectType, Type>();

        public PlayField Playfield
        {
            set
            {
                if (prop_playfield == null) //Voorkomt dat het 2 keer geset wordt
                    prop_playfield = value;
            }
            get
            {
                return prop_playfield;
            }
        }

        /// <summary>
        /// Geeft aan hoever dit GameObject is wat betreft de animatie. Waarde is tussen 0.0f (begin) en 1.0f (eind) of hoger.
        /// </summary>
        public virtual float Frame
        {
            get
            {
                return -1.0f;
            }
            protected set { }
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
        public virtual int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value >= 0)
                {
                    if (Playfield == null || value + Width <= Playfield.Width)
                        x = value;
                    else
                        x = Playfield.Width - Width;
                }
            }
        }
        /// <summary>
        /// De Y positie van het game-object.
        /// </summary>
        public virtual int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                    if (Playfield == null || value + Height <= Playfield.Height)
                        y = value;
                    else
                        y = Playfield.Height - Height;
                else
                    y = 0;
            }
        }

        public virtual string getDescription(){
            description = "No description yet";
            return description;
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
            Type = ObjectType.UNKNOWN;
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
            return DoLinesOverlap(Y, Height, entity.Y, entity.Height);
        }
        /// <summary>
        /// Helper method om te bepalen of de X assen van de objecten elkaar kruisen
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>True als ze elkaar kruisen, anders false</returns>
        public bool CollidesWithX(GameObject entity)
        {
            return DoLinesOverlap(X, Width, entity.X, entity.Width);
        }
        /// <summary>
        /// Kijkt of de gegeven GameObject kruist over het huidige object.
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>CollisionType type van het type waar hij gecollide is</returns>
        public virtual CollisionType CollidesWithObject(GameObject entity)
        {
            if (CollidesWithX(entity) && CollidesWithY(entity))
            {
                CollisionType collision = CollisionType.X | CollisionType.Y;
                Entity thisEntity = this as Entity;
                if (thisEntity == null)
                    return collision;
                if (DoLinesOverlap(thisEntity.PreviousX, Width, entity.X, entity.Width))
                    collision = collision & ~CollisionType.X;
                if (DoLinesOverlap(thisEntity.PreviousY, Height, entity.Y, entity.Height))
                    collision = collision & ~CollisionType.Y;
                return collision == CollisionType.NONE ? CollisionType.X | CollisionType.Y : collision;
            }
            return CollisionType.NONE;
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
        /// <param name="fieldRemoved">bool die aangeeft of hij door het PlayField is verwijderd. True is door het speelveld verwijderd, false door een OnCollide</param>
        public virtual void OnRemoved(bool fieldRemoved)
        {

        }
        /// <summary>
        /// Controleerd of 2 lijnen elkaar overlappen. Gebaseerd op hun startpositie en breedte (of Hoogte).
        /// </summary>
        /// <param name="x1">Beginpunt van lijn 1</param>
        /// <param name="width1">Breedte van lijn 1</param>
        /// <param name="x2">Beginpunt van lijn 2</param>
        /// <param name="width2">Breedte van lijn 2</param>
        /// <returns>True als ze elkaar overlappen, anders false</returns>
        public static bool DoLinesOverlap(int x1, int width1, int x2, int width2)
        {
            if (x1 >= x2)
                return (x2 + width2) > x1;
            return (x1 + width1) > x2;
        }
    }
}
