using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace Olympus_the_Game.View
{
    public partial class GameScreen : Form
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Vraagscherm bij afsluiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            // Opent dialoog voor sluiten
            DialogResult dr = MessageBox.Show("Are you sure you want to exit the game? Any unsaved data will be lost.",
                "Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Sluit spel af bij JA/YES
            // Sluit dialoog af bij NEE/NO en laat spel verder draaien
            if (dr == DialogResult.Yes)
                OlympusTheGame.INSTANCE.RequestClose();
            else
                e.Cancel = true;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            arrowPanel1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            infoBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            infoView1.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.OnKeyDown(e);
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.OnKeyUp(e);
        }

        // ======================
        // ====== menu bar ======
        // ======================

        private void statistiekenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // InfoView verbergen of weergeven
            switch (statestiekenToolStripMenuItem.Checked)
            {
                case (false):
                    infoView1.Hide();
                    break;
                case (true):
                    infoView1.Show();
                    break;
            }    
        }

        private void informatieSchermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // InfoBox verbergen of weergeven
            switch (informatieSchermToolStripMenuItem.Checked)
            {
                case (false):
                    infoBox1.Hide();
                    break;
                case (true):
                    infoBox1.Show();
                    break;
            }    
        }

        private void pijltjestoetsenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Pijltjestoetsen verbergen of weergeven
            switch (pijltjestoetsenToolStripMenuItem.Checked) { 
                case(false):
                    arrowPanel1.Hide();
                    break;
                case(true):
                    arrowPanel1.Show();
                    break;
            }    
        }

        private void volledigeWeergaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Volledige weergave aan/uit
            switch (volledigeWeergaveToolStripMenuItem.Checked)
            {
                case (false):
                    WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    gamePanel1.Left = 10;
                    gamePanel1.Top = 35;
                    break;
                case (true):
                    WindowState = FormWindowState.Maximized;
                    this.FormBorderStyle = FormBorderStyle.None;
                    gamePanel1.Left = (this.ClientSize.Width - gamePanel1.Width) / 2;
                    gamePanel1.Top = (this.ClientSize.Height - gamePanel1.Height) / 2;
                    break;
            }    
        }
    }
}
