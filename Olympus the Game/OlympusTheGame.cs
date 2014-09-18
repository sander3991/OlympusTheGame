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
            // Temporary placeholder
            MessageBox.Show("Welcome to Olympus the Game!\nThe most epic game ever created by students", "Olympus the Game", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 1 stap van de gameloop, deze wordt achter elkaar uitgevoerd totdat afsluiten wordt aangevraagd.
        /// </summary>
        private void GameLoopStep()
        {
            // Temporary placeholder, anders blijft loop oneindig draaien
            this.RequestClose();
        }

        /// <summary>
        /// Release alle resources
        /// </summary>
        private void CleanUp()
        {
            // Clean up resources
        }
    }
}
