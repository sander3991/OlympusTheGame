using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View
{
    public partial class LevelEditor : Form
    {
        private PlayField pf = new PlayField(1000, 500, new List<GameObject>());

        public LevelEditor()
        {
            InitializeComponent();

            this.gamePanel1.setPlayField(this.pf);
            this.gamePanel1.Invalidate();
        }

        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(typeof(EntityPlayer).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Creeper_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(typeof(EntityCreeper).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Spider_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(typeof(EntitySlower).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Tnt_MouseDown(object sender, MouseEventArgs e)
        {
            Tnt.DoDragDrop(typeof(EntityExplode).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void TimeBomb_MouseDown(object sender, MouseEventArgs e)
        {
            TimeBomb.DoDragDrop(typeof(EntityTimeBomb).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Cake_MouseDown(object sender, MouseEventArgs e)
        {
            Cake.DoDragDrop(typeof(ObjectFinish).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void drag_drop(object sender, DragEventArgs e)
        {
            // Get relative location
            Point l = this.gamePanel1.PointToClient(new Point(e.X, e.Y));
            l = new Point((int)((double)l.X / this.gamePanel1.SCALE), (int)((double)l.Y / this.gamePanel1.SCALE));

            // Add object
            this.pf.AddObject(new EntityPlayer(50, 50, l.X, l.Y));
            this.gamePanel1.Invalidate();
        }
    }
}
