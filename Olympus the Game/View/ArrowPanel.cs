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
            this.DoubleBuffered = true;
            
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
            if (richting == "ArrowKeyRight")
                KeyHandler.MovePlayer(2, true);
            if (richting == "ArrowKeyLeft")
                KeyHandler.MovePlayer(-2, true);
            if (richting == "ArrowKeyUp")
                KeyHandler.MovePlayer(-2, false);
            if (richting == "ArrowKeyDown")
                KeyHandler.MovePlayer(2, false);
        }
        
        /// <summary>
        /// Functie om de speler stil te zetten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopMoving(object sender, MouseEventArgs e)
        {
            KeyHandler.MovePlayer(0, true);
            KeyHandler.MovePlayer(0, false);
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
            this.BackColor = Color.Transparent;
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
                if (!string.IsNullOrEmpty(textBoxRight.Text))
                    KeyHandler.CustomRight =
                        (Keys)char.ToUpper(textBoxRight.Text[0]);
                if (!String.IsNullOrEmpty(textBoxLeft.Text))
                    KeyHandler.CustomLeft =
                        (Keys)char.ToUpper(textBoxLeft.Text[0]);
                if (!String.IsNullOrEmpty(textBoxUp.Text))
                    KeyHandler.CustomUp =
                        (Keys)char.ToUpper(textBoxUp.Text[0]);
                if (!String.IsNullOrEmpty(textBoxDown.Text))
                    KeyHandler.CustomDown =
                        (Keys)char.ToUpper(textBoxDown.Text[0]);
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
                
