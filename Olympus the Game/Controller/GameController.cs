using System;
using System.Collections.Generic;
using Olympus_the_Game.Model;
using Olympus_the_Game.Model.Entities;

namespace Olympus_the_Game.Controller
{
    public enum FinishType
    {
        Dead,
        Cake,
    }

    public class GameController
    {
        /// <summary>
        /// Delegate voor het <code>OnPlayerFinished</code> event
        /// </summary>
        /// <param name="type">Het type finish</param>
        public delegate void DelOnFinish(FinishType type);

        /// <summary>
        /// Delegate voor het <code>OnHealthChanged</code> event
        /// </summary>
        /// <param name="player">De entity waarvan de health veranderd is</param>
        public delegate void DelOnHealthChanged(EntityPlayer player, int newHealth, int prevHealth);

        /// <summary>
        /// De tijd tussen 2 AI updates
        /// </summary>
        private const long AiUpdateInterval = 1000;

        /// <summary>
        /// Laatste update van de AI
        /// </summary>
        private long _lastAiUpdate = -1;

        /// <summary>
        /// Genereert een nieuwe GameController
        /// </summary>
        public GameController()
        {
            // Add Update to UpdateEvents
            UpdateGameEvents += Update;

            // Add AIUpdate to UpdateEvents
            UpdateGameEvents += UpdateEntityAi;

            // Registreert de health update event aan de controller
            OnHealthChanged += Player_OnHealthChanged;
        }

        /// <summary>
        /// Event dat gedraait woordt zodra een <code>EntityPlayer</code> object zijn health is veranderd.
        /// </summary>
        public event DelOnHealthChanged OnHealthChanged;

        /// <summary>
        /// Wordt aangeroepen zodra een speler finished
        /// </summary>
        public event DelOnFinish OnPlayerFinished;

        /// <summary>
        /// Deze wordt gebruikt voor alle game events
        /// </summary>
        public event Action UpdateGameEvents;

        /// <summary>
        /// Deze wordt gebruikt voor alle events die niet zo vaak hoeven te gebeuren, zoals updaten statistiek etc.
        /// </summary>
        public event Action UpdateSlowEvents;

        /// <summary>
        /// Als de health van de speler is veranderd
        /// </summary>
        /// <param name="player"></param>
        /// <param name="newHealth"></param>
        /// <param name="prevHealth"></param>
        private void Player_OnHealthChanged(EntityPlayer player, int newHealth, int prevHealth)
        {
            if (newHealth == 0)
            {
                OlympusTheGame.Pause();
                if (OnPlayerFinished != null)
                    OnPlayerFinished(FinishType.Dead); //TODO add score hier
            }
        }

        public void OnPlayerReachedCake()
        {
            OlympusTheGame.Pause();
            Scoreboard.AddScore(ScoreType.GameFinished, 10000);
            int gameTime = Convert.ToInt32(OlympusTheGame.GameTime/1000 - 30);
                //Haalt de gametime in seconde op minus de 30 seconde waarvoor je geen minpunten krijgt
            Scoreboard.AddScore(ScoreType.Time, Math.Min(0, gameTime*-10));
            Scoreboard.AddScore(ScoreType.Health, OlympusTheGame.Playfield.Player.Health*200);
            if (OnPlayerFinished != null)
                OnPlayerFinished(FinishType.Cake);
        }

