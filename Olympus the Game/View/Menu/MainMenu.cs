﻿using Olympus_the_Game.Controller;
using Olympus_the_Game.Model;
using Olympus_the_Game.View;
using Olympus_the_Game.View.Editor;
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
using Olympus_the_Game.View.Game;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game.View.Menu
{
    /// <summary>
    /// Mainmenu form
    /// Bevat onderandere een control met buttons
    /// Splashscreen magic happens here
    /// </summary>
    public partial class Mainmenu : Form
    {
        // Timer die gebruikt word voor het afspelen van splashscreen.gif
        readonly System.Windows.Forms.Timer gifTimer = new System.Windows.Forms.Timer();

        private bool firstInit = true;

        private GameScreen gs;

        public Mainmenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Wordt aangeroepen zodra de visibility van het Mainmenu veranderd, als dat gebeurd willen we het StarWars muziekje weer laten spelen
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
            this.SizeChanged += delegate { CenterAllControls(); };
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
            CenterControl(settingsDialog1);

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
            this.settingsDialog1.Visible = true;
            this.ButtonBack.Visible = true;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            OlympusTheGame.RequestClose();
            gs.Dispose();
            this.Dispose();
        }

        private void OpenLevel()
        {
            // Retrieve level
            int lvl = this.levelDialog1.Level;

            // Read PlayField
            OlympusTheGame.Playfield = PlayFieldToXml.ReadFromResource(Properties.Resources.hell);
            if (OlympusTheGame.Playfield == null)
            {
                OlympusTheGame.Playfield = new PlayField();
            }

            OlympusTheGame.Playfield.InitializeGameObjects();

            // Show mask
            Mp3Player.FadeOut(Utils.MASK_FADE_DURATION);
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
            this.settingsDialog1.Visible = false;
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            // als er op OK word gedrukt
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // en er is een bestand geselecteerd
                System.IO.Stream fileStream;
                if ((fileStream = openFileDialog1.OpenFile()) != null)
                {
                    // Lees bestand
                    PlayField pf = PlayFieldToXml.ReadFromXml(fileStream);
                    // Als geldig
                    if (pf != null)
                    {
                        // Open LevelEditor
                        Utils.ShowMask(true);
                        LevelEditor le = new LevelEditor(pf);
                        this.Visible = false;
                        new Thread(delegate() { Utils.ShowMask(false); }).Start();
                        le.ShowDialog();
                        this.Visible = true;
                    }
                }
            }
        }

        private void CenterAllControls()
        {
            CenterControl(this.levelEditorMenu1);
            CenterControl(this.levelDialog1);
            CenterControl(this.mainMenuControl1);
            CenterControl(this.settingsDialog1);
        }

        private void ShowMaskAndStartGame(object source, EventArgs ea)
        {
            Utils.ShowMask(false);
            this.StartGame();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            OlympusTheGame.RequestClose();
        }
    }
}
