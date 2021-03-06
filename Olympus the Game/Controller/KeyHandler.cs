﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace Olympus_the_Game.Controller
{
    /// <summary>
    ///     Gebruik deze klasse om alle toetsen aan toe te voegen
    /// </summary>
    public static class KeyHandler
    {
        private static List<Keys> blockedKeys = new List<Keys> { Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.W, Keys.A, Keys.D, Keys.S, Keys.P, Keys.F11 };
        private static Keys _right;
        private static Keys _left;
        private static Keys _up;
        private static Keys _down;
        // Deze variabelen zijn voor als de gebruiker zelf keys toevoegd er word 
        public static Keys CustomRight { 
            get { return _right; }
            set { SetKey(ref _right, value); }
        }
        public static Keys CustomLeft
        {
            get { return _left; }
            set { SetKey(ref _left, value); }
        }
        public static Keys CustomUp
        {
            get { return _up; }
            set { SetKey(ref _up, value); }
        }
        public static Keys CustomDown
        {
            get { return _down; }
            set { SetKey(ref _down, value); }
        }

        /// <summary>
        ///     Wordt aangeroepen als je op een toetsklikt
        /// </summary>
        /// <param name="e"></param>
        internal static void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left  || e.KeyCode == Keys.Right  ||
                e.KeyCode == Keys.Up    || e.KeyCode == Keys.Down   ||
                e.KeyCode == Keys.A     || e.KeyCode == Keys.D      ||
                e.KeyCode == Keys.W     || e.KeyCode == Keys.S      ||
                e.KeyCode == CustomRight|| e.KeyCode == CustomLeft  ||
                e.KeyCode == CustomUp   || e.KeyCode == CustomDown)
            {
                MovePlayer(e, 2);
            }
        }

        /// <summary>
        ///     Wordt aangeroepen als je een toets los laat
        /// </summary>
        /// <param name="e"></param>
        internal static void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left  || e.KeyCode == Keys.Right  ||
                e.KeyCode == Keys.Up    || e.KeyCode == Keys.Down   ||
                e.KeyCode == Keys.A     || e.KeyCode == Keys.D      ||
                e.KeyCode == Keys.W     || e.KeyCode == Keys.S      ||
                e.KeyCode == CustomRight|| e.KeyCode == CustomLeft  ||
                e.KeyCode == CustomUp   || e.KeyCode == CustomDown)
            {
                MovePlayer(e, 0);
            }
            // Als control is ingedrukt samen met p dan moet er niet worden gepauseerd dit zorg voor en conflict bij weergave
            if (e.KeyCode == Keys.P && (Control.ModifierKeys & Keys.Control) == 0)
            {
                if (OlympusTheGame.IsPaused)
                    OlympusTheGame.Resume();
                else
                    OlympusTheGame.Pause();
            }
        }

        /// <summary>
        ///     Beweeg de speler met toetsen die zijn toegewezen
        /// </summary>
        /// <param name="e">Toetsen</param>
        /// <param name="speed">Snelheid</param>
        private static void MovePlayer(KeyEventArgs e, int speed)
        {
            // Toetsen voor naar links en naar rechts.
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D || e.KeyCode == CustomRight)
                OlympusTheGame.Playfield.Player.DX = speed;
            if (e.KeyCode == Keys.Left  || e.KeyCode == Keys.A || e.KeyCode == CustomLeft)
                OlympusTheGame.Playfield.Player.DX = -speed;
            // Toetsen voor naar boven en naar beneden.
            if (e.KeyCode == Keys.Up    || e.KeyCode == Keys.W || e.KeyCode == CustomUp)
                OlympusTheGame.Playfield.Player.DY = -speed;
            if (e.KeyCode == Keys.Down  || e.KeyCode == Keys.S || e.KeyCode == CustomDown)
                OlympusTheGame.Playfield.Player.DY = speed;
        }

        /// <summary>
        ///     Move player als er op de knop wordt gedrukt vanuit ArrowPanel
        /// </summary>
        /// <param name="speed">Snelheid van de speler</param>
        /// <param name="horizontaal">Geef aan links of rechts</param>
        internal static void MovePlayer(int speed, bool horizontaal)
        {
            if (horizontaal)
                OlympusTheGame.Playfield.Player.DX = speed;
            else
                OlympusTheGame.Playfield.Player.DY = speed;
        }

        private static void SetKey(ref Keys key, Keys value)
        {
            if (!blockedKeys.Contains(value))
            {
                blockedKeys.Remove(key);
                key = value;
                if(value != Keys.None)
                    blockedKeys.Add(value);
            }
        }
    }
}