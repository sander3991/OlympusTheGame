using Olympus_the_Game.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
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
        System.Windows.Forms.Timer gifTimer = new System.Windows.Forms.Timer();

        private bool firstInit = true;

        private GameScreen gs;

        public MainMenu()
        {
            InitializeComponent();
            var pos = this.PointToScreen(helpDialog1.Location);
            helpDialog1.Parent = pictureBox1;
            helpDialog1.Location = pictureBox1.PointToClient(pos);
        }

        /// <summary>
        /// Wordt aangeroepen zodra de visibility van het MainMenu veranderd, als dat gebeurd willen we het StarWars muziekje weer laten spelen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Mp3Player.StopPlaying();
                Mp3Player.SetResource(DataPool.IntroSound);
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
        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Make invisible
            this.Visible = false;
            HideAllControls();

            this.gifTimer.Tick += new EventHandler(Timer_Tick);
            // Interval is ~ongeveer 5 seconden.
            // Hangt een beetje af van snelheid van computer
            this.gifTimer.Interval = 5000;
            this.gifTimer.Start();

            // Init form
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.CenterToScreen();

            // Add events
            this.mainMenuControl1.ButtonStart.Click += ButtonStart_Click;
            this.mainMenuControl1.ButtonLevelEditor.Click += ButtonLevelEditor_Click;
            this.mainMenuControl1.ButtonSettings.Click += ButtonSettings_Click;
            this.mainMenuControl1.ButtonExit.Click += ButtonExit_Click;
            this.mainMenuControl1.button1.Click += ButtonHelp_Click;
            this.VisibleChanged += MainMenu_VisibleChanged;
            this.SizeChanged += delegate(object source, EventArgs ea) { CenterAllControls(); };
            this.levelDialog1.LevelChosen += OpenLevel;
            this.levelEditorMenu1.ButtonNewEditor.Click += NewEditor;
            this.levelEditorMenu1.ButtonLoadEditor.Click += LoadEditor;

            // Load resources
            this.loadResources();
        }

        

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            HideAllControls();
            this.helpDialog1.Visible = true;
            this.ButtonBack.Visible = true;
            this.helpDialog1.Start();
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
            CenterControl(levelEditorMenu1);

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
            HideAllControls();
            this.levelDialog1.Visible = true;
            this.ButtonBack.Visible = true;
        }

        private void ButtonLevelEditor_Click(object sender, EventArgs e)
        {
            HideAllControls();
            this.levelEditorMenu1.Visible = true;
            this.ButtonBack.Visible = true;
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            HideAllControls();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            OlympusTheGame.RequestClose();
        }

        private void OpenLevel()
        {
            // Retrieve level
            int lvl = this.levelDialog1.Level;
            // TODO Load given level

            // Show mask
            Mp3Player.FadeOut(4000);
            Utils.ShowMask(true);
            // Hid this screen
            this.Visible = false;
            // Create Gamescreen
            ShowGame();

            // Add eventhandler
            this.gs.Shown += ShowMaskAndStartGame;

            // Show gamescreen
            this.gs.ShowDialog();

            // Remove eventhandler
            this.gs.Shown -= ShowMaskAndStartGame;

            // Gamescreen closed, make this visible
            this.Visible = true;
        }

        private void HideAllControls()
        {
            this.levelDialog1.Visible = false;
            this.levelEditorMenu1.Visible = false;
            this.ButtonBack.Visible = false;
            this.mainMenuControl1.Visible = false;
            this.helpDialog1.Visible = false;
        }

        private void loadResources()
        {
            DataPool.LoadDataPool();
        }

        public void PrepareNewGameScreen()
        {
            // Maak gamescreen aan
            if (this.gs == null || this.gs.IsDisposed)
                this.gs = new GameScreen();

            // Reset gametime
            OlympusTheGame.GameTime = 0;

        }

        /// <summary>
        /// Deze methode wordt aangeroepen om de game te starten.
        /// </summary>
        public void ShowGame()
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

            // Start muziek
            Mp3Player.SetResource(DataPool.gameSound);
            Mp3Player.Loop(true);
        }

        public void StartGame()
        {
            Mp3Player.PlaySelected();
            OlympusTheGame.Resume();
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            HideAllControls();
            this.mainMenuControl1.Visible = true;
        }

        private void NewEditor(object sender, EventArgs e)
        {
            Utils.ShowMask(true);
            LevelEditor le = new LevelEditor();
            this.Visible = false;
            new Thread(delegate() { Utils.ShowMask(false); }).Start();
            le.ShowDialog();
            this.Visible = true;
        }

        private void LoadEditor(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon!");
        }

        private void CenterAllControls()
        {
            CenterControl(this.levelEditorMenu1);
            CenterControl(this.levelDialog1);
            CenterControl(mainMenuControl1);
        }

        private void ShowMaskAndStartGame(object source, EventArgs ea)
        {
            Utils.ShowMask(false);
            this.StartGame();
        }
    }
}
