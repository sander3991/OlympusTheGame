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
using Olympus_the_Game.View.Imaging;

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
        /// De maximale Size die dit GamePanel mag hebben.
        /// Deze wordt gevuld met de eerste gegeven Size.
        /// </summary>
        public Size MaxSize { get; private set; }


        #region Setup

        /// <summary>
        /// Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf) // TODO Specify type
        {
            // Save variables
            this.Playfield = pf;
            this.MaxSize = Size.Empty;

            // Initialize GUI
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
            // Change border style
            this.BorderStyle = BorderStyle.FixedSingle;

            // Set background
            this.BackgroundImage = Properties.Resources.background;

            // Register to updateloop
            if (OlympusTheGame.INSTANCE != null)
                OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += delegate() { this.Invalidate(); };
        }

        #endregion

        #region Draw Functions

        private void draw(GameObject go, Graphics g)
        {
            Size s = new Size((int)((float)go.Width * SCALE), (int)((float)go.Height * SCALE));
            Point p = TranslatePlayFieldToPanel(new Point(go.X, go.Y));
            // Generate target rectangle
            Rectangle target = new Rectangle(p, s);

            Sprite bm = ImagePool.GetPicture(go.Type, s);



            //  Draw picture
            g.DrawImageUnscaled(bm[go.Frame], target);
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
        /// Wordt aangeroepen als dit Panel opnieuw moet worden getekenend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaintPanel(object sender, PaintEventArgs e)
        {
            Repaint(e.Graphics);
        }

        /// <summary>
        /// Wordt aangeroepen als dit Panel van grootte wordt veranderd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_resized(object sender, EventArgs e)
        {
            if (Size.Empty.Equals(MaxSize))
                MaxSize = this.Size;
            Recalculate();
        }

        #endregion

        #region ScaleFunctions

        /// <summary>
        /// Vertaal punt van Panel coordinaten naar PlayField coordinaten
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point TranslatePanelToPlayField(Point p)
        {
            return new Point((int)((double)p.X / SCALE), (int)((double)p.Y / SCALE));
        }

        /// <summary>
        /// Vertaal punt van PlayField coordinaten naar Panel coordinaten
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point TranslatePlayFieldToPanel(Point p)
        {
            return new Point((int)((double)p.X * SCALE), (int)((double)p.Y * SCALE));
        }

        /// <summary>
        /// Geeft de locatie van de cursor ten opzichte van dit panel.
        /// </summary>
        /// <returns></returns>
        public Point getCursorPosition()
        {
            return this.PointToClient(Cursor.Position);
        }

        /// <summary>
        /// Geeft de locatie van de cursor in coordinaten van het PlayField
        /// </summary>
        /// <returns></returns>
        public Point getCursorPlayFieldPosition()
        {
            return TranslatePanelToPlayField(getCursorPosition());
        }

        /// <summary>
        /// Berekent opnieuw de schaal van dit GamePanel, en past deze daar op aan.
        /// </summary>
        public void Recalculate()
        {
            // Fix playfield scaling
            double ratioWidth = (double)this.Playfield.WIDTH / (double)MaxSize.Width;
            double ratioHeight = (double)this.Playfield.HEIGHT / (double)MaxSize.Height;
            this.SCALE = (double)1 / Math.Max(ratioWidth, ratioHeight);
            this.Size = new Size((int)((double)this.Playfield.WIDTH * SCALE), (int)((double)this.Playfield.HEIGHT * SCALE));
        }

        #endregion

        #region Locations

        /// <summary>
        /// Geeft het object terug waar de cursor op dit moment op staat.
        /// </summary>
        /// <returns></returns>
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
