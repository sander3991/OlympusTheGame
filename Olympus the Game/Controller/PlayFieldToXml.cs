using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Olympus_the_Game
{
    class PlayFieldToXml
    {
        private PlayFieldToXml() { }
        public static PlayField ReadFromXml(string filePath)
        {
            try
            {
                StreamReader file = new StreamReader(filePath);
                Object o = (new XmlSerializer(typeof(PlayField)).Deserialize(file));
                PlayField pf = o as PlayField;
                file.Close();
                return pf;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Bestand \"{0}\" niet gevonden", filePath);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Onjuiste string meegegeven: {0}", filePath);
            }
            return null;
        }

        internal static PlayField ReadFromResource(string xml)
        {
            try
            {
                StringReader str = new StringReader(xml);
                Object o = (new XmlSerializer(typeof(PlayField)).Deserialize(str));
                PlayField pf = o as PlayField;
                str.Close();
                return pf;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Something went wrong when reading the resource");
                return null;
            }
        }

        public static void WriteToXml(string filePath, PlayField pf)
        {

        }
    }
}
