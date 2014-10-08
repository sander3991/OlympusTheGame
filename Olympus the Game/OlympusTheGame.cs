using Olympus_the_Game.View;
using System;
using System.Diagnostics;
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
        /// Deze houdt de interne tijd bij.
        /// </summary>
        private static Stopwatch prop_gametime = new Stopwatch();

        /// <summary>
        /// Het huidige speelveld.
        /// </summary>
        public static PlayField Playfield { get; set; }

        /// <summary>
        /// De controller, deze regelt alle events en updates
        /// </summary>
        public static Controller Controller { get; private set; }

        /// <summary>
        /// Geeft aan of het spel gepauzeerd is.
        /// </summary>
        public static bool IsPaused
        {
            get
            {
                return !GameTimer.Enabled;
            }
        }

        /// <summary>
        /// Geeft de gametijd terug.
        /// </summary>
        public static long GameTime
        {
            get
            {
                return prop_gametime.ElapsedMilliseconds;
            }
            set
            {
                if (value == 0)
                    prop_gametime.Reset();
            }
        }

        /// <summary>
        /// Event dat gefired wordt zodra er een nieuw Playfield is
        /// </summary>
        public static event Action<PlayField> OnNewPlayField;

        /// <summary>
        /// Maak nieuw OlympusTheGame object
        /// </summary>
        private OlympusTheGame() { }

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

            // Add gameloop to timer
            GameTimer.Tick += Controller.ExecuteUpdateGameEvent;
            GameTimer.Interval = 10;

            // Create slow timer
            SlowTimer.Tick += Controller.ExecuteUpdateSlowEvent;
            SlowTimer.Interval = 200;
        }

        /// <summary>
        /// Change the playfield
        /// </summary>
        /// <param name="pf"></param>
        public static void SetNewPlayfield(PlayField pf)
        {
            if (pf != null)
            {
                if (Playfield != null)
                    Playfield.UnloadPlayField();
                pf.SetPlayerHome();
                Playfield = pf;
                Playfield.InitializeGameObjects();
                if (OnNewPlayField != null)
                    OnNewPlayField(pf);
            }
        }

        /// <summary>
        /// Stops all logic
        /// </summary>
        public static void Pause()
        {
            prop_gametime.Stop();
            GameTimer.Stop();
            SlowTimer.Stop();
        }

        /// <summary>
        /// Resumes all logic
        /// </summary>
        public static void Resume()
        {
            prop_gametime.Start();
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

            // Sluit de MP3 speler af en verwijder bestanden
            Mp3Player.StopPlaying();
        }
    }
}
