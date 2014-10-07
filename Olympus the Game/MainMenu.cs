using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    public partial class MainMenu : Form
    {
        Timer gifTimer = new Timer();

        public MainMenu()
        {
            bool gifState = true;

            InitializeComponent();
            mainMenuControl1.Visible = false;
            this.gifTimer.Tick += new EventHandler(Timer_Tick);
            if (gifState == true)
            {
                gifTimer.Interval = 4000;
                gifTimer.Start();
                gifState = false;
            }
        }

        

        private void MainMenu_Load(object sender, EventArgs e) {
            mainMenuControl1.Left = (this.ClientSize.Width - mainMenuControl1.Width) / 2;
            mainMenuControl1.Top = (this.ClientSize.Height - mainMenuControl1.Height) / 2;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.CenterToScreen();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            gifTimer.Stop();
            mainMenuControl1.Visible = true;
            pictureBox1.Image = global::Olympus_the_Game.Properties.Resources.loop;
        }

    }
}
