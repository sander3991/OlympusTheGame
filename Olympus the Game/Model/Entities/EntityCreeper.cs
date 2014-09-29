using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus_the_Game;

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
        /// <param name="effectStrength">De sterkte van het exploderende object</param>
        public EntityCreeper(int width, int height, int x, int y, int dx, int dy, double explodeStrength) : base(width, height, x, y, dx, dy, explodeStrength)
        {
            EntityControlledByAI = true;
        }

        /// <summary>
        /// Een creeper object die stil staat op het begin
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="effectStrength">De sterkte van het exploderende object</param>
        public EntityCreeper(int width, int height, int x, int y, double explodeStrength) : this(width, height, x, y, 0, 0, explodeStrength) { }

        //public override void OnCollide(GameObject gameObject) {
        //    OlympusTheGame.INSTANCE.pf.Player.Health--;

        //}
    }
}
