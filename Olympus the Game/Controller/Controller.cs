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
        
        public static Mp3Player MusicPlayer = new Mp3Player();
        /// <summary>
        /// Deze wordt gebruikt voor alle game events
        /// </summary>
        public event Action UpdateGameEvents;

        /// <summary>
        /// Deze wordt gebruikt voor alle events die niet zo vaak hoeven te gebeuren, zoals updaten statistiek etc.
        /// </summary>
        public event Action UpdateSlowEvents;

        /// <summary>
        /// Laatste update van de AI
        /// </summary>
        private long lastAIUpdate = -1;

        /// <summary>
        /// De tijd tussen 2 AI updates
        /// </summary>
        private long AIUpdateInterval = 1000;

        /// <summary>
        /// Genereert een nieuwe Controller
        /// </summary>
        public Controller()
        {
            // Add Update to UpdateEvents
            UpdateGameEvents += Update;

            // Add AIUpdate to UpdateEvents
            UpdateGameEvents += UpdateEntityAI;

        }

        /// <summary>
        /// Update alle game entities naar hun volgende state. Doet een Move() voor elke entity (including Player), en doet de Collision Detection en de OnCollide.
        /// </summary>
        public void Update()
        {
            EntityPlayer player = OlympusTheGame.Playfield.Player;
            player.Move();
            List<GameObject> gameObjects = new List<GameObject>(OlympusTheGame.Playfield.GameObjects); //Er wordt een nieuwe lijst van gemaakt, omdat bij de oncollide er dingen uit de originele lijst kunnen verdwijnen
            foreach (GameObject o in gameObjects) //Controleer of de player collide met een GameObject
            {
                CollisionType collision = player.CollidesWithObject(o);
                if (collision != CollisionType.NONE) //Als er een collision is (dus niet 'geen' collision)
                {
                    if (o.IsSolid) //Alleen bij solide blokken moet de speler terug worden gezet naar de vorige plek
                    {
                        if(collision.HasFlag(CollisionType.X))
                            player.X = player.PreviousX;
                        if(collision.HasFlag(CollisionType.Y))
                            player.Y = player.PreviousY;
                    }
                    o.OnCollide(player); //Roept de OnCollide van het object aan om te kijken wat er moet gebeuren, de Speler heeft nooit een OnCollide, dus dat is overbodig
                }
            }
            List<GameObject> listWithPlayer = new List<GameObject>(gameObjects); //Maak een lijst waar de player ook bij in zit
            listWithPlayer.Add(player);
            foreach (GameObject o in gameObjects) //Loop door de lijst met GameObjects heen, niet die met de speler want de speler is al gecontroleerd
            {
                Entity e = o as Entity;
                if (e != null) //Controleer of het een Entity is, alleen entities dienen geupdate te worden
                {
                    e.Move();
                    foreach (GameObject o2 in listWithPlayer)
                    {
                        if(!e.Equals(o2)) //We kunnen dezelfde entity tegenkomen, dus controleer of we niet vergelijken met onszelf, dat is nutteloos!
                        {
                            CollisionType collision = e.CollidesWithObject(o2); //Is er een collision
                            if (collision != CollisionType.NONE)
                            {
                                e.OnCollide(o2); //Bij een collision voor beide objecten de OnCollide aanroepen, we weten niet welke van de twee functionaliteit heeft
                                o2.OnCollide(e);
                                if(collision.HasFlag(CollisionType.X)) //Is de collision op de X as? Verander dan de X.
                                    e.X = e.PreviousX;
                                if(collision.HasFlag(CollisionType.Y)) //Is de collison op de Y as? Verander dan de Y
                                    e.Y = e.PreviousY;
                                if (e.EntityControlledByAI) //Als wij de entity besturen, willen we de entity de andere kant op laten lopen zodat hij niet blijft colliden
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



        /// <summary>
        /// Deze wordt aangeroepen om de AI te updaten. Elke iteratie wordt er opnieuw bepaald waar elke entity heen moet lopen.
        /// </summary>
        public void UpdateEntityAI()
        {
            // Scale down to 1 second
            if (OlympusTheGame.GameTime < lastAIUpdate) lastAIUpdate = -1;
            if (lastAIUpdate != -1 && OlympusTheGame.GameTime < lastAIUpdate + AIUpdateInterval) return;
            lastAIUpdate = OlympusTheGame.GameTime;

            Random rand = new Random(); //Maakt een random generator
            List<GameObject> gameObjects = OlympusTheGame.Playfield.GameObjects;
            foreach (GameObject o in gameObjects)
            {
                Entity e = o as Entity;
                if (e != null) //Is het een entity? Alleen entities moeten geupdate worden
                {
                    if (e.EntityControlledByAI) // Word hij door de AI bestuurd?
                    {
                        e.DX = rand.Next(3) - 1; //Pak een random int tussen 0 en 2, en verlaag het dan met 1 zodat we tussen -1 en 1 zitten.
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

        /// <summary>
        /// Returned de speelduur van de huidige map.
        /// </summary>
        public string GetTimeSinceStart()
        {
            long gt = OlympusTheGame.GameTime;
            int sec = (int)(gt / 1000);
            int minutes = sec / 60;
            int seconds = sec - minutes * 60;

            return string.Format("{0}{1}:{2}{3}", minutes < 10 ? "0" : "", minutes, seconds < 10 ? "0" : "", seconds);
        }

    }
}
