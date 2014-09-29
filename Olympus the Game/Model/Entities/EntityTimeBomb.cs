using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityTimeBomb : EntityExplode
    {
        /// <summary>
        /// De tijd hoe lang het duurt voordat deze entity explodeert
        /// </summary>
        public const int EXPLODETIME = 5;

        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        /// <param name="effectStrength">De sterkte van het object</param>
        public EntityTimeBomb(int width, int height, int x, int y, int dx, int dy, double effectStrength) : base(width, height, x, y, dx, dy, effectStrength)
        {
            EntityControlledByAI = false;
        }
        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        /// <param name="effectStrength">De sterkte van het object</param>
        public EntityTimeBomb(int width, int height, int x, int y, double effectStrength) : this(width, height, x, y, 0, 0, effectStrength) { 
        
        
        }
    }
}
