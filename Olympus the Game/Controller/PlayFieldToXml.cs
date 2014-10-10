using System;
using System.IO;
using System.Xml.Serialization;
using Olympus_the_Game.Model;

namespace Olympus_the_Game.Controller
{
    class PlayFieldToXml
    {
        private static readonly XmlSerializer serialiser = new XmlSerializer(typeof(PlayField));
        private PlayFieldToXml() { }
        /// <summary>
        /// Leest een XML bestand in.
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

        /// <summary>
        /// Leest een resource, dit zijn strings met daarin de Xml gegevens.
        /// </summary>
        /// <param name="xml">De Properties.Resources.*, waar * de bestandsnaam is</param>
        /// <returns>Het PlayField object dat bij het Xml bestand hoort</returns>
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

        /// <summary>
        /// Schrijf een PlayField naar een Xml bestand
        /// </summary>
        /// <param name="fileStream">De Stream waarnaartoe het Playfield moet worden weggeschreven</param>
        /// <param name="pf">De PlayField die weggeschreven moet worden</param>
        public static void WriteToXml(Stream fileStream, PlayField pf)
        {
            serialiser.Serialize(fileStream, pf);
            fileStream.Close();
        }
    }
}
