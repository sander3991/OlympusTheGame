using Olympus_the_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    class OlympusTheGame
    {
        // Het scherm van het spel
        private GameScreen gs;

        // de pijltjes toetsen

        
        // Tick counter
        private int startTick = 0;
        private int tickCount = 0;

        public static OlympusTheGame INSTANCE;

        /// <summary>
        /// Beginpunt van de applicatie
        /// </summary>
        static void Main()
        {
            // non-static object aanmaken
            INSTANCE = new OlympusTheGame();

            // Game starten
            INSTANCE.Start();
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
                /**
                 * moet in gameloop
                 * application.run (enige twijfel, nadere verklaring benodigd)
                 * 
                **/

                // Timer update
                tickCount = Environment.TickCount;

                // Refresh at 60FPS
                if(tickCount > startTick + 16)
                {
                    startTick = tickCount;
                }

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
        public void RequestClose()
        {
            // Verander parameter die afsluiten bijhoudt
            closeRequested = true;
        }

        /// <summary>
        /// Initialiseer game, dit is het laden van resources, aanmaken van schermen etc...
        /// </summary>
        private void Initialize()
        {
            // Maak gamescreen aan
            gs = new GameScreen();

            // Laat het scherm zien
            Application.Run(gs);
        }

        /// <summary>
        /// 1 stap van de gameloop, deze wordt achter elkaar uitgevoerd totdat afsluiten wordt aangevraagd.
        /// </summary>
        private void GameLoopStep()
        {
            // Invalidate scherm zodat deze opnieuw wordt getekend
            gs.Invalidate(true);
        }

        /// <summary>
        /// Release alle resources
        /// </summary>
        private void CleanUp()
        {
            // Clean up resources

            // Sluit het scherm
            gs.Dispose();
        }
    }
}
