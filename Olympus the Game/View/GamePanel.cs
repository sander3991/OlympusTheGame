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
        private static int BLOCK_SIZE = 50;
        private static float SCALE = 1.0f;
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
            this.pf = OlympusTheGame.INSTANCE.pf;
            this.pf.AddObject(new ObjectStart(50, 50, 0, 0));
            this.pf.AddObject(new ObjectFinish(50, 50, 800, 300));
            this.pf.AddObject(new ObjectObstacle(50, 50, 60, 0));
            this.pf.AddObject(new EntityCreeper(50, 50, 150, 60, 1.0f));
            this.pf.AddObject(new EntityExplode(50, 50, 150, 0, 1.0f));
            this.pf.AddObject(new EntityPlayer(50, 50, 0, 0));
            this.pf.AddObject(new EntitySlower(50, 50, 200, 150));
            this.pf.AddObject(new EntityTimeBomb(50, 50, 600, 75, 1.0f));

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
            List<GameObject> objects = pf.GetObjects();

            // Loop through all gameobjects
            foreach (GameObject go in objects)
            {
                e.Graphics.FillRectangle(Brushes.Black, go.X * SCALE, go.Y * SCALE, BLOCK_SIZE, BLOCK_SIZE);
            }
        }
    }
}
