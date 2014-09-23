using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityCreeper : EntityExplode
    {
        /// <summary>
        /// Een Creeper object met een beginsnelheid
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        public EntityCreeper(int width, int height, int x, int y, int dx, int dy)
        {

        }
        /// <summary>
        /// Een creeper object die stil staat op het begin
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public EntityCreeper(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }
    }
}
