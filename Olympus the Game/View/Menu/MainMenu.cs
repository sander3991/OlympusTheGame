using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    /// <summary>
    /// Mainmenu form
    /// Bevat onderandere een control met buttons
    /// Splashscreen magic happens here
    /// </summary>
    public partial class MainMenu : Form
    {
        // Timer die gebruikt word voor het afspelen van splashscreen.gif
        Timer gifTimer = new Timer();
        private bool firstInit = true;
        public MainMenu()
        {
            // Boolean waarmee gekeken kan worden of did de eerste keer is dat 
            // de splashscreen word weergeven of niet
            bool gifState = true;

            InitializeComponent();

            // Zorg ervoor dat tijdens de splashscreen geen buttons in scherm zijn
            mainMenuControl1.Visible = false;

            // Maak nieuw eventhandler aan voor timer tick
            this.gifTimer.Tick += new EventHandler(Timer_Tick);
            if (gifState == true)
            {
                // Interval is ~ongeveer 4 seconden.
                // Hangt een beetje af van snelheid van computer
                gifTimer.Interval = 4000;
                gifTimer.Start();
                gifState = false;
            }
            this.VisibleChanged += MainMenu_VisibleChanged;
        }
        /// <summary>
        /// Wordt aangeroepen zodra de visibility van het MainMenu veranderd, als dat gebeurd willen we het StarWars muziekje weer laten spelen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
            {
                Mp3Player.StopPlaying();
                Mp3Player.SetResource(Properties.Resources.StarWars);
                if (!firstInit)
                {
                    System.Threading.Thread.Sleep(1); //Er zat een raar plopje dat de volume van het vorige liedje nog aan stond, dit lijkt dat op te lossen.
                    Mp3Player.FadeIn(2000);
                    Mp3Player.SetPosition(27D);
                }
                Mp3Player.PlaySelected();
                firstInit = false;
            }
        }        

        private void MainMenu_Load(object sender, EventArgs e) {
            mainMenuControl1.Left = (this.ClientSize.Width - mainMenuControl1.Width) / 2;
            mainMenuControl1.Top = (this.ClientSize.Height - mainMenuControl1.Height) / 2;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.CenterToScreen();
        }

        /// <summary>
        /// Als de 4 seconden voorbij zijn van de gifTimer dan word
        /// deze functie aangeroepen die ervoor zorgt dat de achtergrond
        /// veranderd in een seemless looping starburst gif, en het menu
        /// weergeven word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            gifTimer.Stop();
            mainMenuControl1.Visible = true;
            pictureBox1.Image = global::Olympus_the_Game.Properties.Resources.loop;
        }

    }
}
