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
        public InfoBox()
        {
            InitializeComponent();
        }

        public void HealthHearts(int Health)
        {
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


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HealthHearts(OlympusTheGame.INSTANCE.Playfield.Player.Health);
        }
    }
}
