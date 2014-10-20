using System;
using System.Windows.Forms;
using Olympus_the_Game.Controller;

namespace Olympus_the_Game.View.Game
{
    public partial class ArrowPanel : UserControl
    {
        public ArrowPanel()
        {
            InitializeComponent();
            // Speler kan maximaal 1 toets per textveld in vullen
            textBoxRight.MaxLength = 1;
            textBoxLeft.MaxLength = 1;
            textBoxUp.MaxLength = 1;
            textBoxDown.MaxLength = 1;
        }

        /// <summary>
        ///     Kijk of er op het plaatje met pijltjes toetsen is geklikt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArrowKey_MouseDown(object sender, MouseEventArgs e)
        {
            var b = sender as Button;
            if (b != null)
            {
                // Pak de naam van van de button waarom de gebruiker heeft geklikt
                string richting = b.Name;
                // Kijk aan de hand van deze naam welke richting de gebruiker wil
                if (richting == "ArrowKeyRight")
                    KeyHandler.MovePlayer(2, true);
                if (richting == "ArrowKeyLeft")
                    KeyHandler.MovePlayer(-2, true);
                if (richting == "ArrowKeyUp")
                    KeyHandler.MovePlayer(-2, false);
                if (richting == "ArrowKeyDown")
                    KeyHandler.MovePlayer(2, false);
            }
        }

        /// <summary>
        ///     Verander de controls als de gebruiker een toets wijzigd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textfield_ChangeControls(object sender, EventArgs e)
        {
            try
            {
                // Als de tekst in de textbox niet null is, wordt de letter die is ingevoerd ingsteld als toets
                if (!string.IsNullOrEmpty(textBoxRight.Text))
                    KeyHandler.CustomRight =
                        (Keys) char.ToUpper(textBoxRight.Text[0]);
                if (!String.IsNullOrEmpty(textBoxLeft.Text))
                    KeyHandler.CustomLeft =
                        (Keys) char.ToUpper(textBoxLeft.Text[0]);
                if (!String.IsNullOrEmpty(textBoxUp.Text))
                    KeyHandler.CustomUp =
                        (Keys) char.ToUpper(textBoxUp.Text[0]);
                if (!String.IsNullOrEmpty(textBoxDown.Text))
                    KeyHandler.CustomDown =
                        (Keys) char.ToUpper(textBoxDown.Text[0]);
            }
            catch (FormatException)
            {
                MessageBox.Show("Onjuiste toetsen geselecteerd");
            }
        }

        /// <summary>
        /// Selecteer alle tekst van de textbox als user er in gaat staat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null && !string.IsNullOrEmpty(tb.Text))
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }

        /// <summary>
        /// Selecteer alle tekst als user met zijn muis in het textveld gaat staan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_EnterWithMouse(object sender, MouseEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null && !string.IsNullOrEmpty(tb.Text))
            {
                tb.SelectionStart = 0;
                tb.SelectionLength = tb.Text.Length;
            }
        }

        /// <summary>
        ///     Functie om de speler stil te zetten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopMoving(object sender, MouseEventArgs e)
        {
            KeyHandler.MovePlayer(0, true);
            KeyHandler.MovePlayer(0, false);
        }
    }
}