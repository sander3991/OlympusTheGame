using Olympus_the_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlympusTheGame
{
    class OlympusTheGame
    {
        // Het scherm van het spel
        private GameScreen gs;

        /// <summary>
        /// Beginpunt van de applicatie
        /// </summary>
        static void Main()
        {
            // non-static object aanmaken
            OlympusTheGame otg = new OlympusTheGame();

            // Game starten
            otg.Start();
        }

        /// <summary>
        /// Deze variabele houdt bij of er aanvraag is geweest om af te sluiten.
        /// </summary>
        private bool closeRequested = false;


        /// <summary>
        /// Deze methode wordt aangeroepen om de game te starten.
        /// </summary>
        private void Start()
        {
            // Initialize game
            Initialize();

            // Game loop
            while (!closeRequested)
            {
                // Gameloop step
                GameLoopStep();
            }

            // Clean up
            CleanUp();
        }

        /// <summary>
        /// Stuur een aanvraag om af te sluiten, deze method moet worden gebruikt
        /// om soepel afsluiten te garanderen.
        /// </summary>
        private void RequestClose()
        {
            // Verander parameter die afsluiten bijhoudt
            closeRequested = true;
        }

        /// <summary>
        /// Initialiseer game, dit is het laden van resources, aanmaken van schermen etc...
        /// </summary>
        private void Initialize()
        {
            // Laat het scherm zien
            gs = new GameScreen();
            gs.Show();
        }

        /// <summary>
        /// 1 stap van de gameloop, deze wordt achter elkaar uitgevoerd totdat afsluiten wordt aangevraagd.
        /// </summary>
        private void GameLoopStep()
        {
            // Deze hier laten, deze regelt afhandeling van de GUI, anders blokkeert het scherm
            Application.DoEvents();
        }

        /// <summary>
        /// Release alle resources
        /// </summary>
        private void CleanUp()
        {
            // Clean up resources

            // Sluit het scherm
            gs.Close();
        }
    }
}
