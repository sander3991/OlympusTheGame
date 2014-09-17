using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class PlayField
    {
        public readonly int WIDTH;
        public readonly int HEIGHT;
        private List<GameObject> gameObjects;
        private EntityPlayer player = new EntityPlayer();
        public EntityPlayer Player
        {
            get
            {
                return player;
            }
            set
            {
                return;
            }
        }

        /// <summary>
        /// Verkrijgt alle gameObjects die op het veld zijn
        /// </summary>
        public List<GameObject> GetObjects()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Voegt een entity toe aan het speelveld
        /// </summary>
        public void AddObject(GameObject entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
