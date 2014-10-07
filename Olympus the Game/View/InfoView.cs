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
        // List voor alle Entitys bijhouden
        public List<GameObject> Entitys { get; set; }
        // Het scherm moet 1 keer worden geresized in de Update zet hij deze op false
        public bool IsResized { get; set; }
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
            this.DoubleBuffered = true;
            OlympusTheGame.Controller.UpdateSlowEvents += delegate() { update(); };
            IsResized = false;
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
        /// Update alle items in de list view
        /// </summary>
        private void update()
        {
            // TODO HenkJan: Efficientere manier van updaten. Eventueel in overleg met Sander
            Entitys = OlympusTheGame.Playfield.GameObjects;
            listView1.Items.Clear();
            foreach (GameObject g in Entitys)
            {
                Entity e = g as Entity;
                
                if (e != null)
                {
                    ListViewItem LVItem = new ListViewItem(e.ToString());
                    LVItem.SubItems.Add(e.X.ToString());
                    LVItem.SubItems.Add(e.Y.ToString());
                    LVItem.SubItems.Add(Math.Abs(e.DX + e.DY).ToString());
                    listView1.Items.Add(LVItem);
                }
            }
            if (!IsResized)
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                IsResized = true;
            }
            this.Invalidate(true);
        }

        
    }
}
