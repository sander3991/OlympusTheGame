using Olympus_the_Game.View;
using System;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    class OlympusTheGame
    {
        // Het scherm van het spel
        private GameScreen gs;

        /// <summary>
        /// Deze timer voert alle game events uit.
        /// </summary>
        /// Er is voor een Windows Forms Timer gekozen zodat er geen problemen ontstaan met cross-thread updating in Windows Forms.
        private Timer GameTimer = new Timer();

        /// <summary>
        /// Deze timer voert de SlowEvents uit.
        /// </summary>
        private Timer SlowTimer = new Timer();

        /// <summary>
        /// De instantie van de huidige applicatie, deze variabele kan worden gebruikt om onderdelen op te halen zoals
        /// </summary>
        public static OlympusTheGame INSTANCE { get; private set; }

        /// <summary>
        /// Het huidige speelveld.
        /// </summary>
        public PlayField Playfield { get; private set; }

        /// <summary>
        /// De controller, deze regelt alle events en updates
        /// </summary>
        public Controller Controller { get; private set; }
        
        /// <summary>
        /// Maak nieuw OlympusTheGame object
        /// </summary>
        public OlympusTheGame()
        {
            this.Controller = new Controller();
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
            // Read PlayField
            this.Playfield = PlayFieldToXml.ReadFromResource(Properties.Resources.hell);
            if (this.Playfield == null)
            {
                this.Playfield = new PlayField();
                this.Playfield.InitializeGameObjects();
            }

            // Add gameloop to timer
            GameTimer.Tick += this.Controller.ExecuteUpdateGameEvent;
            GameTimer.Interval = 10;

            // Create slow timer
            SlowTimer.Tick += this.Controller.ExecuteUpdateSlowEvent;
            SlowTimer.Interval = 200;

            // TODO Remove
            Playfield.InitializeGameObjects();

            // Maak gamescreen aan
            gs = new GameScreen();

            // Add PlayField to GameScreen
            gs.gamePanel1.Playfield = this.Playfield;

            // Start timers
            GameTimer.Start();
            SlowTimer.Start();

            // Start applicatie
            Application.Run(gs);
        }

        /// <summary>
        /// Stuur een aanvraag om af te sluiten, deze method moet worden gebruikt
        /// om soepel afsluiten te garanderen.
        /// </summary>
        public void RequestClose()
        {
            // Stop timers
            GameTimer.Stop();
            SlowTimer.Stop();

            // Sluit scherm
            gs.Dispose();
        }
    }
}
