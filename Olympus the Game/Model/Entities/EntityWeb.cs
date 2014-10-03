using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class EntityWeb : Entity
    {
        public bool isSlowingPlayer = false;

        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        public EntityWeb(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = false;
            Type = ObjectType.WEB;
            IsSolid = false;
        }

        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, staat vanaf het begin stil
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        public EntityWeb(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            double sm = OlympusTheGame.INSTANCE.Playfield.Player.SpeedModifier;
            double distance = DistanceToObject(player);

            //todo: Gebruik maken van oncollide ipv distance
            //todo: Max 3 cobwebs in het spel
            //todo: Cobweb verwijderen na x seconden
            //todo: Cobweb's niet laten overlappen

            // Maak de speler langzamer wanneer hij nog niet door een cobweb loopt
            if (distance <= 55 && !isSlowingPlayer && sm != 0.50)
            {
                player.SpeedModifier = player.SpeedModifier / 2;
                isSlowingPlayer = true;
            }
            // Maakt de speler sneller wanneer het niet meer in aanraking met een cobweb is
            else if (distance >= 55 && isSlowingPlayer && sm == 0.50)
            {
                player.SpeedModifier = player.SpeedModifier * 2;
                isSlowingPlayer = false;
            }
        }
    }
}
