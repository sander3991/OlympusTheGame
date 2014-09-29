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

        private void Player_MouseDown(object sender, EventArgs e)
        {
            Player.DoDragDrop(Player.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Creeper_MouseDown(object sender, EventArgs e)
        {
            Player.DoDragDrop(Player.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void Spider_MouseDown(object sender, EventArgs e)
        {
            Player.DoDragDrop(Player.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void TnT_MouseDown(object sender, EventArgs e)
        {
            Player.DoDragDrop(Player.Image, DragDropEffects.Copy | DragDropEffects.Move);
        }

    }
}
