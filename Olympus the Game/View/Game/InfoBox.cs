using System;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.Model.Entities;

namespace Olympus_the_Game.View.Game
{
    public partial class InfoBox : UserControl
    {
        public InfoBox()
        {
            InitializeComponent();

            if (OlympusTheGame.GameController != null)
                OlympusTheGame.GameController.OnHealthChanged += UpdateHealth;
            OlympusTheGame.OnNewPlayField += OlympusTheGame_OnNewPlayField;
        }

        public Point MouseDownLocation { get; set; }

        private void OlympusTheGame_OnNewPlayField(PlayField obj)
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
            timePlayed.Text = OlympusTheGame.GameController.GetTimeSinceStart();
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

        private void InfoBox_Load_1(object sender, EventArgs e)
        {
            if (OlympusTheGame.GameController != null)
                OlympusTheGame.GameController.UpdateSlowEvents += delegate { UpdateLabels(); };
        }
    }
}