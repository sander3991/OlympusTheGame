using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class KeyHandlerClass
    {
        // Deze variabelen zijn voor als de gebruiker zelf keys toevoegd er word 
        //een int bijgehouden omdat de char die de gebruiker invoert makkelijke om te zetten is.
        public int CustomRight { get; set; }
        public int CustomLeft { get; set; }
        public int CustomUp { get; set; }
        public int CustomDown { get; set; }

        internal void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S ) 
            {
                MovePlayer(e, 2);
            }
            else
            {
                CustomMovePlayer(e, 2);
            }
                
        }

        internal void KeyUp(KeyEventArgs e)
        {
            MovePlayer(e, 0);
            CustomMovePlayer(e, 0);
        }

        public void MovePlayer(int speed, bool horizontaal)
        {
            if (horizontaal)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = speed;
            else
                OlympusTheGame.INSTANCE.Playfield.Player.DY = speed;
        }

        private void MovePlayer(KeyEventArgs e, int speed)
        {
            // Toetsen voor naar links en naar rechts.
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = -speed;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = speed;
            // Toetsen voor naar boven en naar beneden.
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                OlympusTheGame.INSTANCE.Playfield.Player.DY = -speed;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                OlympusTheGame.INSTANCE.Playfield.Player.DY = speed;
        }
        /// <summary>
        ///  Beweeg de speler met toetsen die zijn toegewezen
        /// </summary>
        /// <param name="e">Toetsen</param>
        /// <param name="speed">Snelheid</param>
        public void CustomMovePlayer(KeyEventArgs e, int speed)
        {
            if (e.KeyValue == CustomRight)
                MovePlayer(speed, true);

            if (e.KeyValue == CustomLeft)
                MovePlayer(-speed, true);

            if (e.KeyValue == CustomDown)
                MovePlayer(speed, false);

            if (e.KeyValue == CustomUp)
                MovePlayer(-speed, false);
        }

        

        
    }
}
