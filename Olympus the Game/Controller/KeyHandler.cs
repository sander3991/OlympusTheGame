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
    public static class KeyHandler
    {
        // Deze variabelen zijn voor als de gebruiker zelf keys toevoegd er word 
        public static Keys CustomRight { get; set; }
        public static Keys CustomLeft { get; set; }
        public static Keys CustomUp { get; set; }
        public static Keys CustomDown { get; set; }

        /// <summary>
        /// Wordt aangeroepen als je op een toetsklikt
        /// </summary>
        /// <param name="e"></param>
        internal static void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S ||
                e.KeyCode == CustomRight || e.KeyCode == CustomLeft ||
                e.KeyCode == CustomUp || e.KeyCode == CustomDown) 
            {
                MovePlayer(e, 2);
            }
        }
        /// <summary>
        /// Wordt aangeroepen als je een toets los laat
        /// </summary>
        /// <param name="e"></param>
        internal static void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S ||
                e.KeyCode == CustomRight || e.KeyCode == CustomLeft ||
                e.KeyCode == CustomUp || e.KeyCode == CustomDown)
            {
                MovePlayer(e, 0);
            }
        }
        /// <summary>
        ///  Beweeg de speler met toetsen die zijn toegewezen
        /// </summary>
        /// <param name="e">Toetsen</param>
        /// <param name="speed">Snelheid</param>
        private static void MovePlayer(KeyEventArgs e, int speed)
        {
            // Toetsen voor naar links en naar rechts.
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D || e.KeyCode == CustomRight)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = speed;
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A || e.KeyCode == CustomLeft)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = -speed;
            // Toetsen voor naar boven en naar beneden.
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W || e.KeyCode == CustomUp)
                OlympusTheGame.INSTANCE.Playfield.Player.DY = -speed;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S || e.KeyCode == CustomDown)
                OlympusTheGame.INSTANCE.Playfield.Player.DY = speed;
        }


        /// <summary>
        /// Move player als er op de knop wordt gedrukt vanuit ArrowPanel
        /// </summary>
        /// <param name="speed">Snelheid van de speler</param>
        /// <param name="horizontaal">Geef aan links of rechts</param>
        public static void MovePlayer(int speed, bool horizontaal)
        {
            if (horizontaal)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = speed;
            else
                OlympusTheGame.INSTANCE.Playfield.Player.DY = speed;
        }
        
        

        
    }
}
