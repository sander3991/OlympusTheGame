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
        /// Schaal van het speelveld
        /// </summary>
        private float SCALE = 1.0f;

        /// <summary>
        /// Het speelveld dat moet worden getekend.
        /// </summary>
        private PlayField pf;

        private Dictionary<Type, Bitmap> ImageList = new Dictionary<Type, Bitmap>();

        /// <summary>
        /// Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf) // TODO Specify type
        {
            // Save vars
            this.pf = OlympusTheGame.INSTANCE.pf;
            this.pf.AddObject(new ObjectStart(50, 50, 0, 0));
            this.pf.AddObject(new ObjectFinish(150, 150, 800, 300));
            this.pf.AddObject(new ObjectObstacle(50, 50, 60, 0));
            this.pf.AddObject(new EntityCreeper(50, 50, 150, 60, 1.0f));
            this.pf.AddObject(new EntityExplode(50, 50, 150, 0, 1.0f));
            this.pf.AddObject(new EntityPlayer(50, 50, 0, 0));
            this.pf.AddObject(new EntitySlower(50, 50, 200, 150));
            this.pf.AddObject(new EntityTimeBomb(50, 50, 600, 75, 1.0f));

            // Build imagelist
            this.ImageList.Add(typeof(EntityCreeper), Properties.Resources.creeper);
            this.ImageList.Add(typeof(EntityExplode), Properties.Resources.tnt);
            this.ImageList.Add(typeof(EntitySlower), Properties.Resources.spider);
            this.ImageList.Add(typeof(EntityPlayer), Properties.Resources.player);

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
                draw(go, e.Graphics);
            }

            // Draw player
            draw(pf.Player, e.Graphics);
        }

        private void draw(GameObject go, Graphics g)
        {
            // Select bitmap
            Bitmap bm = null;
            ImageList.TryGetValue(go.GetType(), out bm);
            if (bm == null)
                bm = Properties.Resources.rsz_arrowup; // TODO Change not implemented picture

            // Generate target rectangle
            Rectangle target = new Rectangle(
                (int)((float)go.X * SCALE),
                (int)((float)go.Y * SCALE),
                (int)((float)go.Width * SCALE),
                (int)((float)go.Height * SCALE));

            //  Draw picture
            g.DrawImage(bm,
                target,
                new Rectangle(0, 0, bm.Width, bm.Height),
                System.Drawing.GraphicsUnit.Pixel);

            // Add border
            Pen p = new Pen(Brushes.Black);
            g.DrawRectangle(p, target);
        }
    }
}
