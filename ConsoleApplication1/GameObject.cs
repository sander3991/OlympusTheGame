using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public abstract class GameObject
    {
        public readonly int Height;
        public readonly int Width;

        public int X
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Y
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Wat is de afstand hemelsbreed
        /// </summary>
        public double DistanceToObject(GameObject entity)
        {
            throw new System.NotImplementedException();
        }

        public bool CollidesWithObject(GameObject entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnCollide(GameObject gameObject)
        {

        }

        public abstract void PaintObject();
    }
}
