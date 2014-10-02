using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus_the_Game;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntityTimeBomb : EntityExplode
    {
        /// <summary>
        /// De tijd hoe lang het duurt voordat deze entity explodeert
        /// </summary>
        public const int EXPLODETIME = 5;
        Stopwatch stopwatch = Stopwatch.StartNew();

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
        public EntityTimeBomb(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy, effectStrength)
        {
            EntityControlledByAI = false;
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.TIMEBOMB;
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
        public EntityTimeBomb(int width, int height, int x, int y, double effectStrength)
            : this(width, height, x, y, 0, 0, effectStrength)
        {


        }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;

            if (player != null)
            {

                stopwatch.Stop();
                if (DistanceToObject(player) < 100 && stopwatch.IsRunning == false)
                {
                    stopwatch.Start();
                }
                            
                if (stopwatch.ElapsedMilliseconds >= 3000 && DistanceToObject(player) < 100)
                {
                    PlayField pf = OlympusTheGame.INSTANCE.Playfield;
                    pf.SetPlayerHome();
                    pf.RemoveObject(this);
                    stopwatch.Stop();
                }
            }
        }
        public override void OnRemoved()
        {
            Controller contr = OlympusTheGame.INSTANCE.Controller;
            PlayField pf = OlympusTheGame.INSTANCE.Playfield;
            contr.UpdateGameEvents -= OnUpdate;
            pf.AddObject(new SpriteExplosion(this));
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "TimeBomb";
        }
    }
}
