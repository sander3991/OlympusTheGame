using Olympus_the_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Olympus_the_Game
{
    class OlympusTheGame
    {

        private delegate void InvalidateDelegate(bool b);

        // Het scherm van het spel
        private GameScreen gs;

        private System.Timers.Timer timer = new System.Timers.Timer();

        // Tick counter
        private int startTick = 0;
        private int tickCount = 0;

        /// <summary>
        /// De instantie van de huidige applicatie, deze variabele kan worden gebruikt om onderdelen op te halen zoals
        /// </summary>
        public static OlympusTheGame INSTANCE { get; private set; }
        public PlayField Playfield { get; private set; }
        public Controller Controller { get; private set; }
        
        /// <summary>
        /// Maak nieuw OlympusTheGame object
        /// </summary>
        public OlympusTheGame()
        {
            // TODO Verwijderen
            this.Playfield = new PlayField(1000, 500);
            this.Controller = new Controller(this.Playfield);
            
        }

        /// <summary>
        /// Beginpunt van de applicatie
        /// </summary>
        [STAThread]
        static void Main()
        {
            // non-static object aanmaken
            INSTANCE = new OlympusTheGame();

            // Game starten
            INSTANCE.Start();
        }

        /// <summary>
        /// Deze methode wordt aangeroepen om de game te starten.
        /// </summary>
        private void Start()
        {
            // Add gameloop to timer
            timer.Elapsed += new ElapsedEventHandler(GameLoopStep);
            timer.Interval = 10;

            // TODO Remove
            Playfield.InitializeGameObjects();

            // Maak gamescreen aan
            gs = new GameScreen();

            // Start timer
            timer.Start();

            // Start applicatie
            Application.Run(gs);
        }

        /// <summary>
        /// Stuur een aanvraag om af te sluiten, deze method moet worden gebruikt
        /// om soepel afsluiten te garanderen.
        /// </summary>
        public void RequestClose()
        {
            // Stop timer
            timer.Stop();
        }

        /// <summary>
        /// 1 stap van de gameloop, deze wordt achter elkaar uitgevoerd totdat afsluiten wordt aangevraagd.
        /// </summary>  
        private void GameLoopStep(object source, ElapsedEventArgs e)
        {
            // Timer update
            tickCount = Environment.TickCount;
            // Refresh at 60FPS
            if (tickCount > startTick + 16)
            {
                startTick = tickCount;
            }

            // Controller update
            Controller.Update();

            if (tickCount % 1000 == 0)
                Controller.UpdateEntityAI();
        }
    }
}
