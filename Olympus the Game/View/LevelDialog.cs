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
        /// <summary>
        /// Deze waarde geeft de levelnaam van het gekozen level aan
        /// </summary>
        private string Level { get; set; } //TODO Martijn: Waarom een property als het private is? Is hij nodig? 0 references?
        public PlayField Playfield { get; private set; }
        public LevelDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiest één van de 4 levels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LevelSelect_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string tag = button.Tag as string;
                if(tag != null)
                {
                    string xmlContents = "";
                    switch (tag)
                    {
                        case "BEACH":
                            xmlContents = Properties.Resources.beach;
                            break;
                        case "HELL":
                            xmlContents = Properties.Resources.hell;
                            break;
                        case "HEAVEN":
                            //TODO add Heaven level
                            xmlContents = Properties.Resources.beach;
                            break;
                        case "DUNGEON":
                            //TODO add Dungeon level
                            xmlContents = Properties.Resources.beach;
                            break;
                    }
                    if(xmlContents.Length != 0)
                        Playfield = PlayFieldToXml.ReadFromResource(xmlContents);
                    Close();

                }
            }
        }

        /// <summary>
        /// Laad een .xml bestand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadXMLfile_Click(object sender, EventArgs e)
        {

            System.IO.Stream fileStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            // als er op OK word gedrukt
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // en er is een bestand geselecteerd
                if ((fileStream = openFileDialog1.OpenFile()) != null)
                {
                    PlayField pf = PlayFieldToXml.ReadFromXml(fileStream);
                    if(pf != null)
                        OlympusTheGame.SetNewPlayfield(pf);
                    Close();
                }
            }
        }
    }
}
