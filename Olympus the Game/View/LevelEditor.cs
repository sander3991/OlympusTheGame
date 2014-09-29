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
        }

        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            Player.DoDragDrop(Player.BackgroundImage, DragDropEffects.Copy | DragDropEffects.Move);
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

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

    }
}
