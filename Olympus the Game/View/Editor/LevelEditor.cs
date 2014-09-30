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
            Player.DoDragDrop(Entity.Type.PLAYER, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Creeper_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(Entity.Type.CREEPER, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Spider_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(Entity.Type.SLOWER, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Tnt_MouseDown(object sender, MouseEventArgs e)
        {
            Tnt.DoDragDrop(Entity.Type.EXPLODE, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void TimeBomb_MouseDown(object sender, MouseEventArgs e)
        {
            TimeBomb.DoDragDrop(Entity.Type.TIMEBOMB, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Cake_MouseDown(object sender, MouseEventArgs e)
        {
            Cake.DoDragDrop(Entity.Type.CAKE, DragDropEffects.Copy | DragDropEffects.Move);
        }

        /// <summary>
        /// Zodra een entiteit in het panel word gesleept word bekeken of deze van het type string is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Entity.Type)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Weergeef de locatie waar het object geplaatst is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drag_drop(object sender, DragEventArgs e)
        {
            // Get relative location
            Point l = this.gamePanel1.PointToClient(new Point(e.X, e.Y));
            l = new Point((int)((double)l.X / this.gamePanel1.SCALE), (int)((double)l.Y / this.gamePanel1.SCALE));

            // Add object
            switch ((Entity.Type)e.Data.GetData(typeof(Entity.Type)))
            {
                case Entity.Type.PLAYER:
                    this.pf.Player.X = l.X;
                    this.pf.Player.Y = l.Y;
                    break;
                case Entity.Type.TIMEBOMB:
                    this.pf.AddObject(new EntityTimeBomb(50, 50, l.X, l.Y, 1.0f));
                    break;
                case Entity.Type.SLOWER:
                    this.pf.AddObject(new EntitySlower(50, 50, l.X, l.Y));
                    break;
                case Entity.Type.CAKE:
                    this.pf.GetObjects().RemoveAll((p) => { return p.GetType() == typeof(ObjectFinish); });
                    this.pf.AddObject(new ObjectFinish(50, 50, l.X, l.Y));
                    break;
                case Entity.Type.HOME:
                    this.pf.GetObjects().RemoveAll((p) => { return p.GetType() == typeof(ObjectStart); });
                    this.pf.AddObject(new ObjectStart(50, 50, l.X, l.Y));
                    break;
                case Entity.Type.CREEPER:
                    this.pf.AddObject(new EntityCreeper(50, 50, l.X, l.Y, 1.0f));
                    break;
                case Entity.Type.OBSTACLE:
                    this.pf.AddObject(new ObjectObstacle(50, 50, l.X, l.Y));
                    break;
                case Entity.Type.EXPLODE:
                    this.pf.AddObject(new EntityExplode(50, 50, l.X, l.Y, 1.0f));
                    break;
            }
            this.gamePanel1.Invalidate();
        }
    }
}
