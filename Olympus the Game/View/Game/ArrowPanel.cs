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
        /// Kijk of er op het plaatje met pijltjes toetsen is geklikt.
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
        /// Leest een key uit een textbox
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        private Keys GetKeyFromTextbox(TextBox tb)
        {
            try
            {
                Keys key = (Keys)char.ToUpper(tb.Text[0]);
                return (Keys)char.ToUpper(tb.Text[0]);
            }
            catch (FormatException) //Als we het niet kunnen formatten naar een key
            {
                return Keys.None;
            }
            catch (IndexOutOfRangeException) //Als er niks in de string staat, is tb.Text[0] out of bounds, dus null.
            {
                return Keys.None;
            }
        }
        /// <summary>
        /// Zet de meegegegeven textbox contents op de meegegeven key.
        /// </summary>
        /// <param name="tb">de tekstbox</param>
        /// <param name="key">de key</param>
        private void SetTextBoxContents(TextBox tb, Keys key)
        {
            if (key == Keys.None)
                tb.Text = "";
            else
                tb.Text = key.ToString().ToUpper();
        }

        /// <summary>
        /// Verander de controls als de gebruiker een toets wijzigd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Textfield_ChangeControls(object sender, EventArgs e)
        {
            KeyHandler.CustomRight = GetKeyFromTextbox(textBoxRight) ;
            KeyHandler.CustomLeft = GetKeyFromTextbox(textBoxLeft);
            KeyHandler.CustomUp = GetKeyFromTextbox(textBoxUp);
            KeyHandler.CustomDown = GetKeyFromTextbox(textBoxDown);
            SetTextBoxContents(textBoxRight, KeyHandler.CustomRight);
            SetTextBoxContents(textBoxLeft, KeyHandler.CustomLeft);
            SetTextBoxContents(textBoxDown, KeyHandler.CustomDown);
            SetTextBoxContents(textBoxUp, KeyHandler.CustomUp);
        }

        /// <summary>
        ///     Selecteer alle tekst van de textbox als user er in gaat staat
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
        ///     Selecteer alle tekst als user met zijn muis in het textveld gaat staan
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
        /// Functie om de speler stil te zetten
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