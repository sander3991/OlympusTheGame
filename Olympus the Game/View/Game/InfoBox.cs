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

            if (OlympusTheGame.Controller != null)
                OlympusTheGame.Controller.OnHealthChanged += UpdateHealth;
            OlympusTheGame.OnNewPlayField += OlympusTheGame_OnNewPlayField;
        }

        void OlympusTheGame_OnNewPlayField(PlayField obj)
        {
            UpdateHealth(obj.Player, obj.Player.Health, -1);
        }

        /// <summary>
        /// Wijst verschillende gegevens toe aan labels in de InfoBox
        /// </summary>
        private void UpdateLabels()
        {
            PlayField pf = OlympusTheGame.Playfield;
            SpelerSpeedX.Text = pf.Player.SpeedModifier.ToString();
            SpelerX.Text = OlympusTheGame.Playfield.Player.X.ToString();
            SpelerY.Text = OlympusTheGame.Playfield.Player.Y.ToString();
            timePlayed.Text = OlympusTheGame.Controller.GetTimeSinceStart();
        }

        /// <summary>
        /// Wordt gebruikt om de health van de speler te updaten
        /// </summary>
        /// <param name="player">De speler die het event gefired heeft</param>
        /// <param name="prevHealth">De health voordat de speler damage kreeg</param>
        private void UpdateHealth(EntityPlayer player, int newHealth, int prevHealth)
        {
            // Geeft het aantal levens weer
            heartAlive1.Visible = false;
            heartAlive2.Visible = false;
            heartAlive3.Visible = false;
            heartAlive4.Visible = false;
            heartAlive5.Visible = false;
            switch (newHealth)
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
            if (OlympusTheGame.Controller != null)
                OlympusTheGame.Controller.UpdateSlowEvents += delegate() { UpdateLabels(); };
        }
    }
}
