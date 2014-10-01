﻿using System;
namespace Olympus_the_Game {
    public class EntityExplode : Entity {
        /// <summary>
        /// De sterkte van het exploderende object
        /// </summary>
        public readonly double EffectStrength;
        /// <summary>
        /// Initialiseert een exploderend object dat explodeert als spelers daarmee in contact komen, hij beweegt gelijk na initialisatie
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        /// <param name="effectStrength">De sterkte van het exploderende object</param>
        public EntityExplode(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy) {
            EffectStrength = Math.Max(0, effectStrength);
            EntityControlledByAI = false;
        }
        /// <summary>
        /// Initialiseert een exploderend object dat explodeert als spelers daarmee in contact komen, hij beweegt niet na initialisatie
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="effectStrength">De sterkte van het exploderende object</param>
        public EntityExplode(int width, int height, int x, int y, double effectStrength) : this(width, height, x, y, 0, 0, effectStrength) { }

        public override void OnCollide(GameObject gameObject) {
            EntityPlayer player = gameObject as EntityPlayer;

            if(player != null){
                player.Health--;
                player.X = 0;
                player.Y = 0;

            }
        }

        public override string ToString()
        {
            return "Explode";
        }
    }
}
