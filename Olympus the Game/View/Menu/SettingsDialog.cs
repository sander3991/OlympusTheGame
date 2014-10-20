using System;
using System.Windows.Forms;
using Olympus_the_Game.Controller;

namespace Olympus_the_Game.View.Menu
{
    public partial class SettingsDialog : UserControl
    {
        public SettingsDialog()
        {
            InitializeComponent();
            SoundEnabled = Mp3Player.Enabled;
        }
        
        public bool SoundEnabled { get; private set; }

        /// <summary>
        /// Als user hier op klikt zet dan het geluid aan of uit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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