using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Olympus_the_Game
{
    public class PlayField : IXmlSerializable
    {
        private static int ID = 0;
        public int WIDTH { get; private set; }
        public int HEIGHT { get; private set; }
        private List<GameObject> gameObjects = new List<GameObject>();
        public EntityPlayer Player {get; private set;}
        public string Name { get; set; }
        public bool IsInitialized { get; private set; }
        public PlayField() : this(1000, 500) { }
        public PlayField(int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;
            Name = "Map_" + ID++;
            IsInitialized = false;
        }

        public void InitializeGameObjects()
        {
            if(!IsInitialized)
                this.InitializeGameobjects(GetDefaultMap(WIDTH, HEIGHT));
        }

        public void InitializeGameobjects(List<GameObject> objects)
        {
            if (!IsInitialized)
            {
                if (objects == null)
                    new ArgumentException("Geen lijst met gameobjects meegegeven");
                gameObjects = objects;
                for (int i = 0; i < objects.Count; i++)
                {
                    EntityPlayer player = objects[i] as EntityPlayer;
                    if (player != null)
                    {
                        Player = player;
                        gameObjects.Remove(player);
                    }
                }
                if (Player == null)
                    Player = new EntityPlayer(50, 50, 0, 0);
                IsInitialized = true;
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
        /// <summary>
        /// Zet de speler op de home locatie neer
        /// </summary>
        public void SetPlayerHome()
        {
            ObjectStart start = null;
            foreach(GameObject o in gameObjects)
            {
                start = o as ObjectStart;
                if(o != null)
                    break;
            }
            if (start != null)
            {
                Player.X = (start.X + start.Width) / 2 - (Player.Width / 2);
                Player.Y = (start.Y + start.Height) / 2 - (Player.Height / 2);
            }
        }

        public static List<GameObject> GetDefaultMap(int width, int height)
        {
            List<GameObject> objects = new List<GameObject>();
            objects.Add(new ObjectStart(150, 150, 0, 0));
            objects.Add(new ObjectFinish(150, 150, 800, 300));
            objects.Add(new ObjectObstacle(50, 50, 250, 250));
            objects.Add(new EntityCreeper(50, 50, 150, 60, 1.0f));
            objects.Add(new EntityExplode(50, 50, 150, 0, 1.0f));
            objects.Add(new EntitySlower(50, 50, 200, 150));
            objects.Add(new EntityTimeBomb(50, 50, 600, 75, 1.0f));
            return objects;
        }

        /// <summary>
        /// Haalt alle objecten op op de locatie
        /// </summary>
        /// <param name="x">De X locatie waarop gecontroleerd moet worden</param>
        /// <param name="y">De Y Locatie waarop gecontroleerd moet worden</param>
        /// <returns><code>null</code> als er niks is gevonden, anders een <code>List</code> met <code>GameObject</code></returns>
        public List<GameObject> GetObjectsAtLocation(int x, int y)
        {
            List<GameObject> objectList = new List<GameObject>();
            for (int i = 0; i < gameObjects.Count; i++ )
            {
                GameObject o = gameObjects[i];
                if (o.X <= x && (o.X + o.Width) >= x && o.Y <= y && (o.Y + o.Height) >= y)
                    objectList.Add(o);

            }
            if (Player != null && Player.X >= x && (Player.X + Player.Width) <= x && Player.Y >= y && (Player.Y + Player.Height) <= y)
                objectList.Add(Player);

            return objectList.Count == 0 ? null : objectList;
        }

        public void SaveToXml(string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            new XmlSerializer(typeof(PlayField)).Serialize(file, this);
            file.Close();
        }

        public static PlayField GetFromXml(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            Object o = (new XmlSerializer(typeof(PlayField)).Deserialize(file));
            PlayField pf = o as PlayField;
            file.Close();
            return pf;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.Read();
            }
            return;
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Width", WIDTH.ToString());
            writer.WriteElementString("Height", HEIGHT.ToString());
            writer.WriteStartElement("GameObjects");
            foreach (GameObject o in gameObjects)
            {
                writer.WriteStartElement("GameObject");
                writer.WriteAttributeString("Type", o.Type.ToString());
                writer.WriteElementString("X", o.X.ToString());
                writer.WriteElementString("Y", o.Y.ToString());
                writer.WriteElementString("Width", o.Width.ToString());
                writer.WriteElementString("Height", o.Height.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
