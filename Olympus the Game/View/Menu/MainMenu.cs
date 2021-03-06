﻿using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model;
using Olympus_the_Game.Properties;
using Olympus_the_Game.View.Editor;
using Olympus_the_Game.View.Game;
using Olympus_the_Game.View.Imaging;
using Timer = System.Windows.Forms.Timer;

namespace Olympus_the_Game.View.Menu
{
    /// <summary>
    ///     Mainmenu form
    ///     Bevat onderandere een control met buttons
    ///     Splashscreen magic happens here
    /// </summary>
    public partial class Mainmenu : Form
    {
        private bool firstInit = true;

        private EventHandler _threadCallback; //callback voor als er een event van buiten de form thread wordt aangeroepen

        private GameScreen gs;

        public Mainmenu()
        {
            InitializeComponent();
            Icon = Resources.icon;
        }

        /// <summary>
        ///     Wordt aangeroepen zodra de visibility van het Mainmenu veranderd, als dat gebeurd willen we het StarWars muziekje
        ///     weer laten spelen
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
                    Thread.Sleep(5);
                    //Er zat een raar plopje dat de volume van het vorige liedje nog aan stond, dit lijkt dat op te lossen.
                    Mp3Player.FadeIn(2000);
                    Mp3Player.SetPosition(27D);
                }
                Mp3Player.PlaySelected();
                firstInit = false;

                // Preload stuff
                PrepareNewGameScreen();
            }
        }

        /// <summary>
        ///     Laad main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Make invisible
            Visible = false;
            HideAllControls();

            // Er wordt een BackgroundWorker thread aangemaakt, deze thread gaat 5000 milliseconde slapen
            // Na 5000 milliseconde wordt er een Invoke gedaan op deze thread met het verzoek de timer te stoppen.
            BackgroundWorker bw = new BackgroundWorker(); 
            bw.DoWork += delegate(object o, DoWorkEventArgs ev) { 
                Thread.Sleep(5000);
                _threadCallback = Timer_Tick;
                Invoke(_threadCallback, new object[] { sender, e });
            };
            bw.RunWorkerAsync();

            // Init form
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            CenterToScreen();

            // Add events
            mainMenuControl1.ButtonStart.Click += ButtonStart_Click;
            mainMenuControl1.ButtonLevelEditor.Click += ButtonLevelEditor_Click;
            mainMenuControl1.ButtonSettings.Click += ButtonSettings_Click;
            mainMenuControl1.ButtonExit.Click += ButtonExit_Click;
            mainMenuControl1.button1.Click += ButtonHelp_Click;
            VisibleChanged += MainMenu_VisibleChanged;
            SizeChanged += delegate { CenterAllControls(); };
            levelDialog1.LevelChosen += OpenLevel;
            levelEditorMenu1.ButtonNewEditor.Click += NewEditor;
            levelEditorMenu1.ButtonLoadEditor.Click += LoadEditor;

            // Load resources
            LoadResources();
        }


        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            HideAllControls();
            helpDialog1.Visible = true;
            ButtonBack.Visible = true;
        }

        /// <summary>
        ///     Als de 4 seconden voorbij zijn van de gifTimer dan word
        ///     deze functie aangeroepen die ervoor zorgt dat de achtergrond
        ///     veranderd in een seemless looping starburst gif, en het menu
        ///     weergeven word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Center controls
            CenterControl(mainMenuControl1);
            CenterControl(levelDialog1);
            CenterControl(levelEditorMenu1);
            CenterControl(settingsDialog1);

            // Make main menu visible
            mainMenuControl1.Visible = true;

            // Change picture to loop
            pictureBox1.Image = Resources.loop;
        }

        private void CenterControl(Control c)
        {
            c.Left = (Width - c.Width)/2;
            c.Top = (Height - c.Height)/2;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            HideAllControls();
            levelDialog1.Visible = true;
            ButtonBack.Visible = true;
        }

        private void ButtonLevelEditor_Click(object sender, EventArgs e)
        {
            HideAllControls();
            levelEditorMenu1.Visible = true;
            ButtonBack.Visible = true;
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            HideAllControls();
            settingsDialog1.Visible = true;
            ButtonBack.Visible = true;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            OlympusTheGame.RequestClose();
            gs.Dispose();
            Dispose();
        }

        private void OpenLevel(PlayField pf)
        {
            if (pf == null)
                pf = PlayfieldLoader.ReadFromResource(Resources.mapHell) ?? new PlayField();
            // Read PlayField
            OlympusTheGame.Playfield = pf;

            OlympusTheGame.Playfield.InitializeGameObjects();

            // Show mask
            Mp3Player.FadeOut(Utils.MaskFadeDuration);
            Utils.ShowMask(true);
            // Hid this screen
            Visible = false;
            // Create Gamescreen
            ShowGame();

            // Add eventhandler
            gs.Shown += ShowMaskAndStartGame;

            // Show gamescreen
            gs.ShowDialog();

            // Remove eventhandler
            gs.Shown -= ShowMaskAndStartGame;

            // Gamescreen closed, make this visible
            Visible = true;
        }

        private void HideAllControls()
        {
            levelDialog1.Visible = false;
            levelEditorMenu1.Visible = false;
            ButtonBack.Visible = false;
            mainMenuControl1.Visible = false;
            helpDialog1.Visible = false;
            settingsDialog1.Visible = false;
        }

        private static void LoadResources()
        {
            DataPool.LoadDataPool();
        }

        public void PrepareNewGameScreen()
        {
            // Maak gamescreen aan
            if (gs == null || gs.IsDisposed)
                gs = new GameScreen();

            // Reset gametime
            OlympusTheGame.GameTime = 0;
        }

        /// <summary>
        ///     Deze methode wordt aangeroepen om de game te starten.
        /// </summary>
        public void ShowGame()
        {
            // Start muziek
            Mp3Player.SetResource(DataPool.GameSound);
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
            mainMenuControl1.Visible = true;
        }

        private void NewEditor(object sender, EventArgs e)
        {
            Utils.ShowMask(true);
            var le = new LevelEditor();
            Visible = false;
            new Thread(() => Utils.ShowMask(false)).Start();
            le.ShowDialog();
            Visible = true;
        }

        private void LoadEditor(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = PlayfieldLoader.CustomMapLoc;

            // als er op OK word gedrukt
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // en er is een bestand geselecteerd
                Stream fileStream;
                if ((fileStream = openFileDialog1.OpenFile()) != null)
                {
                    // Lees bestand
                    PlayField pf = PlayfieldLoader.ReadFromXml(fileStream);
                    // Als geldig
                    if (pf != null)
                    {
                        // Open LevelEditor
                        Utils.ShowMask(true);
                        var le = new LevelEditor(pf);
                        Visible = false;
                        new Thread(() => Utils.ShowMask(false)).Start();
                        le.ShowDialog();
                        Visible = true;
                    }
                }
            }
        }

        private void CenterAllControls()
        {
            CenterControl(levelEditorMenu1);
            CenterControl(levelDialog1);
            CenterControl(mainMenuControl1);
            CenterControl(settingsDialog1);
        }

        private void ShowMaskAndStartGame(object source, EventArgs ea)
        {
            Utils.ShowMask(false);
            StartGame();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            OlympusTheGame.RequestClose();
        }
    }
}