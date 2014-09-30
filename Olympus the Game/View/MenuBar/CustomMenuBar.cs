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

            this.Items.Add(tsmiFile);
            tsmiFile.DropDownItems.Add(tsmiOpen);
            tsmiFile.DropDownItems.Add(new ToolStripSeparator());
            tsmiFile.DropDownItems.Add(tsmiClose);

            this.Items.Add(tsmiLevelEditor);
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
        }

        private void LevelEditor_Click(object sender, EventArgs e)
        {
            LevelEditor le = new LevelEditor();
            le.ShowDialog();
        }
    }
}
