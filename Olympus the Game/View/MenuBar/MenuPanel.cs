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
    public partial class MenuPanel : UserControl
    {
        // Mouse location om het panel te verslepen
        public Point MouseDownLocation { get; set; }
        public MenuPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sluit het spel door the Close functie te gebruiken van het bovenliggende form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitGame_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// Laad een dialog waarin uit standaard levels gekozen kan worden en waar
        /// een .xml bestand kan worden ingeladen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadLevel_Click(object sender, EventArgs e)
        {
            LevelDialog ld = new LevelDialog();
            ld.ShowDialog();
        }

        private void LevelEditor_Click(object sender, EventArgs e)
        {
            LevelEditor le = new LevelEditor();
            le.ShowDialog();
        }

        /// <summary>
        /// Functie om het panel op runtime te verslepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveButton_MouseDown(object sender, MouseEventArgs e)
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
        private void MoveButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }
    }
}
