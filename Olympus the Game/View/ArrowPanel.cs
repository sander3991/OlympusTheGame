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
    public partial class ArrowPanel : UserControl
    {
        // Punt zodat het panel versleept kan worden
        public Point MouseDownLocation { get; set; }

        public ArrowPanel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Kijk of er op het plaatje met pijltjes toetsen is geklikt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrowKey_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            string richting = b.Name.ToString();
            switch (richting)
            {
                case "ArrowKeyRight":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(2, true);
                    break;
                case "ArrowKeyLeft":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(-2, true);
                    break;
                case "ArrowKeyUp":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(-2, false);
                    break;
                case "ArrowKeyDown":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(2, false);
                    break;
            }
        }
        
        /// <summary>
        /// Functie om de speler stil te zetten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopMoving(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(0, true);
            OlympusTheGame.INSTANCE.Controller.MovePlayer(0, false);
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

        private void button1_Click(object sender, EventArgs e)
        {
            //OlympusTheGame.INSTANCE.Controller.CustomRight = 76;
            //OlympusTheGame.INSTANCE.Controller.CustomLeft = 74;
            //OlympusTheGame.INSTANCE.Controller.CustomUp = 73;
            //OlympusTheGame.INSTANCE.Controller.CustomDown = 75;
            try
            {
                OlympusTheGame.INSTANCE.Controller.CustomRight =Convert.ToInt32(Char.ToUpper(textBox1.Text[0]));
                OlympusTheGame.INSTANCE.Controller.CustomLeft = Convert.ToInt32(Char.ToUpper(textBox2.Text[0]));
                OlympusTheGame.INSTANCE.Controller.CustomUp =   Convert.ToInt32(Char.ToUpper(textBox3.Text[0]));
                OlympusTheGame.INSTANCE.Controller.CustomDown = Convert.ToInt32(Char.ToUpper(textBox4.Text[0]));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Onjuiste toetsen geselecteerd");
            }
            
            //int wat = Convert.ToInt32(textBox1.Text[0]);
            //MessageBox.Show(wat.ToString());
        }
        
    }
}
                
