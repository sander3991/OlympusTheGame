using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class PlayField
    {
        public readonly int WIDTH;
        public readonly int HEIGHT;

        private List<GameObject> gameObjects = new List<GameObject>();

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
            return gameObjects;
        }

        /// <summary>
        /// Voegt een entity toe aan het speelveld
        /// </summary>
        public void AddObject(GameObject entity)
        {
            gameObjects.Add(entity);
        }
    }
}
