using Olympus_the_Game.View;
using System;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    public class OlympusTheGame
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
        //TODO Sander: Overleggen over public setter, eventueel hele class Static maken? 
        public static OlympusTheGame INSTANCE { get; set; }

        /// <summary>
        /// Het huidige speelveld.
        /// </summary>
        public PlayField Playfield { get; private set; }

        /// <summary>
        /// De controller, deze regelt alle events en updates
        /// </summary>
        public Controller Controller { get; private set; }

        /// <summary>
        /// Delegate voor het <code>OnNewPlayField</code> event.
        /// </summary>
        /// <param name="Playfield">Het nieuwe Playfield object</param>
        public delegate void NewPlayField(PlayField Playfield);

        /// <summary>
        /// Event dat gefired wordt zodra er een nieuw Playfield is
        /// </summary>
        public event NewPlayField OnNewPlayField;

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
        public static void Main()
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
            this.Playfield.SetPlayerHome();
            if (this.Playfield == null)
            {
                this.Playfield = new PlayField();
                this.Playfield.InitializeGameObjects();
            }

            // Maak gamescreen aan
            gs = new GameScreen();

            // Add gameloop to timer
            GameTimer.Tick += this.Controller.ExecuteUpdateGameEvent;
            GameTimer.Interval = 10;

            // Create slow timer
            SlowTimer.Tick += this.Controller.ExecuteUpdateSlowEvent;
            SlowTimer.Interval = 200;

            // Add PlayField to GameScreen
            gs.gamePanel1.Playfield = this.Playfield;

            // Start timers
            this.Resume();

            // Start applicatie
            Application.Run(gs);
        }

        /// <summary>
        /// Change the playfield
        /// </summary>
        /// <param name="pf"></param>
        public void SetNewPlayfield(PlayField pf)
        {
            if (pf != null)
            {
                Playfield.UnloadPlayField();
                pf.SetPlayerHome();
                this.Playfield = pf;
                if (OnNewPlayField != null)
                    OnNewPlayField(pf);
            }
        }

        /// <summary>
        /// Stops all logic
        /// </summary>
        public void Pause()
        {
            this.GameTimer.Stop();
            this.SlowTimer.Stop();
        }

        /// <summary>
        /// Resumes all logic
        /// </summary>
        public void Resume()
        {
            this.GameTimer.Start();
            this.SlowTimer.Start();
        }

        /// <summary>
        /// Stuur een aanvraag om af te sluiten, deze method moet worden gebruikt
        /// om soepel afsluiten te garanderen.
        /// </summary>
        public void RequestClose()
        {
            // Pause game
            this.Pause();

            // Sluit scherm
            gs.Dispose();
        }
    }
}
