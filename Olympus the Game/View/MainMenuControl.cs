using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View {
    public partial class MainMenuControl : UserControl {
        public MainMenuControl() {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e) {
            this.FindForm().Visible = false;
            OlympusTheGame.Start();
            this.FindForm().Visible = true;
        }

        private void ButtonLevelEditor_Click(object sender, EventArgs e) {
            this.FindForm().Visible = false;
            LevelDialog ld = new LevelDialog();
            ld.ShowDialog();
            this.FindForm().Visible = true;            
        }
    }
}
