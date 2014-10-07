using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game {
    public partial class MainMenu : Form {
        public MainMenu() {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            mainMenuControl1.Left = (this.ClientSize.Width - mainMenuControl1.Width) / 2;
            mainMenuControl1.Top = (this.ClientSize.Height - mainMenuControl1.Height) / 2;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}
