using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Olympus_the_Game;

namespace Olympus_the_Game.View
{
    public partial class GameScreen : Form
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        private void Form_Close(object sender, FormClosingEventArgs e)
        {
            // Opent dialoog voor sluiten
            DialogResult dr = MessageBox.Show("Are you sure you want to exit the game? Any unsaved data will be lost."
                , "Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            // Sluit spel af bij JA/YES
            // Sluit dialoog af bij NEE/NO en laat spel verder draaien
            if(dr == DialogResult.Yes)
                OlympusTheGame.INSTANCE.RequestClose();
            else
                e.Cancel = true;
        }


        /// <summary>
        /// Het spel word gestopt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
