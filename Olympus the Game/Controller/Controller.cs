﻿using System;
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
        /// <summary>
        /// Deze wordt gebruikt voor alle game events
        /// </summary>
        public event Action UpdateGameEvents;

        /// <summary>
        /// Deze wordt gebruikt voor alle events die niet zo vaak hoeven te gebeuren, zoals updaten statistiek etc.
        /// </summary>
        public event Action UpdateSlowEvents;
        
       
        public int CustomRight { get; set; }
        public int CustomLeft { get; set; }
        public int CustomUp { get; set; }
        public int CustomDown { get; set; }
         
        public Controller(PlayField pf)
        {
            // Add Update to UpdateEvents
            UpdateGameEvents += Update;

            // Add AIUpdate to UpdateEvents
            UpdateGameEvents += UpdateEntityAI;

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
                // Geef de speed van 1 mee
                MovePlayer(e, 2);
            }
            else
            {
                CustomMovePlayer(e, 2);
            }
            
        }

        private void CustomMovePlayer(KeyEventArgs e, int speed)
        {
            if (e.KeyValue == CustomRight)
                MovePlayer(speed, true);

            else if (e.KeyValue == CustomLeft)
                MovePlayer(-speed, true);

            else if (e.KeyValue == CustomDown)
                MovePlayer(speed, false);

            else if (e.KeyValue == CustomUp)
                MovePlayer(-speed, false);
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
                CustomMovePlayer(e , 0);
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
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            player.Move();
            List<GameObject> gameObjects = OlympusTheGame.INSTANCE.Playfield.GetObjects();
            foreach (GameObject o in gameObjects)
            {
                if (player.CollidesWithObject(o))
                {
                    if (o.IsSolid)
                    {
                        player.X = player.PreviousX;
                        player.Y = player.PreviousY;
                    }
                    o.OnCollide(player);
                }
            }
            List<GameObject> listWithPlayer = new List<GameObject>(gameObjects);
            listWithPlayer.Add(player);
            foreach (GameObject o in gameObjects)
            {
                Entity e = o as Entity;
                if (e != null)
                {
                    e.Move();
                    foreach (GameObject o2 in listWithPlayer)
                    {
                        if(!e.Equals(o2) && e.CollidesWithObject(o2))
                        {
                            e.OnCollide(o2);
                            o2.OnCollide(e);
                            e.X = e.PreviousX;
                            e.Y = e.PreviousY;
                            if (e.EntityControlledByAI)
                            {
                                e.DX = -e.DX;
                                e.DY = -e.DY;
                            }
                        }
                    }
                }
            }
        }

        public void UpdateEntityAI()
        {
            if (Environment.TickCount % 1000 != 0) return; // TODO Dit beter afhandelen
            Random rand = new Random();
            List<GameObject> gameObjects = OlympusTheGame.INSTANCE.Playfield.GetObjects();
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
        }

        /// <summary>
        /// Execute the UpdateGameEvent in the Controller, this method should only be called from within OlympusTheGame.
        /// </summary>
        public void ExecuteUpdateGameEvent(object source, EventArgs ea)
        {
            if (UpdateGameEvents != null)
                UpdateGameEvents();
        }

        /// <summary>
        /// Executes the UpdateSlowEvent in the Controller, this method should only be called from within OlympusTheGame.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ea"></param>
        public void ExecuteUpdateSlowEvent(object source, EventArgs ea)
        {
            if (UpdateSlowEvents != null)
                UpdateSlowEvents();
        }
    }
}
