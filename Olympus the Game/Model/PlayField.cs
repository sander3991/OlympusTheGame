using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Olympus_the_Game.Model.Entities;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model
{
    public class PlayField : IXmlSerializable
    {
        public delegate void DelOnPlayFieldChanged(GameObject go);

        public const int DefaultHeight = 1000;
        public const int DefaultWidth = 500;

        private static int ID;
        private bool _isClosing;

        /// <summary>
        /// Initialiseert een standaard PlayField object aan zonder GameObjects en met een breedte van 1000 en een hoogte van 500.
        /// </summary>
        public PlayField() : this(DefaultWidth, DefaultHeight)
        {
        }

        /// <summary>
        /// Initialiseert een PlayField met een custom breedte en hoogte
        /// </summary>
        /// <param name="width">De breedte van het PlayField</param>
        /// <param name="height">De hoogte van het PlayField</param>
        public PlayField(int width, int height)
        {
            Width = width;
            Height = height;
            int mapId = ID++;
            Name = "Map_" + mapId;
            IsInitialized = false;
            GameObjects = new List<GameObject>();
        }

        /// <summary>
        /// De breedte van de PlayField
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// De hoogte van het PlayField
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// De GameObjecten van dit PlayField.
        /// </summary>
        public List<GameObject> GameObjects { get; private set; }

        /// <summary>
        /// De Speler op dit PlayField
        /// </summary>
        public EntityPlayer Player { get; private set; }

        /// <summary>
        /// De naam van dit PlayField
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is dit PlayField geinitialiseerd met de GameObjects
        /// </summary>
        public bool IsInitialized { get; private set; }

        public event DelOnPlayFieldChanged OnObjectAdded;

        public event DelOnPlayFieldChanged OnObjectRemoved;

        /// <summary>
        /// Initialiseert alle GameObject zonder gameobjecten
        /// </summary>
        public void InitializeGameObjects()
        {
            InitializeGameObjects(new List<GameObject>());
        }

        /// <summary>
        /// Initialiseert de PlayMap met de meegegeven lijst met GameObjects
        /// </summary>
        /// <param name="objects">De Lijst waarmee het PlayField geinitialiseerd dient te worden</param>
        public void InitializeGameObjects(List<GameObject> objects)
        {
            if (!IsInitialized)
            {
                if (objects == null)
                    throw new ArgumentException("Geen lijst met gameobjects meegegeven");
                GameObjects = objects;
                foreach (GameObject t in objects)
                {
                    if (t.Playfield != null && t.Playfield != this)
                        //Is er al een PlayField object aangekoppeld, dat mag niet!
                        throw new ArgumentException("De meegegeven objects zijn al gekoppeld aan een PlayField!");
                    t.Playfield = this;
                    EntityPlayer player = t as EntityPlayer;
                    if (player != null) //Is dit het speler object? Deze willen we niet in de gameObject lijst hebben
                    {
                        Player = player; //Zet de speler in de Player property
                        if (GameObjects != null) GameObjects.Remove(player);
                    }
                }
                if (Player != null) // TODO Waarom??????????
                    Player.Playfield = this;
                IsInitialized = true;
            }
            SetPlayerHome();
        }

        /// <summary>
        /// Voegt een entity toe aan het speelveld
        /// </summary>
        public void AddObject(GameObject entity)
        {
            if (_isClosing) return; //We willen niks meer toevoegen als wij dingen toevoegen
            if (entity.Playfield != null)
                throw new ArgumentException("Het meegegeven object is al gekoppeld aan een PlayField");
            GameObjects.Add(entity);
            entity.Playfield = this;
            if (OnObjectAdded != null)
                OnObjectAdded(entity);
        }

        /// <summary>
        /// Verwijderd een GameObject van dit speelveld, bij het verwijderen van dit object wordt de OnRemoved van dat object aangeroepen.
        /// </summary>
        /// <param name="entity">Het GameObject dat verwijderd dient te worden</param>
        public void RemoveObject(GameObject entity)
        {
            RemoveObject(entity, false);
        }

        /// <summary>
        /// Verwijderd een GameObject van dit speelveld, bij het verwijderen van dit object worrdt de OnRemoved van dat object aangeroepen.
        /// </summary>
        /// <param name="entity">Het GameObject dat verwijderd dient te worden</param>
        /// <param name="fieldRemoved">True als het spel wordt uitgeladen</param>
        public void RemoveObject(GameObject entity, bool fieldRemoved)
        {
            GameObjects.Remove(entity);
            entity.OnRemoved(fieldRemoved);
            if (OnObjectRemoved != null)
                OnObjectRemoved(entity);
        }

        /// <summary>
        /// Zet de speler op de home locatie neer, en maakt een Player aan als deze nog niet bestaat.
        /// </summary>
        public void SetPlayerHome()
        {
            if (Player == null) //Bestaat de speler al? Zo niet, dan maken wij hem aan.
            {
                Player = new EntityPlayer(50, 50, 0, 0);
                Player.Playfield = this;
            }
            ObjectStart start = null;
            foreach (GameObject o in GameObjects)
            {
                start = o as ObjectStart;
                if (start != null)
                    break;
            }
            if (start != null)
            {
                //Zet de speler op het midden van het startobject
                Player.X = (start.X + start.Width/2) - (Player.Width/2);
                Player.Y = (start.Y + start.Height/2) - (Player.Height/2);
            }
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
            for (int i = 0; i < GameObjects.Count; i++) //loopt door alle objects
            {
                GameObject o = GameObjects[i];
                if (o.X <= x && (o.X + o.Width) >= x && o.Y <= y && (o.Y + o.Height) >= y)
                    //zit de object op de locatie x/y
                    objectList.Add(o); //Zo ja, voeg het toe aan de List
            }
            if (Player != null && Player.X >= x && (Player.X + Player.Width) <= x && Player.Y >= y &&
                (Player.Y + Player.Height) <= y)
                objectList.Add(Player); //Controleer ook of de player op die plek zit

            return objectList.Count == 0 ? null : objectList;
                // Return alleen de lijst als er daadwerkelijk wat in zit, anders null.
        }

        /// <summary>
        /// Verwijderd alle gameobjecten van het speelveld, en roept de GameObject.OnRemoved aan voor elke method.
        /// </summary>
        public void UnloadPlayField()
        {
            _isClosing = true;
            List<GameObject> oldList = new List<GameObject>(GameObjects);
                //we maken een nieuwe lijst aan zodat we alle referenties behouden, RemoveObject haalt de referenties weg!
            foreach (GameObject go in oldList)
                RemoveObject(go, true);
            if (GameObjects.Count != 0)
                throw new NotImplementedException();
            Player.OnRemoved(true);
            if (OnObjectRemoved != null)
                OnObjectRemoved(Player);
            Player = null;
        }

        #region Xml I/O Implementatie

        /// <summary>
        /// Interface implementatie IXmlSerializable
        /// </summary>
        /// <returns>null, comform documentatie interface</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Word aargeroepen door de XmlReader om een PlayField bestand in te lezen
        /// </summary>
        /// <param name="reader">De reader aangemaakt door de XmlReader</param>
        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            // Variabelen om te onthouden wat de gameobject voor variabelen hebben
            GameObject newObject = null;
            // boolean om te kijken of hij bezig is met het lezen van een object.
            bool isReadingObject = false;
            while (!(reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "PlayField"))
                //blijf lezen totdat je bij het eindelement van PlayField bent
            {
                switch (reader.NodeType) //Switch op element type
                {
                    case XmlNodeType.Element:
                        string elementName = reader.LocalName; //Haal het element naam eruit
                        if (elementName != "GameObject")
                            //Bij alle elementen behalve 'GameObject' naar het volgende element gaan, bij GameObject niet doen omdat we daarvan het attribuut moeten lezen
                            reader.Read();
                                //Het volgende object is de tekst tussen de elementen, op te vragen via reader.Value
                        switch (elementName)
                        {
                            case "Name":
                                Name = reader.Value;
                                break;
                            case "Width":
                                if (isReadingObject)
                                {
                                    if (newObject != null)
                                        newObject.Width = Convert.ToInt32(reader.Value);
                                }
                                else
                                    Width = Convert.ToInt32(reader.Value);
                                break;
                            case "Height":
                                if (isReadingObject)
                                {
                                    if (newObject != null)
                                        newObject.Height = Convert.ToInt32(reader.Value);
                                }
                                else
                                    Height = Convert.ToInt32(reader.Value);
                                break;
                            case "GameObjects":
                                isReadingObject = true;
                                continue;
                            case "GameObject":
                                if (!reader.HasAttributes)
                                    //Heeft het huidige object attributen, in het attribuut staat namelijk het object type
                                    Console.WriteLine(
                                        "Bij het lezen van het XML bestand is er wat fout gegaan, er mist een class in de GameObject attribuut!");
                                string str = reader.GetAttribute("Type"); //Haal het Type attribuut op
                                if (str == null)
                                    Console.WriteLine("Het attribuut kon niet ingelezen worden!");
                                try
                                {
                                    str = char.ToUpper(str[0]) + str.Substring(1).ToLower().Replace(" ","");//De char.toUpper en substring zorgen ervoor dat het altijd zo geformat is als de enum om de kans te vergroten dat het lukt! De Replace zorgt ervoor dat er eventuele spaties uitgehaald worden
                                    newObject = LevelEditorUtils.CreateObjectOfType((ObjectType)Enum.Parse(typeof(ObjectType), str)); //Zet het om naar het enum type die erbij hoort
                                }
                                catch (InvalidCastException)
                                {
                                    Console.WriteLine("Er ging iets fout bij het casten van het attribuut naar de enum");
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Het object van type '{0}' kon niet ingeladen worden!", str);
                                }
                                break;
                            default:
                                // Voor de default gaan we kijken of het gegeven element een property is in het gameobject
                                if (newObject != null)
                                {
                                    PropertyInfo propInfo = newObject.GetType().GetProperty(elementName);
                                        //WE zoeken hier de property op
                                    if (propInfo == null)
                                        // Als de property niet bestaat, laten we dit de user weten met een print line
                                        Console.WriteLine(
                                            "Er ging iets niet goed bij het inlezen van het element {0} in het object van type {1}.",
                                            elementName, newObject.Type);
                                    else //Doet ie het wel gaan we het proberen te zetten in de property
                                        try
                                        {
                                            // We zetten hier de value in het newObject object. Dit doen we door de value te converten naar het type in de property.
                                            propInfo.SetValue(newObject,
                                                Convert.ChangeType(reader.Value, propInfo.PropertyType), null);
                                        }
                                        catch (FormatException)
                                        {
                                            // Mochten we het nou niet kunnen converten, laten we dit ook weten aan de user
                                            Console.WriteLine(
                                                "Value {0} kon niet ingelezen worden. {1} kon niet omgezet worden naar type {2}",
                                                elementName, reader.Value, propInfo.PropertyType);
                                        }
                                }
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.LocalName == "GameObject")
                        {
                            if (newObject != null)
                            {
                                AddObject(newObject);
                                newObject = null;//Haalt de verwijzing weg zodat we weten dat we niet meer aan het lezen zijn
                            }
                        }
                        break;
                }
                reader.Read();
            }
             IsInitialized = true;
        }

        /// <summary>
        /// IXmlSerializable interface voor het schrijven naar een XmlBestand
        /// </summary>
        /// <param name="writer">De schrijver</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Width", Width.ToString());
            writer.WriteElementString("Height", Height.ToString());
            writer.WriteStartElement("GameObjects");
            foreach (GameObject o in GameObjects)
            {
                writer.WriteStartElement("GameObject");
                writer.WriteAttributeString("Type", o.Type.ToString());
                foreach (
                    PropertyInfo fi in
                        o.GetType()
                            .GetProperties()
                            .Where( //Reflection gemaakt door Ruben, geen idee hoe die het doet maar het iterate over alle Properties
                                delegate(PropertyInfo pi)
                                {
                                    object[] attributes = pi.GetCustomAttributes(typeof (ExcludeFromEditor), true);
                                    return pi.CanWrite &&
                                           (!attributes.Any() || !((ExcludeFromEditor) attributes[0]).Exclude);
                                }))
                {
                    writer.WriteElementString(fi.Name, fi.GetValue(o, new object[] {}).ToString());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        #endregion
    }
}