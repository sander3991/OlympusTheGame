﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.Properties;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game.View.Game
{
    /// <summary>
    ///     This is a graphical representation of a PlayField.
    /// </summary>
    public partial class GamePanel : UserControl
    {
        #region Properties

        /// <summary>
        ///     Padding van het speelveld, deze rand wordt er altijd omheen gehouden.
        /// </summary>
        private const int BorderPadding = 35;

        /// <summary>
        ///     Variabele die Playfield bijhoudt.
        /// </summary>
        private PlayField _propPlayfield;

        /// <summary>
        ///     Schaal van het speelveld
        /// </summary>
        public double PlayfieldScale { get; private set; }

        /// <summary>
        ///     Het speelveld dat moet worden getekend.
        /// </summary>
        public PlayField Playfield
        {
            get { return _propPlayfield; }
            set
            {
                // Change value and recalculate scale and size
                _propPlayfield = value;
                Recalculate();
            }
        }

        /// <summary>
        ///     De maximale Size die dit GamePanel mag hebben.
        ///     Deze wordt gevuld met de eerste gegeven Size.
        /// </summary>
        public Size MaxSize { get; private set; }

        #endregion

        #region Setup

        /// <summary>
        ///     Maak een nieuw GamePanel aan, deze krijgt als argument het model mee welke moet worden getekend.
        /// </summary>
        public GamePanel(PlayField pf)
        {
            // Save variables
            Playfield = pf;

            // Initialize GUI
            InitializeComponent();
        }

        /// <summary>
        ///     Lege constructor, deze implementeert het gewone gedrag. Bij aanmaken wordt er gekeken of er een game draait, zo ja,
        ///     wordt dit speelveld gebruikt.
        ///     Als er geen game draait, wordt er een standaard speelveld gebruikt.
        /// </summary>
        public GamePanel()
            : this(new PlayField(1000, 500))
        {
        }

        private void Init(object sender, EventArgs e)
        {
            // Change border style
            BorderStyle = BorderStyle.FixedSingle;

            // Set background
            BackgroundImage = Resources.background;

            // Register to updateloop
            if (OlympusTheGame.GameController != null)
                OlympusTheGame.GameController.UpdateGameEvents += Invalidate;

            // Set max size
            MaxSize = Size;

            // Recalculate size
            Recalculate();
        }

        #endregion

        #region Draw Functions

        private void Draw(GameObject go, Graphics g)
        {
            // Get preferred size and location
            var s = new Size((int) (go.Width*PlayfieldScale), (int) (go.Height*PlayfieldScale));
            Point p = TranslatePlayFieldToPanel(new Point(go.X, go.Y));

            // Generate target rectangle
            var target = new Rectangle(p, s);

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
                if (go.Visible)
                {
                    Draw(go, g);
                }
            }

            // Draw player
            if (Playfield.Player != null)
                Draw(Playfield.Player, g);
        }

        #endregion

        #region Events

        /// <summary>
        ///     Wordt aangeroepen als dit Panel opnieuw moet worden getekenend.
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
        ///     Vertaal punt van Panel coordinaten naar PlayField coordinaten
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point TranslatePanelToPlayField(Point p)
        {
            return new Point((int) (p.X/PlayfieldScale), (int) (p.Y/PlayfieldScale));
        }

        /// <summary>
        ///     Vertaal punt van PlayField coordinaten naar Panel coordinaten
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point TranslatePlayFieldToPanel(Point p)
        {
            return new Point((int) (p.X*PlayfieldScale), (int) (p.Y*PlayfieldScale));
        }

        /// <summary>
        ///     Geeft de locatie van de cursor ten opzichte van dit panel.
        /// </summary>
        /// <returns></returns>
        public Point GetCursorPosition()
        {
            return PointToClient(Cursor.Position);
        }

        /// <summary>
        ///     Geeft de locatie van de cursor in coordinaten van het PlayField
        /// </summary>
        /// <returns></returns>
        public Point GetCursorPlayFieldPosition()
        {
            return TranslatePanelToPlayField(GetCursorPosition());
        }

        /// <summary>
        ///     Berekent opnieuw de schaal van dit GamePanel, en past deze daar op aan.
        /// </summary>
        public void Recalculate()
        {
            // Fix playfield scaling
            double ratioWidth = Playfield.Width/(double) MaxSize.Width;
            double ratioHeight = Playfield.Height/(double) MaxSize.Height;
            PlayfieldScale = 1/Math.Max(ratioWidth, ratioHeight);
            Size = new Size((int) (Playfield.Width*PlayfieldScale), (int) (Playfield.Height*PlayfieldScale));

            // Empty image buffer
            DataPool.ClearImagePool();
        }

        /// <summary>
        ///     Tries to expand this GamePanel as far as possible.
        /// </summary>
        public void TryExpand()
        {
            // Get parent form
            Form parent = FindForm();

            if (parent == null)
            {
                Recalculate();
                return;
            }

            Size = new Size(0, 0);

            // Initial values
            float ratio = Playfield.Width/(float) Playfield.Height;
            Point pt =
                parent.PointToClient(new Point(parent.Location.X + parent.Width, parent.Location.Y + parent.Height));
            var currentSize = new Size(pt.X, pt.Y);
            var minimalSize = new Size((int) (ratio*100.0f), 100);
            currentSize = ScaleDown(currentSize, new Point(parent.Width, parent.Height), ratio);
            int barHeight = 0;
            int pad = 0;

            // Loop objects
            foreach (Control c in from Control c in parent.Controls where c != this && c.Visible select c)
            {
                if (c.GetType() == typeof (MenuStrip))
                {
                    barHeight = c.Height;
                }
                else
                {
                    pad = BorderPadding;
                    // Get control location
                    Point p = c.Location;

                    currentSize = ScaleDown(currentSize, p, ratio);
                }
            }

            // Change size
            Location = new Point(pad, pad + barHeight);
            MaxSize = new Size(currentSize.Width - 2*pad, currentSize.Height - 2*pad - barHeight);
            MaxSize = new Size(Math.Max(MaxSize.Width, minimalSize.Width), Math.Max(MaxSize.Height, minimalSize.Height));
            // Recalculate
            Recalculate();
        }

        private static Size ScaleDown(Size s, Point p, float ratio)
        {
            // Shrink so it fits
            if (p.X/(float) p.Y > ratio)
            {
                if (p.X < s.Width)
                    return new Size(p.X, (int) (p.X/ratio));
            }
            else
            {
                if (p.Y < s.Height)
                    return new Size((int) (p.Y*ratio), p.Y);
            }
            return s;
        }

        #endregion

        #region Locations

        /// <summary>
        ///     Geeft het object terug waar de cursor op dit moment op staat.
        /// </summary>
        /// <returns></returns>
        public GameObject GetObjectAtCursor()
        {
            Point p = GetCursorPlayFieldPosition();
            // Get list of objects at that location
            List<GameObject> objects = Playfield.GetObjectsAtLocation(p.X, p.Y);

            // If there is a last object, return it
            if (objects != null && objects.Count > 0)
            {
                return objects.Last();
            }
            return null;
        }

        #endregion
    }
}