using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View.MenuBar
{
    public partial class CustomMenuBar : MenuStrip
    {
        ToolStripMenuItem tsmiInfoView, tsmiInfoBox, tsmiArrowKeys, tsmiFullScreen;
        public CustomMenuBar()
        {
            InitializeComponent();

            ToolStripMenuItem tsmiFile = new ToolStripMenuItem("Bestand");

            ToolStripMenuItem tsmiOpen = new ToolStripMenuItem("Open");
            tsmiOpen.ShortcutKeys = (Keys)Shortcut.CtrlO;
            tsmiOpen.ShowShortcutKeys = true;
            tsmiOpen.Click += LoadLevel_Click;

            ToolStripMenuItem tsmiClose = new ToolStripMenuItem("Afsluiten");
            tsmiClose.ShortcutKeys = (Keys)Shortcut.AltF4;
            tsmiClose.ShowShortcutKeys = true;
            tsmiClose.Click += QuitGame_Click;

            ToolStripMenuItem tsmiLevelEditor = new ToolStripMenuItem("Level editor");
            tsmiLevelEditor.Click += LevelEditor_Click;

            // Gecomment door elmar
            // Menu: Weergave
            //ToolStripMenuItem tsmiWeergave = new ToolStripMenuItem("Weergave");

            //tsmiInfoView = new ToolStripMenuItem("Statestieken");
            //tsmiInfoView.ShortcutKeys = (Keys)Shortcut.CtrlS;
            //tsmiInfoView.ShowShortcutKeys = true;
            //tsmiInfoView.Checked = true;
            //tsmiInfoView.Click += infoView_Click;

            //tsmiInfoBox = new ToolStripMenuItem("Informatie paneel");
            //tsmiInfoBox.ShortcutKeys = (Keys)Shortcut.CtrlI;
            //tsmiInfoBox.ShowShortcutKeys = true;
            //tsmiInfoBox.Checked = true;
            //tsmiInfoBox.Click += infoBox_Click;

            //tsmiArrowKeys = new ToolStripMenuItem("Pijltjestoetsen");
            //tsmiArrowKeys.ShortcutKeys = (Keys)Shortcut.CtrlP;
            //tsmiArrowKeys.ShowShortcutKeys = true;
            //tsmiArrowKeys.Checked = true;
            //tsmiArrowKeys.Click += arrowKeys_Click;

            //tsmiFullScreen = new ToolStripMenuItem("Volledige weergave");
            //tsmiFullScreen.ShortcutKeys = (Keys)Shortcut.CtrlF;
            //tsmiFullScreen.ShowShortcutKeys = true;
            //tsmiFullScreen.Checked = false;
            //tsmiFullScreen.Click += fullScreen_Click;

            // Menu's toevoegen aan menubalk
            this.Items.Add(tsmiFile);
            tsmiFile.DropDownItems.Add(tsmiOpen);
            tsmiFile.DropDownItems.Add(new ToolStripSeparator());
            tsmiFile.DropDownItems.Add(tsmiClose);

            this.Items.Add(tsmiLevelEditor);

            //this.Items.Add(tsmiWeergave);
            //tsmiWeergave.DropDownItems.Add(tsmiInfoView);
            //tsmiWeergave.DropDownItems.Add(tsmiInfoBox);
            //tsmiWeergave.DropDownItems.Add(tsmiArrowKeys);
            //tsmiFile.DropDownItems.Add(new ToolStripSeparator());
            //tsmiWeergave.DropDownItems.Add(tsmiFullScreen);
        }

        private void QuitGame_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        /// <summary>
        /// Laad een dialog waarin uit standaard levels gekozen kan worden en waar
        /// een .xml bestand kan worden ingeladen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadLevel_Click(object sender, EventArgs e)
        {
            LevelDialog ld = new LevelDialog();
            ld.ShowDialog();
            PlayField Playfield = ld.Playfield;
            if (Playfield != null)
                OlympusTheGame.INSTANCE.SetNewPlayfield(Playfield);
        }

        private void LevelEditor_Click(object sender, EventArgs e)
        {
            LevelEditor le = new LevelEditor();
            le.ShowDialog();
        }

        // Gecomment door Elmar
        //// Menu: weergave
        //private void infoView_Click(object sender, EventArgs e)
        //{
        //    // InfoView verbergen of weergeven
        //    switch (tsmiInfoView.Checked)
        //    {
        //        case (false):
                    
        //            break;
        //        case (true):
        //            infoView1.Show();
        //            break;
        //    }
        //}

        //private void infoBox_Click(object sender, EventArgs e)
        //{
        //    // InfoBox verbergen of weergeven
        //    switch ()
        //    {
        //        case (false):
        //            infoBox1.Hide();
        //            break;
        //        case (true):
        //            infoBox1.Show();
        //            break;
        //    }
        //}

        //private void arrowKeys_Click(object sender, EventArgs e)
        //{
        //    // Pijltjestoetsen verbergen of weergeven
        //    switch ()
        //    {
        //        case (false):
        //            arrowPanel1.Hide();
        //            break;
        //        case (true):
        //            arrowPanel1.Show();
        //            break;
        //    }
        //}

        //private void fullScreen_Click(object sender, EventArgs e)
        //{
        //    // Volledige weergave aan/uit
        //    switch ()
        //    {
        //        case (false):
        //            WindowState = FormWindowState.Normal;
        //            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        //            gamePanel1.Left = 10;
        //            gamePanel1.Top = 35;
        //            break;
        //        case (true):
        //            WindowState = FormWindowState.Maximized;
        //            this.FormBorderStyle = FormBorderStyle.None;
        //            gamePanel1.Left = (this.ClientSize.Width - gamePanel1.Width) / 2;
        //            gamePanel1.Top = (this.ClientSize.Height - gamePanel1.Height) / 2;
        //            break;
        //    }
        //}
    }
}
