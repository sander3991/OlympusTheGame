using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Olympus_the_Game.View
{
    public partial class InfoBox : UserControl
    {
        public Point MouseDownLocation { get; set; }
        public InfoBox()
        {
            InitializeComponent();
        }

        public void Update(int Health)
        {
            PlayField pf = OlympusTheGame.INSTANCE.Playfield;
            SpelerSpeedX.Text = pf.Player.SpeedModifier.ToString();
            SpelerX.Text = OlympusTheGame.INSTANCE.Playfield.Player.X.ToString();
            SpelerY.Text = OlympusTheGame.INSTANCE.Playfield.Player.Y.ToString();
            timePlayed.Text = OlympusTheGame.INSTANCE.Controller.GetTimeSinceStart();

            // Geeft het aantal levens weer
            heartAlive1.Visible = false;
            heartAlive2.Visible = false;
            heartAlive3.Visible = false;
            heartAlive4.Visible = false;
            heartAlive5.Visible = false;
            switch (Health)
            {
                case 5:
                    heartAlive5.Visible = true;
                    goto case 4;
                case 4:
                    heartAlive4.Visible = true;
                    goto case 3;
                case 3:
                    heartAlive3.Visible = true;
                    goto case 2;
                case 2:
                    heartAlive2.Visible = true;
                    goto case 1;
                case 1:
                    heartAlive1.Visible = true;
                    break;
            }

        }

        /// <summary>
        /// Functie om het panel op runtime te verslepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepKnop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
            this.BringToFront();
        }
        /// <summary>
        /// Functie die het scherm plaatst als je die muis loslaat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepKnop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void InfoBox_Load_1(object sender, EventArgs e)
        {
            if (OlympusTheGame.INSTANCE != null)
                OlympusTheGame.INSTANCE.Controller.UpdateSlowEvents += delegate() { Update(OlympusTheGame.INSTANCE.Playfield.Player.Health); };
        }

    }
}
