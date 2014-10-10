using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using Olympus_the_Game.View.Game;
using System.Threading;

namespace Olympus_the_Game.View
{
    public partial class GameScreen : Form
    {
        private bool forceClose = false;
        /// <summary>
        /// Maak een nieuw GameScreen aan.
        /// </summary>
        public GameScreen()
        {
            // Initialiseer componenten
            InitializeComponent();
            forceClose = false;
            OlympusTheGame.OnNewPlayField += OnPlayFieldUpdate;
            OlympusTheGame.Controller.OnPlayerFinished += OnPlayerFinished;
        }

        private void OnPlayerFinished(FinishType type)
        {
            GameFinished gf = new GameFinished(type);
            gf.ShowDialog();
            gf.Dispose();
            this.forceClose = true;
            Close();
        }

        /// <summary>
        /// Vraagscherm bij afsluiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible == false)
            {
                e.Cancel = true;
                return;
            }

            // Cancel event
            e.Cancel = true;

            // Opent dialoog voor sluiten
            if (!forceClose)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to exit the game? Any unsaved data will be lost.",
                    "Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Sluit spel af bij JA/YES
                // Sluit dialoog af bij NEE/NO en laat spel verder draaien
                if (dr == DialogResult.Yes)
                {
                    this.Visible = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                // Turn back to normal
                forceClose = false;
            }

            OlympusTheGame.Pause();
            OlympusTheGame.GameTime = 0;
            Utils.ShowMask(true);
            this.Visible = false;
            new Thread(delegate() { Utils.ShowMask(false); }).Start();
        }

