using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntityWeb : Entity
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Controller contr = OlympusTheGame.INSTANCE.Controller;
        PlayField pf = OlympusTheGame.INSTANCE.Playfield;
        /// <summary>
        /// Een EntityWeb object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid
        /// </summary>
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
        public EntityWeb(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            if (this.CollidesWithObject(player) == false)
            {
                if (player.SpeedModifier != 1)
                    player.SpeedModifier *= 2;
                if (stopwatch.ElapsedMilliseconds >= 3000)
                {
                    OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
                    OlympusTheGame.INSTANCE.Playfield.RemoveObject(this);
                }
            }
        }

        public override void OnCollide(GameObject gameObject)
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;

            // Maak de speler langzamer wanneer hij wanneer hij door een cobweb loopt
            if (player.SpeedModifier != 0.50)
            {
                player.SpeedModifier = player.SpeedModifier / 2;
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }
        public override string ToString()
        {
            return "Cobweb";
        }
    }
}
