﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Olympus_the_Game.Model.Entities;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model
{
    public enum ObjectType
    {
        Player,
        Slower,
        Timebomb,
        Obstacle,
        Creeper,
        Explode,
        Start,
        Finish,
        Unknown,
        Spriteexplosion,
        Web,
        Fireball,
        Ghast,
        Webmissile,
        Silverfish
    }

    [Flags]
    public enum CollisionType : byte
    {
        None = 0,
        X = 1,
        Y = 2,
    }

    public abstract class GameObject
    {
        #region Static Part

        public static readonly Dictionary<ObjectType, Func<GameObject>> ConstructorList =
            new Dictionary<ObjectType, Func<GameObject>>();

        static GameObject()
        {
            foreach (
                Type t in typeof (GameObject).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof (GameObject))))
            {
                RuntimeHelpers.RunClassConstructor(t.TypeHandle);
            }
        }

        protected static void RegisterWithEditor(ObjectType ot, Func<GameObject> a)
        {
            ConstructorList.Add(ot, a);
        }

        #endregion

        public delegate void DelOnVisibilityChanged(GameObject go, bool visible);

        private static int ID;

        private PlayField _propPlayfield;
        private bool _propVisible = true;
        private int height;
        private int width;
        private int x;
        private int y;

        /// <summary>
        ///     Initialiseert een GameObject
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        protected GameObject(int width, int height, int x, int y)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsSolid = true;
            Type = ObjectType.Unknown;
            UniqueID = ID++;
        }

        [ExcludeFromEditor]
        public bool Visible
        {
            get { return _propVisible; }
            set
            {
                if (_propVisible != value)
                {
                    _propVisible = value;
                    if (OnVisibilityChanged != null)
                        OnVisibilityChanged(this, value);
                }
            }
        }

        /// <summary>
        ///     Een uniek ID voor elk object dat wordt aangemaakt
        /// </summary>
        public int UniqueID { get; private set; }

        [ExcludeFromEditor]
        public ObjectType Type { get; protected set; }

        [ExcludeFromEditor]
        public PlayField Playfield
        {
            set
            {
                if (_propPlayfield == null) //Voorkomt dat het 2 keer geset wordt
                    _propPlayfield = value;
            }
            get { return _propPlayfield; }
        }

        /// <summary>
        ///     Geeft aan hoever dit GameObject is wat betreft de animatie. Waarde is tussen 0.0f (begin) en 1.0f (eind) of hoger.
        /// </summary>
        [ExcludeFromEditor]
        public virtual float Frame
        {
            get { return -1.0f; }
            protected set { throw new NotImplementedException(); }
        }

        /// <summary>
        ///     De hoogte van het GameObject
        /// </summary>
        [EditorTooltip("Hoogte", "De hoogte van dit object. De minimale hoogte is 10.")]
        public int Height
        {
            get { return height; }
            set { height = value >= 10 ? value : 10; }
        }

        /// <summary>
        ///     De breedte van het GameObject
        /// </summary>
        [EditorTooltip("Breedte", "De breedte van dit object. De minimale breedte is 10.")]
        public int Width
        {
            get { return width; }
            set { width = value >= 10 ? value : 10; }
        }

        /// <summary>
        ///     De X positie van het GameObject
        /// </summary>
        [EditorTooltip("X Positie", "De X positie van dit object")]
        public virtual int X
        {
            get { return x; }
            set
            {
                if (value >= 0)
                    if (Playfield == null || value + Width <= Playfield.Width)
                        x = value;
                    else
                        x = Playfield.Width - Width;
                else
                    x = 0;
            }
        }

        /// <summary>
        ///     De Y positie van het game-object.
        /// </summary>
        [EditorTooltip("Y Positie", "De Y positie van dit object")]
        public virtual int Y
        {
            get { return y; }
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

        /// <summary>
        ///     Is het object een solide object. Dit defineert of er andere entities doorheen kunnen lopen.
        /// </summary>
        [EditorTooltip("Solide", "Is dit object solide? De speler kan door niet solide objecten bewegen")]
        public bool IsSolid { get; protected set; }

        public event DelOnVisibilityChanged OnVisibilityChanged;

        /// <summary>
        ///     Verkrijg beschrijving van entity
        /// </summary>
        /// <returns>Beschrijving</returns>
        public abstract string GetDescription();

        /// <summary>
        ///     Wat is de afstand tussen dit object en het andere object
        /// </summary>
        /// <param name="entity">Een GameObject waarmee vergeleken moet worden</param>
        /// <returns>De afstand tussen de twee game-objecten</returns>
        public double DistanceToObject(GameObject entity)
        {
            int xDistance = entity.X + (entity.Width/2) - X - (Width/2);
            //bekijkt de afstand van het midden van beide objecten
            int yDistance = entity.Y + (entity.Height/2) - Y - (Height/2);
            //bekijkt de afstand van het midden van beide objecten
            double result = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
            return result;
        }

        /// <summary>
        ///     Helper method om te bepalen of de Y assen van de objecten elkaar kruisen
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>True als ze elkaar kruisen, anders false</returns>
        public bool CollidesWithY(GameObject entity)
        {
            return DoLinesOverlap(Y, Height, entity.Y, entity.Height);
        }

        /// <summary>
        ///     Helper method om te bepalen of de X assen van de objecten elkaar kruisen
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>True als ze elkaar kruisen, anders false</returns>
        public bool CollidesWithX(GameObject entity)
        {
            return DoLinesOverlap(X, Width, entity.X, entity.Width);
        }

        /// <summary>
        ///     Kijkt of de gegeven GameObject kruist over het huidige object.
        /// </summary>
        /// <param name="entity">Het GameObject waarmee vergeleken wordt</param>
        /// <returns>CollisionType type van het type waar hij gecollide is</returns>
        public virtual CollisionType CollidesWithObject(GameObject entity)
        {
            if (CollidesWithX(entity) && CollidesWithY(entity))
            {
                CollisionType collision = CollisionType.X | CollisionType.Y;
                var thisEntity = this as Entity;
                if (thisEntity == null)
                    return collision;
                if (DoLinesOverlap(thisEntity.PreviousX, Width, entity.X, entity.Width))
                    collision = collision & ~CollisionType.X;
                if (DoLinesOverlap(thisEntity.PreviousY, Height, entity.Y, entity.Height))
                    collision = collision & ~CollisionType.Y;
                return collision == CollisionType.None ? CollisionType.X | CollisionType.Y : collision;
            }
            return CollisionType.None;
        }

        /// <summary>
        ///     Wat moet er gedaan worden als de method met het meegegeven object kruist.
        ///     Deze method is standaard leeg, en kan overriden worden om functionaliteit toe te voegen.
        /// </summary>
        /// <param name="gameObject">Het object waarmee gekruist wordt</param>
        public virtual void OnCollide(GameObject gameObject)
        {
        }

        /// <summary>
        ///     Wordt aangeroepen als een object verwijderd wordt van het speelveld
        /// </summary>
        /// <param name="fieldRemoved">
        ///     bool die aangeeft of hij door het PlayField is verwijderd. True is door het speelveld
        ///     verwijderd, false door een OnCollide
        /// </param>
        public virtual void OnRemoved(bool fieldRemoved)
        {
        }

        /// <summary>
        ///     Controleerd of 2 lijnen elkaar overlappen. Gebaseerd op hun startpositie en breedte (of Hoogte).
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