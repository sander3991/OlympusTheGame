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
        public double SCALE { get; private set; }

        /// <summary>
        /// Het speelveld dat moet worden getekend.
        /// </summary>
        private PlayField prop_playfield;
        public PlayField Playfield
        {
            get
            {
                return prop_playfield;
            }
            set
            {
                prop_playfield = value;
                Recalculate();
            }
        }

        /// <summary>
        /// List of images used by this view
        /// </summary>
        private Dictionary<Type, Bitmap> ImageList = new Dictionary<Type, Bitmap>();

        private Size MAX_SIZE = Size.Empty;

        #region Setup

        /// <summary>
        /// Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf) // TODO Specify type
        {
            // Save vars
            this.Playfield = pf;
            this.SCALE = 1.0f;
            Init();

            // Register to update
            OlympusTheGame.INSTANCE.Controller.UpdateEvents += () => { this.Invalidate(); };
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

        #endregion

        #region Draw Functions

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

        private void Repaint(Graphics g)
        {
            List<GameObject> objects = Playfield.GetObjects();

            // Loop through all gameobjects
            foreach (GameObject go in objects)
            {
                draw(go, g);
            }

            // Draw player
            if (Playfield.Player != null)
                draw(Playfield.Player, g);
        }

        #endregion

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintPanel(object sender, PaintEventArgs e)
        {
            Repaint(e.Graphics);
        }

        private void Panel_resized(object sender, EventArgs e)
        {
            if (Size.Empty.Equals(MAX_SIZE))
                MAX_SIZE = this.Size;
            Recalculate();
        }

        #endregion

        #region ScaleFunctions

        public Point TranslatePanelToPlayField(Point p)
        {
            return new Point((int)((double)p.X / SCALE), (int)((double)p.Y / SCALE));
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

        public void Recalculate()
        {
            // Fix playfield scaling
            double ratioWidth = (double)this.Playfield.WIDTH / (double)MAX_SIZE.Width;
            double ratioHeight = (double)this.Playfield.HEIGHT / (double)MAX_SIZE.Height;
            this.SCALE = (double)1 / Math.Max(ratioWidth, ratioHeight);
            this.Size = new Size((int)((double)this.Playfield.WIDTH * SCALE), (int)((double)this.Playfield.HEIGHT * SCALE));
        }

        #endregion

        #region Locations

        public GameObject getObjectAtCursor()
        {
            Point p = this.getCursorPlayFieldPosition();
            // Get list of objects at that location
            List<GameObject> objects = this.Playfield.GetObjectsAtLocation(p.X, p.Y);

            // If there is a last object, return it
            if (objects != null && objects.Count > 0)
            {
                return objects.Last();
            }
            else // Else return null
            {
                return null;
            }
        }

        #endregion
    }
}
