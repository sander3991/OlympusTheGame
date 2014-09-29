using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game
    
{
    public class Controller
    {
        public PlayField PlayField { get; private set; }

        public Controller(PlayField pf)
        {
            this.PlayField = pf;
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            // Kijk of de gebruiker standaard besturings toetsen invoert
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S) 
            {
                // Geef de speed van 1 mee
                MovePlayer(e, 1);
            }
                
        }

        public void OnKeyUp(KeyEventArgs e)
        {
            // Kijk of de speler de standaard besturings toetsen loslaat
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                // Zet dan de speel op 0
                MovePlayer(e, 0);
            }
            
        }

        /// <summary>
        ///  Beweeg de speler met toetsen die zijn toegewezen
        /// </summary>
        /// <param name="e"></param>
        /// <param name="speed"></param>
        private void MovePlayer(KeyEventArgs e, int speed)
        {
            // Toetsen voor naar links en naar rechts.
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                OlympusTheGame.INSTANCE.pf.Player.DX = -speed;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                OlympusTheGame.INSTANCE.pf.Player.DX = speed;
            // Toetsen voor naar boven en naar beneden.
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                OlympusTheGame.INSTANCE.pf.Player.DY = -speed;
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                OlympusTheGame.INSTANCE.pf.Player.DY = speed;
            
        }

        // Beweeg de speler met de toetsen op het scherm
        internal void MovePlayer(object sender)
        {
            MessageBox.Show(sender.ToString());
        }

        public void Update()
        {
            PlayField.Player.Move();
            foreach(GameObject o in PlayField.GetObjects()){
                Entity e = o as Entity;
                if (e != null)
                {
                    e.Move();
                }
            }
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }



        
    }
}
