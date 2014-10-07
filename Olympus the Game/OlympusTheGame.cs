using Olympus_the_Game.View;
using System;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    public class OlympusTheGame
    {
        // Het scherm van het spel
        private static MainMenu mm;

        /// <summary>
        /// Deze timer voert alle game events uit.
        /// </summary>
        /// Er is voor een Windows Forms Timer gekozen zodat er geen problemen ontstaan met cross-thread updating in Windows Forms.
        private static Timer GameTimer = new Timer();

        /// <summary>
        /// Deze timer voert de SlowEvents uit.
        /// </summary>
        private static Timer SlowTimer = new Timer();

        /// <summary>
        /// De instantie van de huidige applicatie, deze variabele kan worden gebruikt om onderdelen op te halen zoals
        /// </summary>

        /// <summary>
        /// Het huidige speelveld.
        /// </summary>
        public static PlayField Playfield { get; private set; }

        /// <summary>
        /// De controller, deze regelt alle events en updates
        /// </summary>
        public static Controller Controller { get; private set; }


        /// <summary>
        /// Event dat gefired wordt zodra er een nieuw Playfield is
        /// </summary>
        public static event Action<PlayField> OnNewPlayField;

        /// <summary>
        /// Maak nieuw OlympusTheGame object
        /// </summary>
        private OlympusTheGame(){}

        /// <summary>
        /// Beginpunt van de applicatie
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // non-static object aanmaken
            SetController();
            mm = new MainMenu();
            Application.Run(mm);
        }

        public static void SetController()
        {
            if (Controller == null)
                Controller = new Controller();
        }

        /// <summary>
        /// Deze methode wordt aangeroepen om de game te starten.
        /// </summary>
        public static void Start()
        {
            // Read PlayField
            Playfield = PlayFieldToXml.ReadFromResource(Properties.Resources.hell);
            Playfield.SetPlayerHome();
            if (Playfield == null)
            {
                Playfield = new PlayField();
                Playfield.InitializeGameObjects();
            }

            // Maak gamescreen aan
            GameScreen gs = new GameScreen();

            // Add gameloop to timer
            GameTimer.Tick += Controller.ExecuteUpdateGameEvent;
            GameTimer.Interval = 10;

            // Create slow timer
            SlowTimer.Tick += Controller.ExecuteUpdateSlowEvent;
            SlowTimer.Interval = 200;

            // Add PlayField to GameScreen
            gs.gamePanel1.Playfield = Playfield;

            // Start timers
            Resume();

            // Start applicatie
            gs.ShowDialog();
        }

        /// <summary>
        /// Change the playfield
        /// </summary>
        /// <param name="pf"></param>
        public static void SetNewPlayfield(PlayField pf)
        {
            if (pf != null)
            {
                if(Playfield != null)
                    Playfield.UnloadPlayField();
                pf.SetPlayerHome();
                Playfield = pf;
                if (OnNewPlayField != null)
                    OnNewPlayField(pf);
            }
        }

        /// <summary>
        /// Stops all logic
        /// </summary>
        public static void Pause()
        {
            GameTimer.Stop();
            SlowTimer.Stop();
        }

        /// <summary>
        /// Resumes all logic
        /// </summary>
        public static void Resume()
        {
            GameTimer.Start();
            SlowTimer.Start();
        }

        /// <summary>
        /// Stuur een aanvraag om af te sluiten, deze method moet worden gebruikt
        /// om soepel afsluiten te garanderen.
        /// </summary>
        public static void RequestClose()
        {
            // Pause game
            Pause();

            // Sluit scherm
            mm.Dispose();
        }
    }
}
