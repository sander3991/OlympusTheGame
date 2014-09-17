using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Entity : GameObject
    {
        public int DX
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {

            }
        }

        public int DY
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
