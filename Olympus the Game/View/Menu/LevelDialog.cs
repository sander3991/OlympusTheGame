using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View.Menu
{
    public partial class LevelDialog : UserControl
    {
        public event Action LevelChosen;

        public int Level { get; private set; }

        public LevelDialog()
        {
            InitializeComponent();

            int buttons = 6;

            for(int i = 1; i <= buttons; i++) {
                Button b = new Button();
                int a = i;
                b.Click += delegate(object source, EventArgs ea) { this.buttonClicked(a); };
                this.Controls.Add(b);
                b.Size = new Size(420, 49);
                b.Location = new Point(3, 3 + (i - 1) * 55);
                b.BackgroundImage = global::Olympus_the_Game.Properties.Resources.stone;
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.ForeColor = Color.Black;
                b.Text = "Level " + i;
            }

            this.Size = new Size(426, buttons * 55);
        }

        private void buttonClicked(int level)
        {
            Level = level;
            if(LevelChosen != null)
                LevelChosen();
        }
    }
}
