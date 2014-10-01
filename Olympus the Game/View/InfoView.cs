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
    public partial class InfoView : UserControl
    {
        public Point MouseDownLocation { get; set; }
        public List<GameObject> Entitys { get; set; }
        public InfoView()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Entitys = OlympusTheGame.INSTANCE.Playfield.GetObjects();

            foreach(GameObject g in Entitys)
            {
                Entity e = g as Entity;
                if (e != null)
                {
                    string itemNaam = e.ToString();
                    ListViewItem LVItem = new ListViewItem(itemNaam);
                    
                    LVItem.SubItems.Add(e.X.ToString());
                    LVItem.SubItems.Add(e.Y.ToString());
                    listView1.Items.Add(LVItem);
                }
            }
        }

        public void update()
        {
            
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

        private void DragButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Init();
        }
    }
}
