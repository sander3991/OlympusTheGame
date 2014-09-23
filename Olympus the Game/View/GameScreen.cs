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
            // Sluit spel af
            OlympusTheGame.INSTANCE.RequestClose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
