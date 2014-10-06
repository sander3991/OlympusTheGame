using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Olympus_the_Game
{
    // TODO Sander: Comments
    class PlayFieldToXml
    {
        private static XmlSerializer serialiser = new XmlSerializer(typeof(PlayField));
        private PlayFieldToXml() { }
        public static PlayField ReadFromXml(Stream fileStream)
        {
            try
            {
                PlayField pf = null;
                if(fileStream.Length > 0)
                {
                    Object o = serialiser.Deserialize(fileStream);
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

        internal static PlayField ReadFromResource(string xml)
        {
            StringReader strReader = new StringReader(xml);
            StringReader str = null;
            try
            {
                str = new StringReader(xml);
                Object o = serialiser.Deserialize(str);
                PlayField pf = o as PlayField;
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

        public static void WriteToXml(Stream fileStream, PlayField pf)
        {
            serialiser.Serialize(fileStream, pf);
            fileStream.Close();
        }
    }
}
