using System;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game.View.Menu
{
    public partial class LevelDialog : UserControl
    {
        public LevelDialog()
        {
            InitializeComponent();

            int buttons = 6;

            for (int i = 1; i <= buttons; i++)
            {
                Button b = new Button();
                int a = i;
                b.Click += delegate { buttonClicked(a); };
                Controls.Add(b);
                b.Size = new Size(420, 49);
                b.Location = new Point(3, 3 + (i - 1)*55);
                b.BackgroundImage = Resources.stone;
                b.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                b.ForeColor = Color.Black;
                b.Text = "Level " + i;
            }

            Size = new Size(426, buttons*55);
        }

        public int Level { get; private set; }
        public event Action LevelChosen;

        private void buttonClicked(int level)
        {
            Level = level;
            if (LevelChosen != null)
                LevelChosen();
        }
    }
}