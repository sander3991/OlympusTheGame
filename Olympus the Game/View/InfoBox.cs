﻿using System;
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
        private EntityPlayer player; //De speler waarvan op dit moment de health getracked wordt
        private Form SourceForm;
        private Point loc;

        public InfoBox()
        {
            InitializeComponent();

            if (OlympusTheGame.Playfield == null || OlympusTheGame.Playfield.Player == null)
                return;

            EntityPlayer player = OlympusTheGame.Playfield.Player;
            if (player == null)
                throw new ArgumentException("De PLayer Entity is nog niet geinitialiseerd");
            player.OnHealthChanged += UpdateHealth;
            OlympusTheGame.OnNewPlayField += OnPlayFieldUpdate;
            this.player = player;
        }

        /// <summary>
        /// Zorgt ervoor dat de healthbar bij het laden van een nieuwe speelveld (en een nieuwe speler), de healthbar gaat luisteren naar de nieuwe speler
        /// </summary>
        /// <param name="Playfield">Het nieuwe playfield object</param>
        private void OnPlayFieldUpdate(PlayField Playfield)
        {
            player.OnHealthChanged -= UpdateHealth;
            player = Playfield.Player;
            player.OnHealthChanged += UpdateHealth;
            UpdateHealth(player, -1);
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
        private void UpdateHealth(EntityPlayer player, int prevHealth)
        {
            // Geeft het aantal levens weer
            heartAlive1.Visible = false;
            heartAlive2.Visible = false;
            heartAlive3.Visible = false;
            heartAlive4.Visible = false;
            heartAlive5.Visible = false;
            switch (player.Health)
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

        private void ButtonRemove_Click(object sender, EventArgs e) {
            loc = this.Location;
            SourceForm = this.FindForm();
            SourceForm.Controls.Remove(this);

            Form f = new Form();
            f.Width = this.Width + 10;
            f.Height = this.Height + 35;
            f.BackgroundImage = Properties.Resources.dirt;
            f.Controls.Add(this);
            this.Location = new Point(0, 0);
            f.MaximizeBox = false;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.FormClosed += BringBack;
            this.SleepButton.Visible = false;
            this.ButtonRemove.Visible = false;
            f.Show();
        }

        private void BringBack(object source, EventArgs e) {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            f.Dispose();

            SourceForm.Controls.Add(this);
            this.SleepButton.Visible = true;
            this.ButtonRemove.Visible = true;

            this.Location = loc;
        }

    }
}
