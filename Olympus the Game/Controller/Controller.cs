using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game
    
{
    public class Controller
    {
        public PlayField PlayField { get; private set; }

        public Controller(PlayField pf)
        {
            this.PlayField = pf;
        }

        public void ReadInput(KeyEventArgs e)
        {
            // Toetsen voor naar links en naar rechts.
            if (e.KeyCode == Keys.Left)
                OlympusTheGame.INSTANCE.pf.Player.DX = 1;
            else if (e.KeyCode == Keys.Right)
                OlympusTheGame.INSTANCE.pf.Player.DX = -1;
            // Toetsen voor naar boven en naar beneden.
            else if (e.KeyCode == Keys.Up)
                OlympusTheGame.INSTANCE.pf.Player.DY = -1;
            else if (e.KeyCode == Keys.Down)
                OlympusTheGame.INSTANCE.pf.Player.DY = 1;

        }

        public void Update()
        {
            PlayField.Player.DX = 1;
            PlayField.Player.Move();
            foreach(GameObject o in PlayField.GetObjects()){
                Entity e = o as Entity;
                if (e != null)
                {
                    e.Move();
                }
            }
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }
    }
}
