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
        private void ArrowKey_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            string richting = b.Name.ToString();
            switch (richting)
            {
                case "ArrowKeyRight":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(1, true);
                    break;
                case "ArrowKeyLeft":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(-1, true);
                    break;
                case "ArrowKeyUp":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(-1, false);
                    break;
                case "ArrowKeyDown":
                    OlympusTheGame.INSTANCE.Controller.MovePlayer(1, false);
                    break;
            }
        }
        
        // Zet alles stil
        private void StopMoving(object sender, MouseEventArgs e)
        {
            OlympusTheGame.INSTANCE.Controller.MovePlayer(0, true);
            OlympusTheGame.INSTANCE.Controller.MovePlayer(0, false);
        }

        

        

        



        


    }
}
