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
        public ArrowPanel()
        {
            InitializeComponent();
        }

        private void ArrowKeyUp_Click(object sender, EventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(sender);
        }


    }
}
