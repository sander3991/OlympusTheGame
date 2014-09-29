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
    public partial class ArrowPanel : UserControl
    {
        public ArrowPanel()
        {
            InitializeComponent();

        }
        // Kijk welke button is ingedrukt
        private void ArrowKeyRight_MouseDown(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(1, true);
        }
        private void ArrowKeyLeft_MouseDown(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(-1, true);
        }

        private void ArrowKeyUp_MouseDown(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(-1, false);
        }

        private void ArrowKeyDown_MouseDown(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(1, false);
        }
        // Zet alles stil
        private void StopMoving(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(0, true);
            OlympusTheGame.INSTANCE.Controller.MovePlayer(0, false);
        }

        

        



        


    }
}
