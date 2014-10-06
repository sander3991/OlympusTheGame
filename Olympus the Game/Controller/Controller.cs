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
    public class Controller
    {
        // Timer voor het bepalen van de speelduur.
        Stopwatch stopWatch = Stopwatch.StartNew();
        /// <summary>
        /// Deze wordt gebruikt voor alle game events
        /// </summary>
        public event Action UpdateGameEvents;

        /// <summary>
        /// Deze wordt gebruikt voor alle events die niet zo vaak hoeven te gebeuren, zoals updaten statistiek etc.
        /// </summary>
        public event Action UpdateSlowEvents;

        // TODO Sander: Commentaar
        public Controller()
        {
            // Add Update to UpdateEvents
            UpdateGameEvents += Update;

            // Add AIUpdate to UpdateEvents
            UpdateGameEvents += UpdateEntityAI;

        }

        public void Update() //TODO Sander: Comments bij toevoegen
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            player.Move();
            List<GameObject> gameObjects = new List<GameObject>(OlympusTheGame.INSTANCE.Playfield.GameObjects); //Er wordt een nieuwe lijst van gemaakt, omdat bij de oncollide er dingen uit de originele lijst kunnen verdwijnen
            foreach (GameObject o in gameObjects)
            {
                CollisionType collision = player.CollidesWithObject(o);
                if (collision != CollisionType.NONE)
                {
                    if (o.IsSolid)
                    {
                        if(collision.HasFlag(CollisionType.X))
                            player.X = player.PreviousX;
                        if(collision.HasFlag(CollisionType.Y))
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
                        if(!e.Equals(o2))
                        {
                            CollisionType collision = e.CollidesWithObject(o2);
                            if (collision != CollisionType.NONE)
                            {
                                e.OnCollide(o2);
                                o2.OnCollide(e);
                                if(collision.HasFlag(CollisionType.X))
                                    e.X = e.PreviousX;
                                if(collision.HasFlag(CollisionType.Y))
                                    e.Y = e.PreviousY;
                                if (e.EntityControlledByAI)
                                {
                                    if (collision.HasFlag(CollisionType.X))
                                        e.DX = -e.DX;
                                    if (collision.HasFlag(CollisionType.Y))
                                        e.DY = -e.DY;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void UpdateEntityAI() // TODO Sander: Commentaar toevoegen
        {
            if (Environment.TickCount % 1000 != 0) return; // TODO Dit beter afhandelen
            Random rand = new Random();
            List<GameObject> gameObjects = OlympusTheGame.INSTANCE.Playfield.GameObjects;
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
        //TODO Elmar: Commentaar
        public string GetTimeSinceStart()
        {
            return stopWatch.Elapsed.Minutes.ToString("D2") + ":" + stopWatch.Elapsed.Seconds.ToString("D2");
        }

    }
}
