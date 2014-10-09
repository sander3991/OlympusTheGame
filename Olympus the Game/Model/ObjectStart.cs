using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class ObjectStart : GameObject
    {
        /// <summary>
        /// Een GameObject die weergeeft waar de Startpositie op het veld is
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public ObjectStart(int width, int height, int x, int y)
            : base(width, height, x, y)
        {
            IsSolid = false;
            Type = ObjectType.START;
        }

        public override string ToString()
        {
            return "Start";
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Start van het level";
        }

        /// <summary>
        /// Lege constructor
        /// </summary>
        public ObjectStart() { }

    }
}
