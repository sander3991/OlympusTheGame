using Olympus_the_Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Drawing;

namespace Olympus_the_Game.View
{
    public partial class InfoView : UserControl
    {
        // Muis positie bijhouden deze wordt gebruikt bij het verslepen van het scherm
        public Point MouseDownLocation { get; set; }
        // Het scherm moet 1 keer worden geresized in de Update zet hij deze op false
        public bool IsResized { get; set; }

        // Een Dictionary om alle game entitys in op te slaan
        private Dictionary<Entity, ListViewItem> list;
        public InfoView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Functie die wordt aangeroepen en alle object laad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, EventArgs e)
        {
            if (OlympusTheGame.Playfield == null) return;
            this.DoubleBuffered = false;
            //if(OlympusTheGame.Controller != null)
            //    OlympusTheGame.Controller.UpdateSlowEvents += update;

            IsResized = false;
            list = new Dictionary<Entity, ListViewItem>();
            // Initialiseer de eerste lijst
            List<GameObject> Entitys = OlympusTheGame.Playfield.GameObjects;

            foreach (GameObject g in Entitys)
            {
                Entity ent = g as Entity;

                if (ent != null)
                {
                    list[ent] = CreateListViewItem(ent);
                    ent.OnMoved += ent_OnMoved;
                }
            }
            OlympusTheGame.Playfield.OnObjectAdded += Playfield_OnObjectAdded;
            OlympusTheGame.Playfield.OnObjectRemoved += Playfield_OnObjectRemoved;
            OlympusTheGame.OnNewPlayField += delegate(PlayField p) { list.Clear(); }; // TODO Uitbreiden deze doet het niet

            if (!IsResized)
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                IsResized = true;
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
                ListViewItem LVItem = list[e];
                LVItem.SubItems[1].Text = e.X.ToString();
                LVItem.SubItems[2].Text = e.Y.ToString();
                LVItem.SubItems[3].Text = Math.Abs(e.DX + e.DY).ToString();
            }

        }

        /// <summary>
        /// Functie om het panel op runtime te verslepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
            this.BringToFront();
        }
        /// <summary>
        /// Functie die het scherm plaatst als je die muis loslaat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
                this.BringToFront();
            }
        }
        /// <summary>
        /// Methode om een item aan de listview toe te voegen
        /// </summary>
        /// <param name="e">Entity die je wilt toevoegen</param>
        /// <returns></returns>
        private ListViewItem CreateListViewItem(Entity e)
        {
            ListViewItem LVItem;
            LVItem = new ListViewItem(e.ToString());
            LVItem.SubItems.Add(e.X.ToString());
            LVItem.SubItems.Add(e.Y.ToString());
            LVItem.SubItems.Add(Math.Abs(e.DX + e.DY).ToString());
            listView1.Items.Add(LVItem);
            return LVItem;
        }

        /// <summary>
        /// Oude code om de list view up te daten
        /// Update alle items in de list view
        /// </summary>
        //private void update()
        //{
        //    List<GameObject> Entitys = OlympusTheGame.Playfield.GameObjects;
        //    foreach (GameObject g in Entitys)
        //    {
        //        Entity e = g as Entity;
        //        if (e != null)
        //        {
        //            ListViewItem LVItem;
        //            if (list.ContainsKey(e))
        //            {
        //                LVItem = list[e];
        //                LVItem.SubItems[1].Text = e.X.ToString();
        //                LVItem.SubItems[2].Text = e.Y.ToString();
        //            }
        //            else
        //            {
        //                list[e] = CreateListViewItem(e);
        //            }
        //        }
        //    }
        //    this.Invalidate(true);
        //}


    }
}
