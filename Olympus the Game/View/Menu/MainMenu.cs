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

        private bool openGame = true;

        private GameScreen gs;

        private string introSound;

        private string gameSound;

        private bool gifState;

        public MainMenu()
        {
            InitializeComponent();
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
                Mp3Player.SetResource(this.introSound);
                Mp3Player.Loop(true);
                if (!firstInit)
                {
                    System.Threading.Thread.Sleep(5); //Er zat een raar plopje dat de volume van het vorige liedje nog aan stond, dit lijkt dat op te lossen.
                    Mp3Player.FadeIn(2000);
                    Mp3Player.SetPosition(27D);
                }
                Mp3Player.PlaySelected();
                firstInit = false;

                // Preload stuff
                this.PrepareNewGameScreen();
            }
        }        

        /// <summary>
        /// Laad main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e) {
            // Make invisible
            this.Visible = false;
            this.levelDialog1.Visible = false;
            this.mainMenuControl1.Visible = false;

            // Boolean waarmee gekeken kan worden of did de eerste keer is dat 
            // de splashscreen word weergeven of niet
            this.gifState = true;
            this.gifTimer.Tick += new EventHandler(Timer_Tick);
            if (this.gifState == true)
            {
                // Interval is ~ongeveer 4 seconden.
                // Hangt een beetje af van snelheid van computer
                this.gifTimer.Interval = 4500;
                this.gifTimer.Start();
                this.gifState = false;
            }

            // Init form
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
            this.SizeChanged += delegate(object source, EventArgs ea) { CenterControl(this.levelDialog1); };
            this.levelDialog1.LevelChosen += OpenLevel;

            // Load resources
            this.loadResources();
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
            // Gif finished
            gifTimer.Stop();

            // Center controls
            CenterControl(mainMenuControl1);
            CenterControl(levelDialog1);

            // Make main menu visible
            mainMenuControl1.Visible = true;

            // Change picture to loop
            pictureBox1.Image = global::Olympus_the_Game.Properties.Resources.loop;
        }

        private void CenterControl(Control c)
        {
            c.Left = (this.Width - c.Width) / 2;
            c.Top = (this.Height - c.Height) / 2;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            openGame = true;
            this.mainMenuControl1.Visible = false;
            this.levelDialog1.Visible = true;
        }

        private void ButtonLevelEditor_Click(object sender, EventArgs e)
        {
            openGame = false;
            this.mainMenuControl1.Visible = false;
            this.levelDialog1.Visible = true;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            OlympusTheGame.RequestClose();
        }

        private void OpenLevel()
        {
            int lvl = this.levelDialog1.Level;
            if (openGame)
            {
                this.Visible = false;
                StartGame();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Level editor will be added later!");
            }
        }

        private void loadResources()
        {
            this.gameSound = Mp3Player.PrepareResource(Properties.Resources.Blocks);
            this.introSound = Mp3Player.PrepareResource(Properties.Resources.StarWars);
            ImagePool.LoadImagePool();
        }

        public void PrepareNewGameScreen()
        {
            // Maak gamescreen aan
            this.gs = new GameScreen();

            // Reset gametime
            OlympusTheGame.GameTime = 0;
            
        }

        /// <summary>
        /// Deze methode wordt aangeroepen om de game te starten.
        /// </summary>
        public void StartGame()
        {
            // Read PlayField
            OlympusTheGame.Playfield = PlayFieldToXml.ReadFromResource(Properties.Resources.hell);
            if (OlympusTheGame.Playfield == null)
            {
                OlympusTheGame.Playfield = new PlayField();
            }

            OlympusTheGame.Playfield.InitializeGameObjects();
            

            // Add PlayField to GameScreen
            gs.gamePanel1.Playfield = OlympusTheGame.Playfield;

            // Start timers
            OlympusTheGame.Resume();

            Mp3Player.SetResource(this.gameSound);
            Mp3Player.Loop(true);
            Mp3Player.PlaySelected();
            // Start applicatie
            gs.ShowDialog();
            Mp3Player.StopPlaying();
        }
    }
}
