using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympus_the_Game
{
    public abstract class Entity : GameObject
    {
        private int dx;
        private int dy;
        /// <summary>
        /// De verandering in X per gametick.
        /// </summary>
        public int DX
        {
            get
            {
                return dx;
            }
            set
            {
                dx = value;
            }
        }
         /// <summary>
         /// De verandering in Y per gametick.
         /// </summary>
        public int DY
        {
            get
            {
                return dy;
            }
            set
            {
                dy = value;
            }
        }
        /// <summary>
        /// De X-positie van de entity voordat Move() werd aangeroepen
        /// </summary>
        public int PreviousX { get; private set; }
        /// <summary>
        /// De Y-positie van de entity voordat Move() werd aangeroepen
        /// </summary>
        public int PreviousY { get; private set; }
        /// <summary>
        /// Initialiseert een Entity zonder dat hij beweegt in het begin.
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public Entity(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) {}
        /// <summary>
        /// Initialiseert een Entity met een meegegeven DX en DY waarde. Deze wordt vanaf het begin gelijk toegepast
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        public Entity(int width, int height, int x, int y, int dx, int dy) : base(width, height, x, y)
        {
            DX = dx;
            DY = dy;
            PreviousX = X;
            PreviousY = Y;
        }

        /// <summary>
        /// Beweegt een object gebaseerd op hun <paramref name="DX"/> en <paramref name="DY"/>
        /// </summary>
        public void Move()
        {
            PreviousX = X;
            PreviousY = Y;
            X += DX;
            Y += DY;
        }
    }
}
