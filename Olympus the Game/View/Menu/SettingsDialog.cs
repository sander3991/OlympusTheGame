using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View.Menu
{
    public partial class SettingsDialog : UserControl
    {
        public bool SoundEnabled { get; private set; }

        public SettingsDialog()
        {
            InitializeComponent();
            SoundEnabled = Mp3Player.Enabled;
        }

        private void ButtonGeluidDempen_Click(object sender, EventArgs e)
        {
            if (!SoundEnabled)
            {
                Mp3Player.Enabled = true;
                SoundEnabled = true;
                ButtonGeluidDempen.Text = "Geluid uitzetten";
            }
            else
            {
                Mp3Player.Enabled = false;
                SoundEnabled = false;
                ButtonGeluidDempen.Text = "Geluid aanzetten";
                
            }
                
        }
    }
}
