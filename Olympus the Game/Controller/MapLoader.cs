using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using Olympus_the_Game.Model;

namespace Olympus_the_Game.Controller
{
    internal static class PlayfieldLoader
    {
        public delegate void DelCustomMapChanged(string mapName, string fileName);

        /// <summary>
        ///     De locatie van de custom maps die ingelezen worden door de MapLoader
        /// </summary>
        public static readonly string CustomMapLoc = Environment.CurrentDirectory + "\\CustomMaps";

        private static readonly XmlSerializer Serialiser = new XmlSerializer(typeof (PlayField));
        private static readonly FileSystemWatcher directoryWatcher;

        private static readonly Dictionary<string, string> customMaps;
        //customMaps, de key is de locatie van het bestand, de value is de omschrijving van het bestand

        static PlayfieldLoader()
        {
            customMaps = new Dictionary<string, string>();
            if (!Directory.Exists(CustomMapLoc))
                Directory.CreateDirectory(CustomMapLoc);
            foreach (string fileLoc in Directory.GetFiles(CustomMapLoc))
                AddFile(fileLoc);
            directoryWatcher = new FileSystemWatcher(CustomMapLoc);
            directoryWatcher.Filter = "*.xml";
            directoryWatcher.EnableRaisingEvents = true;
            directoryWatcher.Created += directoryWatcher_Created;
            directoryWatcher.Deleted += directoryWatcher_Deleted;
            directoryWatcher.Renamed += directoryWatcher_Renamed;
        }

        #region Directory Listener

        /// <summary>
        ///     Bij het renamen van een bestand wordt deze method aangeroepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void directoryWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (customMaps.ContainsKey(e.OldFullPath)) //rename the file in the dictionary, if it exists
            {
                customMaps[e.FullPath] = customMaps[e.OldFullPath];
                customMaps.Remove(e.OldFullPath);
            }
        }

        /// <summary>
        ///     Bij het verwijderen van een bestand wordt deze method aangeroepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void directoryWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (customMaps.ContainsKey(e.FullPath))
            {
                if (OnCustomMapRemoved != null)
                    OnCustomMapRemoved(customMaps[e.FullPath], e.FullPath);
                customMaps.Remove(e.FullPath);
            }
        }

        /// <summary>
        ///     Bij het aanmaken van een bestand in de folder wordt deze method aangeroepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void directoryWatcher_Created(object sender, FileSystemEventArgs e)
        {
            AddFile(e.FullPath);
        }

        /// <summary>
        ///     Handelt het toevoegen van een bestand af
        /// </summary>
        /// <param name="fileLocation">De locatie van het bestand</param>
        /// <param name="attempt">De hoeveelste poging het is om dit bestand te openen. Bij 50 pogingen stopt hij met proberen</param>
        private static void AddFile(string fileLocation, int attempt = 0)
        {
            if (!File.Exists(fileLocation)) return; //Fallback voor als er een verkeerde file locatie wordt meegegeven
            if (Path.GetExtension(fileLocation) == ".xml") //controleerd of het een .xml bestand is
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(fileLocation);
                }
                catch (IOException)
                {
                    if (attempt < 50)
                    {
                        //we gaan het maximaal 50 keer proberen opnieuw te lezen
                        Thread.Sleep(100); //We wachten in deze worked thread een 0,1 seconde, en proberen het opnieuw
                        AddFile(fileLocation, attempt++);
                        // TODO Sander: Waaroom hier attempt++, moet er niet in de methode parameters ref / out staan?
                        return;
                        //Als wij op dit punt een IOException krijgen, is het bestand nog niet klaar met schrijven, we returnen omdat later het event nog een keer afgevuurd word, en we het dan wel kunnen lezen!
                    }
                }
                string line;
                string name = null;
                // TODO Sander: file kan null zijn
                while ((line = file.ReadLine()) != null) // Lees alle regels door om te zoeken naar onderstaande tekst
                {
                    int index1 = line.IndexOf("<Name>"); //Het begin van de name proeprty
                    int index2 = line.IndexOf("</Name>"); //het eind van de name property
                    if (index1 > -1 && index2 > -1) //Asl beide gevonden zijn, zitten tussen deze properties de naam
                    {
                        name = line.Substring(index1 + 6, index2 - (index1 + 6));
                        break; //we kunnen daarom nu ook stoppen met loopen
                    }
                }
                file.Close();
                if (name == null)
                    name = Path.GetFileName(fileLocation);
                customMaps.Add(fileLocation, name);
                if (OnCustomMapAdded != null)
                    OnCustomMapAdded(name, fileLocation);
            }
        }

        #endregion

        #region Maploading

        /// <summary>
        ///     Laad een custom map in.
        /// </summary>
        /// <param name="mapName">De mapnaam zoals aangegeven in de CustomMaps property</param>
        /// <returns>Het Playfield als hij het PlayField object heeft kunnen inlezen, anders null</returns>
        public static PlayField LoadCustomMap(string mapName)
        {
            foreach (var entry in customMaps)
            {
                if (entry.Value == mapName)
                    return ReadFromXml(new FileStream(entry.Key, FileMode.Open));
            }
            return null;
        }

        /// <summary>
        ///     Leest een XML bestand in.
        /// </summary>
        /// <param name="fileStream">De <code>Stream</code> waarin een Xml bestand zit</param>
        /// <returns>Een PlayField object als deze aangemaakt is. Als deze niet is aangemaakt null.</returns>
        public static PlayField ReadFromXml(Stream fileStream)
        {
            try
            {
                PlayField pf = null;
                if (fileStream.Length > 0)
                {
                    Object o = Serialiser.Deserialize(fileStream);
                    pf = o as PlayField;
                }
                fileStream.Close();
                return pf;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Bestand \"{0}\" niet gevonden", fileStream);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Onjuiste string meegegeven: {0}", fileStream);
            }
            return null;
        }

        /// <summary>
        ///     Leest een resource, dit zijn strings met daarin de Xml gegevens.
        /// </summary>
        /// <param name="xml">De Properties.Resources.*, waar * de bestandsnaam is</param>
        /// <returns>Het PlayField object dat bij het Xml bestand hoort</returns>
        internal static PlayField ReadFromResource(string xml)
        {
            StringReader str = null;
            try
            {
                str = new StringReader(xml);
                Object o = Serialiser.Deserialize(str);
                var pf = o as PlayField;
                str.Close();
                return pf;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Something went wrong when reading the resource");
                return null;
            }
            finally
            {
                if (str != null)
                    str.Close();
            }
        }

        /// <summary>
        ///     Schrijf een PlayField naar een Xml bestand
        /// </summary>
        /// <param name="fileStream">De Stream waarnaartoe het Playfield moet worden weggeschreven</param>
        /// <param name="pf">De PlayField die weggeschreven moet worden</param>
        public static void WriteToXml(Stream fileStream, PlayField pf)
        {
            Serialiser.Serialize(fileStream, pf);
            fileStream.Close();
        }

        #endregion

        /// <summary>
        ///     Haalt een array met Maps die gemaakt zijn
        /// </summary>
        public static IEnumerable<string> CustomMaps
        {
            get { return customMaps.Values.ToArray(); }
        }

        /// <summary>
        ///     Wordt afgevuurd zodra er een nieuwe custom map beschikbaar is
        /// </summary>
        public static event DelCustomMapChanged OnCustomMapAdded;

        /// <summary>
        ///     Wordt afgevuurd zodra er een map verwijderd is
        /// </summary>
        public static event DelCustomMapChanged OnCustomMapRemoved;
    }
}