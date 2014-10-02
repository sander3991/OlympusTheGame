using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Olympus_the_Game.View
{
    /// <summary>
    /// This is a graphical representation of a PlayField.
    /// </summary>
    public partial class GamePanel : UserControl
    {
        /// <summary>
        /// Schaal van het speelveld
        /// </summary>
        public double SCALE { get; private set; }

        /// <summary>
        /// Variabele die Playfield bijhoudt.
        /// </summary>
        private PlayField prop_playfield;

        /// <summary>
        /// Het speelveld dat moet worden getekend.
        /// </summary>
        public PlayField Playfield
        {
            get
            {
                return prop_playfield;
            }
            set
            {
                // Change value and recalculate scale and size
                prop_playfield = value;
                Recalculate();
            }
        }

        /// <summary>
        /// List of images used by this view
        /// </summary>
        //private Dictionary<ObjectType, Bitmap> ImageList = new Dictionary<ObjectType, Bitmap>();

        /// <summary>
        /// De maximale Size die dit GamePanel mag hebben.
        /// Deze wordt gevuld met de eerste gegeven Size.
        /// </summary>
        private Size MAX_SIZE = Size.Empty;

        
        #region Setup

        /// <summary>
        /// Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf) // TODO Specify type
        {
            // Save variables
            this.Playfield = pf;

            InitializeComponent();
        }

        /// <summary>
        /// Lege constructor, deze implementeert het gewone gedrag. Bij aanmaken wordt er gekeken of er een game draait, zo ja, wordt dit speelveld gebruikt.
        /// Als er geen game draait, wordt er een standaard speelveld gebruikt.
        /// </summary>
        public GamePanel()
            : this(OlympusTheGame.INSTANCE == null ? new PlayField(1000, 500) : OlympusTheGame.INSTANCE.Playfield)
        { }

        private void Init(object sender, EventArgs e)
        {
            // Build imagelist
            /*this.ImageList.Add(ObjectType.CREEPER, ConvertBitmap(Properties.Resources.creeper));
            this.ImageList.Add(ObjectType.EXPLODE, ConvertBitmap(Properties.Resources.tnt));
            this.ImageList.Add(ObjectType.SLOWER, ConvertBitmap(Properties.Resources.spider));
            this.ImageList.Add(ObjectType.PLAYER, ConvertBitmap(Properties.Resources.player));
            this.ImageList.Add(ObjectType.TIMEBOMB, ConvertBitmap(Properties.Resources.timebomb));
            this.ImageList.Add(ObjectType.HOME, ConvertBitmap(Properties.Resources.huis));
            this.ImageList.Add(ObjectType.CAKE, ConvertBitmap(Properties.Resources.cake));
            this.ImageList.Add(ObjectType.OBSTACLE, ConvertBitmap(Properties.Resources.cobble));
            this.ImageList.Add(ObjectType.UNKNOWN, ConvertBitmap(Properties.Resources.missing));*/

            // Change border style
            this.BorderStyle = BorderStyle.FixedSingle;

            // Set background
            this.BackgroundImage = Properties.Resources.background;

            // Register to updateloop
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += delegate() { this.Invalidate(); };
        }

        #endregion

        #region Draw Functions

        /// <summary>
        /// Converts Bitmap to BitmapData
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        private Bitmap ConvertBitmap(Bitmap bm)
        {
            return new Bitmap(bm, 50, 50);
        }

        private void draw(GameObject go, Graphics g)
        {

            Size s = new Size((int)((float)go.Width * SCALE),(int)((float)go.Height * SCALE));

            // Generate target rectangle
            Rectangle target = new Rectangle(TranslatePlayFieldToPanel(new Point(go.X, go.Y)), s);

            Bitmap bm = ImagePool.GetPicture(go.Type, s);

            //  Draw picture
            g.DrawImageUnscaledAndClipped(bm,
                target);

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
