using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympus_the_Game{
   public abstract class Entity : GameObject
    {
        /// <summary>
        /// De verandering in X per gametick.
        /// </summary>
        public virtual int DX {get;set;}
         /// <summary>
         /// De verandering in Y per gametick.
         /// </summary>
        public virtual int DY {get;set;}
        /// <summary>
        /// De X-positie van de entity voordat Move() werd aangeroepen
        /// </summary>
        public int PreviousX { get; private set; }
        /// <summary>
        /// De Y-positie van de entity voordat Move() werd aangeroepen
        /// </summary>
        public int PreviousY { get; private set; }
        /// <summary>
        /// Geeft aan of deze entity bestuurd moet worden door de AI
        /// </summary>
        public bool EntityControlledByAI { get; protected set; }

        public delegate void DelOnMoved(Entity e);

        public event DelOnMoved OnMoved;
        
        /// <summary>
        /// Initialiseert een Entity zonder dat hij beweegt in het begin.
        /// </summary>
        public Entity(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) {}
        /// <summary>
        /// Initialiseert een Entity met een meegegeven DX en DY waarde. Deze wordt vanaf het begin gelijk toegepast
        /// </summary>
        public Entity(int width, int height, int x, int y, int dx, int dy) : base(width, height, x, y)
        {
            DX = dx;
            DY = dy;
            PreviousX = X;
            PreviousY = Y;
            EntityControlledByAI = true;
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
            if (OnMoved != null)
                OnMoved(this);
        }
    }
}
