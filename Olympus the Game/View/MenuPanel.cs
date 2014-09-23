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

        private void QuitGame_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void PauseGame_Click(object sender, EventArgs e)
        {

        }
    }
}
