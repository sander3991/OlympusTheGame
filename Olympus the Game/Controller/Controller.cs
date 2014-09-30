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
        public delegate void UpdateEvent();
        public event UpdateEvent UpdateEvents;

        public Controller(PlayField pf)
        {
            this.PlayField = pf;
        }
        /// <summary>
        /// Stuurt informatie door als de gebruiker op een toets heeft geklikt.
        /// </summary>
        /// <param name="e"></param>
        public void OnKeyDown(KeyEventArgs e)
        {
            // Kijk of de gebruiker standaard besturings toetsen invoert
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S) 
            {
                MovePlayer(e, OlympusTheGame.INSTANCE.Playfield.gameSpeed);
            }
        }
        /// <summary>
        /// Stuurt informatie door als de gebruiker een toets loslaat.
        /// </summary>
        /// <param name="e"></param>
        public void OnKeyUp(KeyEventArgs e)
        {
            // Kijk of de speler de standaard besturings toetsen loslaat
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.A || e.KeyCode == Keys.D ||
                e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                // Zet dan de speed op 0
                MovePlayer(e, 0);
            }
            else
            {
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
                OlympusTheGame.INSTANCE.Playfield.Player.DX = -speed;
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = speed;
            // Toetsen voor naar boven en naar beneden.
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                OlympusTheGame.INSTANCE.Playfield.Player.DY = -speed;
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                OlympusTheGame.INSTANCE.Playfield.Player.DY = speed;
        }

        /// <summary>
        /// Beweeg de speler op het scherm
        /// Geef aan of deze beweging horizontaal moet zijn
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="horizontaal"></param>
        public void MovePlayer(int speed, bool horizontaal)
        {
            if (horizontaal)
                OlympusTheGame.INSTANCE.Playfield.Player.DX = speed;
            else
                OlympusTheGame.INSTANCE.Playfield.Player.DY = speed;
        }

        public void Update()
        {
            EntityPlayer player = PlayField.Player;
            player.Move();
            List<GameObject> gameObjects = PlayField.GetObjects();
            foreach (GameObject o in gameObjects)
            {
                if (player.CollidesWithObject(o))
                {
                    o.OnCollide(player);
                    if (o.IsSolid)
                    {
                        player.X = player.PreviousX;
                        player.Y = player.PreviousY;
                    }
                }
            }
            foreach (GameObject o in gameObjects)
            {
                Entity e = o as Entity;
                if (e != null)
                    e.Move();
            }
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEntityAI()
        {
            Random rand = new Random();
            List<GameObject> gameObjects = PlayField.GetObjects();
            foreach (GameObject o in gameObjects)
            {
                Entity e = o as Entity;
                if (e != null)
                {
                    if (e.EntityControlledByAI)
                    {
                        e.DX = rand.Next(3) - 1;
                        e.DY = rand.Next(3) - 1;
                    }
                }
            }
            if(UpdateEvents != null)
                UpdateEvents();
        }


        
    }
}
