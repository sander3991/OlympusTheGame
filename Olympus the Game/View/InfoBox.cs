using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            for (int i = 0; i <= Health; i++)
            {
                switch (i)
                {
                    case (1):
                        heart1.Visible = true;
                        break;
                    case (2):
                        heart2.Visible = true;
                        break;
                    case (3):
                        heart3.Visible = true;
                        break;
                    case (4):
                        heart4.Visible = true;
                        break;
                    case (5):
                        heart5.Visible = true;
                        break;
                    default:
                        heart1.Visible = false;
                        heart2.Visible = false;
                        heart3.Visible = false;
                        heart4.Visible = false;
                        heart5.Visible = false;
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


    }
}
