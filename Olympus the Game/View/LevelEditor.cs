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
        public LevelEditor()
        {
            InitializeComponent();

            this.gamePanel1.setPlayField(new PlayField(1000, 500, new List<GameObject>()));
            this.gamePanel1.Invalidate();
        }

        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(typeof(EntityPlayer).ToString(), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Creeper_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(Player.BackgroundImage, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Spider_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(Player.BackgroundImage, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Tnt_MouseDown(object sender, MouseEventArgs e)
        {
            Tnt.DoDragDrop(Tnt.BackgroundImage, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void TimeBomb_MouseDown(object sender, MouseEventArgs e)
        {
            TimeBomb.DoDragDrop(TimeBomb, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Cake_MouseDown(object sender, MouseEventArgs e)
        {
            Cake.DoDragDrop(Cake.BackgroundImage, DragDropEffects.Copy | DragDropEffects.Move);
        }

        /// <summary>
        /// Zodra een entiteit in het panel word gesleept word bekeken of deze van het type string is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
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

            MessageBox.Show(string.Format("Drop: {0} \nX:{1} Y:{2}\nX:{3} Y:{4}", e.Data, l.X, l.Y, e.X, e.Y));
        }
    }
}
