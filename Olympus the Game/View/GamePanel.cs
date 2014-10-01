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
        public double SCALE {get; private set;}

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
            this.SCALE = 1.0f;
            Init();
        }

        /// <summary>
        /// Lege constructor, deze implementeert het gewone gedrag. Bij aanmaken wordt er gekeken of er een game draait, zo ja, wordt dit speelveld gebruikt.
        /// Als er geen game draait, wordt er een standaard speelveld gebruikt.
        /// </summary>
        public GamePanel()
            : this(OlympusTheGame.INSTANCE == null ? new PlayField(1000, 500) : OlympusTheGame.INSTANCE.Playfield)
        { }

        private void Init()
        {
            // Build imagelist
            this.ImageList.Add(typeof(EntityCreeper), Properties.Resources.creeper);
            this.ImageList.Add(typeof(EntityExplode), Properties.Resources.tnt);
            this.ImageList.Add(typeof(EntitySlower), Properties.Resources.spider);
            this.ImageList.Add(typeof(EntityPlayer), Properties.Resources.player);
            this.ImageList.Add(typeof(EntityTimeBomb), Properties.Resources.timebomb);
            this.ImageList.Add(typeof(ObjectStart), Properties.Resources.huis);
            this.ImageList.Add(typeof(ObjectFinish), Properties.Resources.cake);
            this.ImageList.Add(typeof(ObjectObstacle), Properties.Resources.cobble);

            // Initialize component
            InitializeComponent();

            // Change border style
            this.BorderStyle = BorderStyle.FixedSingle;
            

            // Set background
            this.BackgroundImage = Properties.Resources.timebomb;
        }

        public void setPlayField(PlayField pf) {
            // Set playfield
            this.pf = pf;
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
            if(pf.Player != null)
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
                TranslatePlayFieldToPanel(new Point(go.X, go.Y)),
                new Size((int)((float)go.Width * SCALE),
                (int)((float)go.Height * SCALE)));

            //  Draw picture
            g.DrawImage(bm,
                target,
                new Rectangle(0, 0, bm.Width, bm.Height),
                System.Drawing.GraphicsUnit.Pixel);

            // Add border
            Pen p = new Pen(Brushes.Black);
            g.DrawRectangle(p, target);
        }

        private void Panel_resized(object sender, EventArgs e)
        {
            // Fix playfield scaling
            double ratioWidth = (double)this.pf.WIDTH / (double)this.Size.Width;
            double ratioHeight = (double)this.pf.HEIGHT / (double)this.Size.Height;
            this.SCALE = (double)1 / Math.Max(ratioWidth, ratioHeight);
            this.Size = new Size((int)((double)this.pf.WIDTH * SCALE), (int)((double)this.pf.HEIGHT * SCALE));
        }

        public Point TranslatePanelToPlayField(Point p)
        {
            return new Point((int)((double) p.X / SCALE), (int)((double) p.Y / SCALE));
        }

        public Point TranslatePlayFieldToPanel(Point p)
        {
            return new Point((int)((double)p.X * SCALE), (int)((double)p.Y * SCALE));
        }

        public Point getCursorPosition()
        {
            return this.PointToClient(Cursor.Position);
        }

        public Point getCursorPlayFieldPosition()
        {
            return TranslatePanelToPlayField(getCursorPosition());
        }
    }
}
