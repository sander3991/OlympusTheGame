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
    public partial class GamePanel : UserControl
    {

        /// <summary>
        /// Het speelveld dat moet worden getekend.
        /// </summary>
        private PlayField pf;

        /// <summary>
        /// Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf) // TODO Specify type
        {
            // Save vars
            this.pf = pf;

            // Initialize component
            InitializeComponent();

            // Change border style
            this.BorderStyle = BorderStyle.FixedSingle;

            // Set background
            this.BackgroundImage = Properties.Resources.Background;
        }

        /// <summary>
        /// Lege constructor, om compitabiliteit toe te voegen.
        /// </summary>
        public GamePanel()
            : this(null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintPanel(object sender, PaintEventArgs e)
        {
            Console.WriteLine();
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, 100, System.DateTime.Now.Second % 100, 100, 100);
        }
    }
}
