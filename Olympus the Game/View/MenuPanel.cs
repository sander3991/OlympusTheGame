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
    }
}
