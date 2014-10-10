using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    public abstract class Entity : GameObject
    {
        /// <summary>
        /// De verandering in X per gametick.
        /// </summary>
        [ExcludeFromEditor]
        public virtual int DX { get; set; }
        /// <summary>
        /// De verandering in Y per gametick.
        /// </summary>
        [ExcludeFromEditor]
        public virtual int DY { get; set; }
        /// <summary>
        /// De X-positie van de entity voordat Move() werd aangeroepen
        /// </summary>
        [ExcludeFromEditor]
        public int PreviousX { get; private set; }
        /// <summary>
        /// De Y-positie van de entity voordat Move() werd aangeroepen
        /// </summary>
        [ExcludeFromEditor]
        public int PreviousY { get; private set; }
        /// <summary>
        /// Geeft aan of deze entity bestuurd moet worden door de AI
        /// </summary>
        [ExcludeFromEditor]
        public bool EntityControlledByAi { get; protected set; }
        /// <summary>
        /// Delegate om in de gaten te houden wanneer de entity beweegt
        /// </summary>
        /// <param name="e"></param>
        public delegate void DelOnMoved(Entity e);
        /// <summary>
        /// Event om in de gaten wanneer de entity beweegt
        /// </summary>
        public event DelOnMoved OnMoved;
        /// <summary>
        /// Initialiseert een Entity zonder dat hij beweegt in het begin.
        /// </summary>
        protected Entity(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }
        /// <summary>
        /// Initialiseert een Entity met een meegegeven DX en DY waarde. Deze wordt vanaf het begin gelijk toegepast
        /// </summary>
        protected Entity(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y)
        {
            DX = dx;
            DY = dy;
            PreviousX = X;
            PreviousY = Y;
            EntityControlledByAi = true;
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
