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
        /// Entry point of the application.
        /// </summary>
        static void Main()
        {
            // Create non-static object
            OlympusTheGame otg = new OlympusTheGame();

            // Start game
            otg.Start();
        }

        /// <summary>
        /// This variable will keep track of the fact whether closing the game has been requested.
        /// </summary>
        private bool closeRequested = false;


        /// <summary>
        /// This method is called to start the game.
        /// </summary>
        private void Start()
        {
            // Initialize game
            Initialize();

            // Game loop
            while (!closeRequested)
            {
                // Do gameloop step
                GameLoopStep();
            }

            // Clean up everything
            CleanUp();
        }

        /// <summary>
        /// Send this game a request to close itself.
        /// This method should be called instead of force-closing the system to ensure a smooth close.
        /// </summary>
        private void RequestClose()
        {
            // Set close requested parameter
            closeRequested = true;
        }

        /// <summary>
        /// Initialize game, this includes loading resources etc...
        /// </summary>
        private void Initialize()
        {
            // Temporary placeholder
            MessageBox.Show("Welcome to Olympus the Game!\nThe most epic game ever created by students", "Olympus the Game", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 1 step of the game loop. This method will be called untill a close has been requested.
        /// </summary>
        private void GameLoopStep()
        {
            // Stuff that is executed continuously
            this.RequestClose();
        }

        /// <summary>
        /// Clean up all resources.
        /// </summary>
        private void CleanUp()
        {
            // Clean up resources
        }
    }
}
