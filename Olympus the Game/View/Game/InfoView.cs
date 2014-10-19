using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.Model.Entities;

namespace Olympus_the_Game.View.Game
{
    public partial class InfoView : UserControl
    {
        // Muis positie bijhouden deze wordt gebruikt bij het verslepen van het scherm

        // Een Dictionary om alle game entitys in op te slaan
        private Dictionary<Entity, ListViewItem> list;

        public InfoView()
        {
            InitializeComponent();
        }

        public Point MouseDownLocation { get; set; }
        // Het scherm moet 1 keer worden geresized in de Update zet hij deze op false
        public bool IsResized { get; set; }

        /// <summary>
        /// Functie die wordt aangeroepen en alle object laad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            if (OlympusTheGame.Playfield == null) return;
            DoubleBuffered = false;
            //if(OlympusTheGame.GameController != null)
            //    OlympusTheGame.GameController.UpdateSlowEvents += update;

            IsResized = false;
            list = new Dictionary<Entity, ListViewItem>();
            // Initialiseer de eerste lijst
            List<GameObject> entitys = OlympusTheGame.Playfield.GameObjects;

            foreach (GameObject g in entitys)
            {
                Entity ent = g as Entity;

                if (ent != null)
                {
                    if (ent.Visible)
                    {
                        list[ent] = CreateListViewItem(ent);
                        ent.OnMoved += ent_OnMoved;
                    }
                    ent.OnVisibilityChanged += ent_OnVisibilityChanged;
                }
            }
            OlympusTheGame.Playfield.OnObjectAdded += Playfield_OnObjectAdded;
            OlympusTheGame.Playfield.OnObjectRemoved += Playfield_OnObjectRemoved;
            OlympusTheGame.OnNewPlayField += delegate { list.Clear(); }; // TODO Uitbreiden deze doet het niet

            if (!IsResized)
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                IsResized = true;
            }
        }

        void ent_OnVisibilityChanged(GameObject go, bool visible)
        {
            Entity e = go as Entity;
            if (e == null) return;
            if (visible && !list.ContainsKey(e))
            {
                list[e] = CreateListViewItem(e);
                e.OnMoved += ent_OnMoved;
            }
            else if (!visible)
            {
                if (list.ContainsKey(e))
                {
                    ListViewItem item = list[e];
                    if (item != null)
                    {
                        list[e].Remove();
                        list.Remove(e);
                        e.OnMoved -= ent_OnMoved;
                    }
                }
            }

        }

        /// <summary>
        /// Als een object toegevoegd wordt, update dan de listview en koppel het OnMoved event
        /// </summary>
        /// <param name="go"></param>
        private void Playfield_OnObjectAdded(GameObject go)
        {
            Entity e = go as Entity;
            if (e != null)
            {
                list[e] = CreateListViewItem(e);
                e.OnMoved += ent_OnMoved;
            }
        }

        /// <summary>
        /// Als een object van het speelveld afgaat dan wordt het object weggehaald
        /// </summary>
        /// <param name="go"></param>
        private void Playfield_OnObjectRemoved(GameObject go)
        {
            Entity e = go as Entity;
            if (e != null)
            {
                if (list.ContainsKey(e))
                {
                    ListViewItem item = list[e];
                    if (item != null)
                    {
                        list[e].Remove();
                        list.Remove(e);
                        e.OnMoved -= ent_OnMoved;
                        e.OnVisibilityChanged -= ent_OnVisibilityChanged;
                    }
                }
            }
        }

        /// <summary>
        /// Update de text in listview als de entity wordt bewogen
        /// </summary>
        /// <param name="e">Entity die moet worden geupdate</param>
        private void ent_OnMoved(Entity e)
        {
            if (list.ContainsKey(e))
            {
                ListViewItem lvItem = list[e];
                lvItem.SubItems[1].Text = e.X.ToString();
                lvItem.SubItems[2].Text = e.Y.ToString();
                lvItem.SubItems[3].Text = Math.Abs(e.DX + e.DY).ToString();
            }
        }

        /// <summary>
        /// Methode om een item aan de listview toe te voegen
        /// </summary>
        /// <param name="e">Entity die je wilt toevoegen</param>
        /// <returns></returns>
        private ListViewItem CreateListViewItem(Entity e)
        {
            ListViewItem lvItem = new ListViewItem(e.ToString());
            lvItem.SubItems.Add(e.X.ToString());
            lvItem.SubItems.Add(e.Y.ToString());
            lvItem.SubItems.Add(Math.Abs(e.DX + e.DY).ToString());
            listView1.Items.Add(lvItem);
            return lvItem;
        }
    }
}