        /// <summary>
        /// Deze methode wordt aangeroepen als het scherm wordt geladen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameScreen_Load(object sender, EventArgs e)
        {
            // Maak niet resizable
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            arrowPanel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            infoBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            infoView1.Anchor = (AnchorStyles.Right | AnchorStyles.Top);

            // Update menu
            volledigeWeergaveToolStripMenuItem.Checked = true;

            // Do event handlers

            this.infoView1.LocationChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };
            this.arrowPanel1.LocationChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };
            this.infoBox1.LocationChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };

            this.infoView1.VisibleChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };
            this.arrowPanel1.VisibleChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };
            this.infoBox1.VisibleChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };
            this.menuStrip1.VisibleChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };

            this.SizeChanged += delegate(object source, EventArgs ea) { this.gamePanel1.TryExpand(); };

            this.bedieningToolStripMenuItem.CheckedChanged += delegate(object source, EventArgs ea) { if ((source as ToolStripMenuItem).Checked) this.verbergAllesToolStripMenuItem.Checked = false; };
            this.informatieToolStripMenuItem.CheckedChanged += delegate(object source, EventArgs ea) { if ((source as ToolStripMenuItem).Checked) this.verbergAllesToolStripMenuItem.Checked = false; };
            this.statistiekenToolStripMenuItem.CheckedChanged += delegate(object source, EventArgs ea) { if ((source as ToolStripMenuItem).Checked) this.verbergAllesToolStripMenuItem.Checked = false; };

            // Update view
            this.updateView();

            // Start music
            Mp3Player.SetResource(DataPool.gameSound);
            Mp3Player.Loop(true);
        }

        /// <summary>
        /// Handel toetsen af als deze worden ingedrukt
        /// Doe dit via de static KeyHandler class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            KeyHandler.KeyDown(sender, e);
        }

        /// <summary>
        /// Handel toetsen af als deze worden los gelaten
        /// Doet dit via de static KeyHandler class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            KeyHandler.KeyUp(this, e);
        }

        #region MenuBar

        /// <summary>
        /// Method die wordt aangeroepen door de event in de OlympusTheGame class, zodat het playfield update zodra er een nieuw level gekozen is
        /// </summary>
        /// <param name="pf">Het nieuwe playfield</param>
        private void OnPlayFieldUpdate(PlayField pf)
        {
            gamePanel1.Playfield = pf;
            gamePanel1.TryExpand();
        }

        private void pauzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OlympusTheGame.Pause();
        }

        private void verderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OlympusTheGame.Resume();
        }

        private void changeLayoutButtonClicked(object sender, EventArgs e)
        {
            updateView();
        }

        private void verbergAllesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statistiekenToolStripMenuItem.Checked = !this.verbergAllesToolStripMenuItem.Checked;
            this.informatieToolStripMenuItem.Checked = !this.verbergAllesToolStripMenuItem.Checked;
            this.bedieningToolStripMenuItem.Checked = !this.verbergAllesToolStripMenuItem.Checked;

            updateView();
        }

        private void updateView()
        {
            // InfoBox verbergen of weergeven
            switch (this.informatieToolStripMenuItem.Checked)
            {
                case (false):
                    infoBox1.Hide();
                    break;
                case (true):
                    infoBox1.Show();
                    break;
            }

            // Pijltjestoetsen verbergen of weergeven
            switch (this.bedieningToolStripMenuItem.Checked)
            {
                case (false):
                    arrowPanel1.Hide();
                    break;
                case (true):
                    arrowPanel1.Show();
                    break;
            }

            // InfoView verbergen of weergeven
            switch (this.statistiekenToolStripMenuItem.Checked)
            {
                case (false):
                    infoView1.Hide();
                    break;
                case (true):
                    infoView1.Show();
                    break;
            }

            // Volledige weergave aan/uit
            switch (volledigeWeergaveToolStripMenuItem.Checked)
            {
                case (false):
                    this.menuStrip1.Visible = true;
                    Utils.FullScreen(this, false);
                    break;
                case (true):
                    this.menuStrip1.Visible = false;
                    Utils.FullScreen(this, true);
                    break;
            }

            // Try to expand
            this.gamePanel1.TryExpand();
        }
        /// <summary>
        /// Open een file explorer om een bestand te selecteren
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMusicFileDialog.ShowDialog();
        }

        /// <summary>
        /// Als er op ok is geklikt met de file opener speel dan de muziek af
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenMusicFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Mp3Player.StopPlaying();
            CustomMusicPlayer.Open(OpenMusicFileDialog.FileName);
            CustomMusicPlayer.Play(herhalenToolStripMenuItem.Checked);
            speelpauzeToolStripMenuItem.Checked = true;
        }
        /// <summary>
        /// Pauzeer of ga verder met afspelen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speelpauzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustomMusicPlayer.IsPlaying)
                CustomMusicPlayer.Pause();
            else if (!CustomMusicPlayer.IsPlaying)
                CustomMusicPlayer.Play(herhalenToolStripMenuItem.Checked);

            else if (Mp3Player.IsPlaying)
                Mp3Player.Pause();
            else if (!Mp3Player.IsPlaying)
                Mp3Player.Play();

        }
        /// <summary>
        /// Als er op stop is geklikt stop dan de muziek spelers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Mp3Player.IsPlaying)
                Mp3Player.StopPlaying();
            else if (CustomMusicPlayer.IsPlaying)
                CustomMusicPlayer.Stop();
        }
        /// <summary>
        /// Kijkt of hij de muziek moet herhalen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void herhalenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (herhalenToolStripMenuItem.Checked)
                herhalenToolStripMenuItem.Checked = false;
            else
                herhalenToolStripMenuItem.Checked = true;
        }
        /// <summary>
        /// Laat de gebruiker de muziek herhalen als hij dat wil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void herhalenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (Mp3Player.IsPlaying)
                Mp3Player.Loop(herhalenToolStripMenuItem.Checked);
            else if (CustomMusicPlayer.IsPlaying)
                CustomMusicPlayer.Play(herhalenToolStripMenuItem.Checked);

        }
        /// <summary>
        /// verander het checked icoontje bij een onclick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeDempenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!volumeDempenToolStripMenuItem.Checked)
                volumeDempenToolStripMenuItem.Checked = true;
            else
                volumeDempenToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Als user mute heeft geklikt demp dan het volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeDempenToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (volumeDempenToolStripMenuItem.Checked)
            {
                Mp3Player.Volume = 0;
                CustomMusicPlayer.ChangeVolume(0);
            }
            else
            {
                Mp3Player.Volume = 100;
                CustomMusicPlayer.ChangeVolume(100);
            }

        }

        #endregion
    }
}
