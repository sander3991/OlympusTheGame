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
            textBoxRight.MaxLength = 1;
            textBoxLeft.MaxLength = 1;
            textBoxUp.MaxLength = 1;
            textBoxDown.MaxLength = 1;
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
        /// <summary>
        /// Verander de controls als de gebruiker een toets wijzigd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textfield_ChangeControls(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxRight.Text))
                    OlympusTheGame.INSTANCE.Controller.CustomRight = 
                        Convert.ToInt32(Char.ToUpper(textBoxRight.Text[0]));
                if (!String.IsNullOrEmpty(textBoxLeft.Text))
                    OlympusTheGame.INSTANCE.Controller.CustomLeft = 
                        Convert.ToInt32(Char.ToUpper(textBoxLeft.Text[0]));
                if (!String.IsNullOrEmpty(textBoxUp.Text))
                    OlympusTheGame.INSTANCE.Controller.CustomUp =   
                        Convert.ToInt32(Char.ToUpper(textBoxUp.Text[0]));
                if (!String.IsNullOrEmpty(textBoxDown.Text))
                    OlympusTheGame.INSTANCE.Controller.CustomDown =
                        Convert.ToInt32(Char.ToUpper(textBoxDown.Text[0]));

            }
            catch (FormatException)
            {
                MessageBox.Show("Onjuiste toetsen geselecteerd");
            }
            
            //int wat = Convert.ToInt32(textBox1.Text[0]);
            //MessageBox.Show(wat.ToString());
        }
        /// <summary>
        /// Selecteer alle tekst als user er in staat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!string.IsNullOrEmpty(tb.Text))
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }
        /// <summary>
        /// Selecteer alle tekst als user er in klikt met de muis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_EnterWithMouse(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!string.IsNullOrEmpty(tb.Text))
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }
    }
}
                