        /// <summary>
        /// Update alle game entities naar hun volgende state. Doet een Move() voor elke entity (including Player), en doet de Collision Detection en de OnCollide.
        /// </summary>
        public void Update()
        {
            List<GameObject> playerCollisisons = new List<GameObject>();
            EntityPlayer player = OlympusTheGame.Playfield.Player;
            player.Move();
            List<GameObject> gameObjects = new List<GameObject>(OlympusTheGame.Playfield.GameObjects);
                //Er wordt een nieuwe lijst van gemaakt, omdat bij de oncollide er dingen uit de originele lijst kunnen verdwijnen
            foreach (GameObject o in gameObjects) //Controleer of de player collide met een GameObject
            {
                CollisionType collision = player.CollidesWithObject(o);
                if (collision != CollisionType.NONE) //Als er een collision is (dus niet 'geen' collision)
                {
                    if (o.IsSolid) //Alleen bij solide blokken moet de speler terug worden gezet naar de vorige plek
                    {
                        if (collision.HasFlag(CollisionType.X))
                            player.X = player.PreviousX;
                        if (collision.HasFlag(CollisionType.Y))
                            player.Y = player.PreviousY;
                    }
                    o.OnCollide(player);
                        //Roept de OnCollide van het object aan om te kijken wat er moet gebeuren, de Speler heeft nooit een OnCollide, dus dat is overbodig
                    playerCollisisons.Add(o);
                        //We houden bij met wie de player is gecollide, zodat we niet nog een keer in de volgende loop de OnCollide aanroepen
                }
            }
            List<GameObject> listWithPlayer = new List<GameObject>(gameObjects);
                //Maak een lijst waar de player ook bij in zit
            listWithPlayer.Add(player);
            foreach (GameObject o in gameObjects)
                //Loop door de lijst met GameObjects heen, niet die met de speler want de speler is al gecontroleerd
            {
                Entity e = o as Entity;
                if (e != null) //Controleer of het een Entity is, alleen entities dienen geupdate te worden
                {
                    e.Move();
                    foreach (GameObject o2 in listWithPlayer)
                    {
                        if (!e.Equals(o2))
                            //We kunnen dezelfde entity tegenkomen, dus controleer of we niet vergelijken met onszelf, dat is nutteloos!
                        {
                            CollisionType collision = e.CollidesWithObject(o2); //Is er een collision
                            if (collision != CollisionType.NONE)
                            {
                                if (!(playerCollisisons.Contains(e) && o2 == player))
                                    //Alleen als e in de lijst zit, en o2 de speler is, word de code NIET uitgevoerd
                                {
                                    e.OnCollide(o2);
                                        //Bij een collision voor beide objecten de OnCollide aanroepen, we weten niet welke van de twee functionaliteit heeft
                                    o2.OnCollide(e);
                                }
                                if (collision.HasFlag(CollisionType.X)) //Is de collision op de X as? Verander dan de X.
                                    e.X = e.PreviousX;
                                if (collision.HasFlag(CollisionType.Y)) //Is de collison op de Y as? Verander dan de Y
                                    e.Y = e.PreviousY;
                                if (e.EntityControlledByAi)
                                    //Als wij de entity besturen, willen we de entity de andere kant op laten lopen zodat hij niet blijft colliden
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
        public void UpdateEntityAi()
        {
            // Scale down to 1 second
            if (OlympusTheGame.GameTime < _lastAiUpdate) _lastAiUpdate = -1;
            if (_lastAiUpdate != -1 && OlympusTheGame.GameTime < _lastAiUpdate + AiUpdateInterval) return;
            _lastAiUpdate = OlympusTheGame.GameTime;

            Random rand = new Random(); //Maakt een random generator
            List<GameObject> gameObjects = OlympusTheGame.Playfield.GameObjects;
            foreach (GameObject o in gameObjects)
            {
                Entity e = o as Entity;
                if (e != null) //Is het een entity? Alleen entities moeten geupdate worden
                {
                    if (e.EntityControlledByAi) // Word hij door de AI bestuurd?
                    {
                        e.DX = rand.Next(3) - 1;
                            //Pak een random int tussen 0 en 2, en verlaag het dan met 1 zodat we tussen -1 en 1 zitten.
                        e.DY = rand.Next(3) - 1;
                    }
                }
            }
        }

        /// <summary>
        /// Execute the UpdateGameEvent in the GameController, this method should only be called from within OlympusTheGame.
        /// </summary>
        public void ExecuteUpdateGameEvent(object source, EventArgs ea)
        {
            if (UpdateGameEvents != null)
                UpdateGameEvents();
        }

        /// <summary>
        /// Executes the UpdateSlowEvent in the GameController, this method should only be called from within OlympusTheGame.
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
            int sec = (int) (gt/1000);
            int minutes = sec/60;
            int seconds = sec - minutes*60;
            return string.Format("{0}:{1}", minutes.ToString("D2"), seconds.ToString("D2"));
        }

        internal void PlayerHealthChanged(EntityPlayer player, int newHealth, int prevHealth)
        {
            if (OnHealthChanged != null)
                OnHealthChanged(player, newHealth, prevHealth);
        }
    }
}