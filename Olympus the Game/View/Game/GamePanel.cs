using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game.View.Game
{
    /// <summary>
    /// This is a graphical representation of a PlayField.
    /// </summary>
    public partial class GamePanel : UserControl
    {
        /// <summary>
        /// Padding van het speelveld, deze rand wordt er altijd omheen gehouden.
        /// </summary>
        private static readonly int PADDING = 35;

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
        public GamePanel(PlayField pf)
        {
            // Save variables
            this.Playfield = pf;

            // Initialize GUI
            InitializeComponent();
        }

        /// <summary>
        /// Lege constructor, deze implementeert het gewone gedrag. Bij aanmaken wordt er gekeken of er een game draait, zo ja, wordt dit speelveld gebruikt.
        /// Als er geen game draait, wordt er een standaard speelveld gebruikt.
        /// </summary>
        public GamePanel()
            : this(new PlayField(1000, 500))
        { }

        private void Init(object sender, EventArgs e)
        {
            // Change border style
            this.BorderStyle = BorderStyle.FixedSingle;

            // Set background
            this.BackgroundImage = Properties.Resources.background;

            // Register to updateloop
            if (OlympusTheGame.GameController != null)
                OlympusTheGame.GameController.UpdateGameEvents += delegate { this.Invalidate(); };

            // Set max size
            this.MaxSize = this.Size;

            // Recalculate size
            Recalculate();
        }

        #endregion

        #region Draw Functions

        private void draw(GameObject go, Graphics g)
        {
            // Get preferred size and location
            Size s = new Size((int)((float)go.Width * SCALE), (int)((float)go.Height * SCALE));
            Point p = TranslatePlayFieldToPanel(new Point(go.X, go.Y));

            // Generate target rectangle
            Rectangle target = new Rectangle(p, s);

            // Retrieve appropriate image
            Sprite bm = DataPool.GetPicture(go.Type, s);

            //  Draw picture
            g.DrawImageUnscaled(bm[go.Frame], target);
        }

        private void Repaint(Graphics g)
        {
            List<GameObject> objects = Playfield.GameObjects;

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
            double ratioWidth = (double)this.Playfield.Width / (double)MaxSize.Width;
            double ratioHeight = (double)this.Playfield.Height / (double)MaxSize.Height;
            this.SCALE = (double)1 / Math.Max(ratioWidth, ratioHeight);
            this.Size = new Size((int)((double)this.Playfield.Width * SCALE), (int)((double)this.Playfield.Height * SCALE));

            // Empty image buffer
            DataPool.ClearImagePool();
        }

        /// <summary>
        /// Tries to expand this GamePanel as far as possible.
        /// </summary>
        public void TryExpand()
        {
            // Get parent form
            Form parent = this.FindForm();

            if (parent == null)
            {
                Recalculate();
                return;
            }

            this.Size = new Size(0, 0);

            // Initial values
            float ratio = (float)this.Playfield.Width / (float)this.Playfield.Height;
            Point pt = parent.PointToClient(new Point(parent.Location.X + parent.Width, parent.Location.Y + parent.Height));
            Size currentSize = new Size(pt.X, pt.Y);
            Size minimalSize = new Size((int)(ratio * 100.0f), 100);
            currentSize = ScaleDown(currentSize, new Point(parent.Width, parent.Height), ratio);
            int barHeight = 0;

            // Loop objects
            foreach (Control c in parent.Controls)
            {
                if (c != this && c.Visible)
                {
                    if (c.GetType() == typeof(MenuStrip))
                    {
                        barHeight = c.Height;
                    }
                    else
                    {
                        // Get control location
                        Point p = c.Location;

                        currentSize = ScaleDown(currentSize, p, ratio);
                    }
                }
            }

            // Change size
            this.Location = new Point(PADDING, PADDING + barHeight);
            this.MaxSize = new Size(currentSize.Width - 2 * PADDING, currentSize.Height - 2 * PADDING - barHeight);
            this.MaxSize = new Size(Math.Max(MaxSize.Width, minimalSize.Width), Math.Max(MaxSize.Height, minimalSize.Height));
            // Recalculate
            Recalculate();
        }

        private Size ScaleDown(Size s, Point p, float ratio)
        {
            // Shrink so it fits
            if ((float)p.X / (float)p.Y > ratio)
            {
                if (p.X < s.Width)
                    return new Size(p.X, (int)((float)p.X / ratio));
            }
            else
            {
                if (p.Y < s.Height)
                    return new Size((int)((float)p.Y * ratio), p.Y);
            }
            return s;
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
