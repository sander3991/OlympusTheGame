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
        // TODO Sander: Commentaar toevoegen
        private static int ID = 0;
        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// De GameObjecten van dit PlayField.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; }
        public EntityPlayer Player { get; private set; }
        public string Name { get; set; }
        public bool IsInitialized { get; private set; }
        public PlayField() : this(1000, 500) { }
        public PlayField(int width, int height)
        {
            Width = width;
            Height = height;
            Name = "Map_" + ID++;
            IsInitialized = false;
            GameObjects = new List<GameObject>();
        }

        public void InitializeGameObjects()
        {
            if (!IsInitialized)
                this.InitializeGameObjects(GetDefaultMap(Width, Height));
        }

        public void InitializeGameObjects(List<GameObject> objects)
        {
            if (!IsInitialized)
            {
                if (objects == null)
                    new ArgumentException("Geen lijst met gameobjects meegegeven");
                GameObjects = objects;
                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects[i].Playfield != null || objects[i].Playfield == this)
                        new ArgumentException("De meegegeven objects zijn al gekoppeld aan een PlayField!");
                    objects[i].Playfield = this;
                    EntityPlayer player = objects[i] as EntityPlayer;
                    if (player != null)
                    {
                        Player = player;
                        GameObjects.Remove(player);
                    }
                }
                if (Player == null)
                {
                    SetPlayerHome();
                    Player.Playfield = this;
                }
                IsInitialized = true;
            }

        }

        /// <summary>
        /// Voegt een entity toe aan het speelveld
        /// </summary>
        public void AddObject(GameObject entity)
        {

            if (entity.Playfield != null)
                throw new ArgumentException("Het meegegeven object is al gekoppeld aan een PlayField");
            GameObjects.Add(entity);
            entity.Playfield = this;
        }
        // TODO Sander: Commentaar
        public void RemoveObject(GameObject entity)
        {
            GameObjects.Remove(entity);
            entity.OnRemoved(false);
        }
        /// <summary>
        /// Zet de speler op de home locatie neer
        /// </summary>
        public void SetPlayerHome()
        {
            if (Player == null)
            {
                Player = new EntityPlayer(50, 50, 0, 0);
                Player.Playfield = this;
            }
            ObjectStart start = null;
            foreach (GameObject o in GameObjects)
            {
                start = o as ObjectStart;
                if (o != null)
                    break;
            }
            if (start != null) 
            {
                //Zet de speler op het midden van het startobject
                Player.X = (start.X + start.Width / 2) - (Player.Width / 2);
                Player.Y = (start.Y + start.Height / 2) - (Player.Height / 2);
            }
        }

        // TODO Sander : Wegslopen
        public static List<GameObject> GetDefaultMap(int width, int height)
        {
            List<GameObject> objects = new List<GameObject>();
            objects.Add(new ObjectStart(150, 150, 0, 0));
            objects.Add(new ObjectFinish(150, 150, 800, 300));
            objects.Add(new ObjectObstacle(50, 50, 250, 250));
            objects.Add(new EntityCreeper(50, 50, 400, 60, 1.0f));
            objects.Add(new EntitySlower(50, 50, 200, 150));
            objects.Add(new EntityTimeBomb(50, 50, 600, 75, 1.0f));
            objects.Add(new EntityExplode(50, 50, 300, 05, 1.0f));
            objects.Add(new EntityGhast(50,50,100, 100));
            return objects;
        }
        // TODO Sander: In-code commentaar
        /// <summary>
        /// Haalt alle objecten op op de locatie
        /// </summary>
        /// <param name="x">De X locatie waarop gecontroleerd moet worden</param>
        /// <param name="y">De Y Locatie waarop gecontroleerd moet worden</param>
        /// <returns><code>null</code> als er niks is gevonden, anders een <code>List</code> met <code>GameObject</code></returns>
        public List<GameObject> GetObjectsAtLocation(int x, int y)
        {
            List<GameObject> objectList = new List<GameObject>();
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObject o = GameObjects[i];
                if (o.X <= x && (o.X + o.Width) >= x && o.Y <= y && (o.Y + o.Height) >= y)
                    objectList.Add(o);

            }
            if (Player != null && Player.X >= x && (Player.X + Player.Width) <= x && Player.Y >= y && (Player.Y + Player.Height) <= y)
                objectList.Add(Player);

            return objectList.Count == 0 ? null : objectList;
        }

        /// <summary>
        /// Verwijderd alle gameobjecten van het speelveld, en roept de GameObject.OnRemoved aan voor elke method.
        /// </summary>
        public void UnloadPlayField()
        {
            for (int i = 0; i < GameObjects.Count; i++)
                GameObjects[i].OnRemoved(true);
            Player.OnRemoved(true);
        }

        /// <summary>
        /// Interface implementatie IXmlSerializable
        /// </summary>
        /// <returns>null, comform documentatie interface</returns>
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        /// <summary>
        /// Word aargeroepen door de XmlReader om een PlayField bestand in te lezen
        /// </summary>
        /// <param name="reader">De reader aangemaakt door de XmlReader</param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.Read();
            ///Variabelen om te onthouden wat de gameobject voor variabelen hebben
            ObjectType objectType = ObjectType.UNKNOWN;
            int objectWidth = -1; ;
            int objectHeight = -1;
            int objectY = -1;
            int objectX = -1;
            int explodeStrength = -1;
            ///boolean om te kijken of hij bezig is met het lezen van een object.
            bool isReadingObject = false;
            while (!(reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "PlayField")) //blijf lezen totdat je bij het eindelement van PlayField bent
            {
                switch (reader.NodeType) //Switch op element type
                {
                    case XmlNodeType.Element:
                        string elementName = reader.LocalName; //Haal het element naam eruit
                        if (elementName != "GameObject") //Bij alle elementen behalve 'GameObject' naar het volgende element gaan, bij GameObject niet doen omdat we daarvan het attribuut moeten lezen
                            reader.Read(); //Het volgende object is de tekst tussen de elementen, op te vragen via reader.Value
                        switch (elementName)
                        {
                            case "Name":
                                Name = reader.Value;
                                break;
                            case "Width":
                                if (isReadingObject)
                                    objectWidth = Convert.ToInt32(reader.Value);
                                else
                                    Width = Convert.ToInt32(reader.Value);
                                break;
                            case "Height":
                                if (isReadingObject)
                                    objectHeight = Convert.ToInt32(reader.Value);
                                else
                                    Height = Convert.ToInt32(reader.Value);
                                break;
                            case "GameObjects":
                                isReadingObject = true;
                                continue;
                            case "X":
                                objectX = Convert.ToInt32(reader.Value);
                                break;
                            case "Y":
                                objectY = Convert.ToInt32(reader.Value);
                                break;
                            case "ExplodeStrength":
                                explodeStrength = Convert.ToInt32(reader.Value);
                                break;
                            case "GameObject":
                                if (!reader.HasAttributes) //Heeft het huidige object attributen, in het attribuut staat namelijk het object type
                                    Console.WriteLine("Bij het lezen van het XML bestand is er wat fout gegaan, er mist een class in de GameObject attribuut!");
                                string str = reader.GetAttribute("Type"); //Haal het Type attribuut op
                                if (str == null)
                                    Console.WriteLine("Het attribuut kon niet ingelezen worden!");
                                try
                                {
                                    objectType = (ObjectType)System.Enum.Parse(typeof(ObjectType), str); //Zet het om naar het enum type die erbij hoort
                                }
                                catch (InvalidCastException)
                                {
                                    Console.WriteLine("Er ging iets fout bij het casten van het attribuut naar de enum");
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if(reader.LocalName == "GameObject")
                        {
                            bool hasAllParameters = true;
                            //controleer of alle gegevens erin staan
                            if((objectType == ObjectType.UNKNOWN) || (objectX == -1) || (objectY == -1) || (objectHeight == -1) || (objectWidth == -1))
                            {
                                Console.WriteLine("Niet alle parameters van de entity zijn ingelezen!");
                                hasAllParameters = false;
                            }
                            if(objectType == ObjectType.CREEPER || objectType == ObjectType.TIMEBOMB || objectType == ObjectType.EXPLODE)
                                if (explodeStrength == -1)
                                {
                                    Console.WriteLine("Er mist een explodeer parameter!");
                                    hasAllParameters = false;
                                }
                            if (hasAllParameters)
                            {
                                switch (objectType)
                                {
                                    case ObjectType.SLOWER:
                                        AddObject(new EntitySlower(objectWidth, objectHeight, objectX, objectY));
                                        break;
                                    case ObjectType.TIMEBOMB:
                                        AddObject(new EntityTimeBomb(objectWidth, objectHeight, objectX, objectY, explodeStrength));
                                        break;
                                    case ObjectType.OBSTACLE:
                                        AddObject(new ObjectObstacle(objectWidth, objectHeight, objectX, objectY));
                                        break;
                                    case ObjectType.CREEPER:
                                        AddObject(new EntityCreeper(objectWidth, objectHeight, objectX, objectY, explodeStrength));
                                        break;
                                    case ObjectType.EXPLODE:
                                        AddObject(new EntityExplode(objectWidth, objectHeight, objectX, objectY, explodeStrength));
                                        break;
                                    case ObjectType.START:
                                        AddObject(new ObjectStart(objectWidth, objectHeight, objectX, objectY));
                                        break;
                                    case ObjectType.FINISH:
                                        AddObject(new ObjectFinish(objectWidth, objectHeight, objectX, objectY));
                                        break;
                                    case ObjectType.GHAST:
                                        AddObject(new EntityGhast(objectWidth, objectHeight, objectX, objectY));
                                        break;
                                    default:
                                        break;
                                }
                            }
                            //Naar default om de controle voor de volgende te resetten
                            objectType = ObjectType.UNKNOWN;
                            objectX = -1;
                            objectY = -1;
                            objectWidth = 1;
                            objectHeight = -1;
                            explodeStrength = -1;
                        }
                        break;
                }
                reader.Read();
            }
            if (GameObjects.Count > 0)
            {
                IsInitialized = true;
            }

            return;
        }
        /// <summary>
        /// IXmlSerializable interface voor het schrijven naar een XmlBestand
        /// </summary>
        /// <param name="writer">De schrijver</param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Width", Width.ToString());
            writer.WriteElementString("Height", Height.ToString());
            writer.WriteStartElement("GameObjects");
            foreach (GameObject o in GameObjects)
            {
                writer.WriteStartElement("GameObject");
                writer.WriteAttributeString("Type", o.Type.ToString());
                writer.WriteElementString("X", o.X.ToString());
                writer.WriteElementString("Y", o.Y.ToString());
                writer.WriteElementString("Width", o.Width.ToString());
                writer.WriteElementString("Height", o.Height.ToString());
                EntityExplode explode = o as EntityExplode;
                if (explode != null)
                    writer.WriteElementString("ExplodeStrength", explode.EffectStrength.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
