using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View
{
    public partial class LevelDialog : Form
    {
        private string Level { get; set; }

        public LevelDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kies het standaard Dungeon level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DungeonLevel_Click(object sender, EventArgs e)
        {
            Level = "Dungeon";
        }

        /// <summary>
        /// Kies het standaard Beach level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeachLevel_Click(object sender, EventArgs e)
        {
            Level = "Beach";
        }

        /// <summary>
        /// Kies het standaard Heaven level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeavenLevel_Click(object sender, EventArgs e)
        {
            Level = "Heaven";
        }

        /// <summary>
        /// Kies het standaard Hell level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HellLevel_Click(object sender, EventArgs e)
        {
            Level = "Hell";
        }

        /// <summary>
        /// Laad een .xml bestand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadXMLfile_Click(object sender, EventArgs e)
        {

        }
    }
}
