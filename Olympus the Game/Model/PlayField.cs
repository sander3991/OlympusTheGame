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

        private List<GameObject> gameObjects;

        private EntityPlayer player = new EntityPlayer(0,0,0,0);

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

        public PlayField(int width, int height, List<GameObject> objects)
        {
            WIDTH = width;
            HEIGHT = height;
            if (objects != null)
                gameObjects = objects;
            else
                gameObjects = new List<GameObject>();
        }

        public PlayField(int width, int height) : this(width, height, PlayField.GetDefaultMap(width, height)) { }

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

        private static List<GameObject> GetDefaultMap(int width, int height)
        {
            List<GameObject> objects = new List<GameObject>();
            objects.Add(new ObjectStart(50, 50, 0, 0));
            objects.Add(new ObjectFinish(150, 150, 800, 300));
            objects.Add(new ObjectObstacle(50, 50, 60, 0));
            objects.Add(new EntityCreeper(50, 50, 150, 60, 1.0f));
            objects.Add(new EntityExplode(50, 50, 150, 0, 1.0f));
            objects.Add(new EntityPlayer(50, 50, 0, 0));
            objects.Add(new EntitySlower(50, 50, 200, 150));
            objects.Add(new EntityTimeBomb(50, 50, 600, 75, 1.0f));
            return objects;
        }
    }
}
