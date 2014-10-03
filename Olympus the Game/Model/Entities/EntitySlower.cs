﻿using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntitySlower : Entity
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        /// <summary>
        /// De afstand waarin deze entity zijn effect werkt
        /// </summary>
        public const int EFFECTRANGE = 10;
        /// <summary>
        /// De sterkte van het effect van deze entity
        /// </summary>
        public const double EFFECTSTRENGTH = 0.5;

        /// <summary>
        /// Een EntitySlower object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        public EntitySlower(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.SLOWER;
        }
        /// <summary>
        /// Een EntitySlower object die spelers langzamer laten lopen, staat vanaf het begin stil
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        public EntitySlower(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            double distance = DistanceToObject(player);

            if (distance < 100)
            {   
                // Maak een cobweb aan wanneer er 2 seconden voorbij zijn gegaan nadat de speler in de buurt van de spider komt
                if (stopwatch.ElapsedMilliseconds >= 3000)
                {
                    EntityWeb web = new EntityWeb(55, 55, player.X, player.Y, 0, 0);
                    OlympusTheGame.INSTANCE.Playfield.AddObject(web);
                    stopwatch.Restart();
                }
            }
        }
        public override string ToString()
        {
            return "Spider";
        }


    }
}

