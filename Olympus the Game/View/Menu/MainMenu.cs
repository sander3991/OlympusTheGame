using Olympus_the_Game.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
                    System.Threading.Thread.Sleep(5); //Er zat een raar plopje dat de volume van het vorige liedje nog aan stond, dit lijkt dat op te lossen.
                    Mp3Player.FadeIn(2000);
                    Mp3Player.SetPosition(27D);
                }
                Mp3Player.PlaySelected();
                firstInit = false;
            }
        }        

        /// <summary>
        /// Laad main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e) {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.CenterToScreen();

            // Add events
            this.mainMenuControl1.ButtonStart.Click += ButtonStart_Click;
            this.mainMenuControl1.ButtonLevelEditor.Click +=ButtonLevelEditor_Click;
            this.mainMenuControl1.ButtonExit.Click += ButtonExit_Click;
            this.VisibleChanged += MainMenu_VisibleChanged;
            this.SizeChanged += delegate(object source, EventArgs ea) { CenterControl(this.mainMenuControl1); };
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

            CenterControl(mainMenuControl1);
            mainMenuControl1.Visible = true;

            pictureBox1.Image = global::Olympus_the_Game.Properties.Resources.loop;
        }

        private void CenterControl(Control c)
        {
            c.Left = (this.Width - c.Width) / 2;
            c.Top = (this.Height - c.Height) / 2;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.FindForm().Visible = false;
            OlympusTheGame.Start();
            this.FindForm().Visible = true;
        }

        private void ButtonLevelEditor_Click(object sender, EventArgs e)
        {
            this.FindForm().Visible = false;
            LevelEditor le = new LevelEditor();
            le.ShowDialog();

            //Martijn - Comment de twee 'le' regels en haal de onderste twee van de comment af

            //LevelDialog ld = new LevelDialog();
            //ld.ShowDialog();
            this.FindForm().Visible = true;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            OlympusTheGame.RequestClose();
        }
    }
}
