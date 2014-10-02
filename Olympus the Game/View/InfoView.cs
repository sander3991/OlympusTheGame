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
        public Point MouseDownLocation { get; set; }
        public List<GameObject> Entitys { get; set; }
        public bool IsResized { get; set; }
        public InfoView()
        {
            InitializeComponent();
        }
       

        private void OnLoad(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            
            if(OlympusTheGame.INSTANCE.Controller != null)
                OlympusTheGame.INSTANCE.Controller.UpdateSlowEvents += delegate() { update(); };
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
            }
        }

        private void DragButton_Click(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            Entitys = OlympusTheGame.INSTANCE.Playfield.GetObjects();
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
