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
        Stopwatch stopWatch = Stopwatch.StartNew();
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
            timePlayed.Text = stopWatch.Elapsed.Minutes.ToString() + ":" + stopWatch.Elapsed.Seconds.ToString();
            // Geeft het aantal levens weer
            for (int i = 0; i <= Health; i++)
            {
                switch (i)
                {
                    case (1):
                        heartAlive1.Visible = true;
                        break;
                    case (2):
                        heartAlive2.Visible = true;
                        break;
                    case (3):
                        heartAlive3.Visible = true;
                        break;
                    case (4):
                        heartAlive4.Visible = true;
                        break;
                    case (5):
                        heartAlive5.Visible = true;
                        break;
                    default:
                        heartAlive1.Visible = false;
                        heartAlive2.Visible = false;
                        heartAlive3.Visible = false;
                        heartAlive4.Visible = false;
                        heartAlive5.Visible = false;
                        break;
                }

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
