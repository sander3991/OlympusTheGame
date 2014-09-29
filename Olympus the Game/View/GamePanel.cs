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

        /// <summary>
        /// List of images used by this view
        /// </summary>
        private Dictionary<Type, Bitmap> ImageList = new Dictionary<Type, Bitmap>();

        /// <summary>
        /// Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf) // TODO Specify type
        {
            // Save vars
            this.pf = pf;
            Init();
        }

        public GamePanel()
            : this(OlympusTheGame.INSTANCE == null ? new PlayField(1000, 500) : OlympusTheGame.INSTANCE.pf)
        {}

        private void Init()
        {

            // Build imagelist
            this.ImageList.Add(typeof(EntityCreeper), Properties.Resources.creeper);
            this.ImageList.Add(typeof(EntityExplode), Properties.Resources.tnt);
            this.ImageList.Add(typeof(EntitySlower), Properties.Resources.spider);
            this.ImageList.Add(typeof(EntityPlayer), Properties.Resources.player);
            this.ImageList.Add(typeof(EntityTimeBomb), Properties.Resources.timebomb);
            this.ImageList.Add(typeof(ObjectStart), Properties.Resources.missing);
            this.ImageList.Add(typeof(ObjectFinish), Properties.Resources.cake);
            this.ImageList.Add(typeof(ObjectObstacle), Properties.Resources.dirt);

            // Initialize component
            InitializeComponent();

            // Change border style
            this.BorderStyle = BorderStyle.FixedSingle;

            // Set background
            this.BackgroundImage = Properties.Resources.Background;
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
                bm = Properties.Resources.missing; // TODO Change not implemented picture

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
