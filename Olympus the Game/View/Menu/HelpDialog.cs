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
    public partial class HelpDialog : UserControl
    {
        private int prop_scroll;
        private const int TIMERINTERVAL = 33;
        private Timer scrollTimer;
        public int ScrollLoc
        {
            get
            {
                return prop_scroll;
            }
            private set
            {
                if (value > Height)
                    prop_scroll = Height;
                else if ((label1.Location.Y + label1.Height) < 0)
                    prop_scroll = -(label1.Height);
                else
                    prop_scroll = value;
            }
        }
        public HelpDialog()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Visible = false;
            this.MouseWheel += HelpDialog_MouseWheel;
            label1.Text = label1.Text.ToUpper();
            label1.ForeColor = Color.FromArgb(247, 112, 22);
            scrollTimer = new Timer();
            scrollTimer.Interval = TIMERINTERVAL;
            scrollTimer.Tick += scrollTimer_Tick;
            VisibleChanged += OnVisibleChanged;
        }

        void OnVisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                Start();
            else
                Stop();
        }

        void scrollTimer_Tick(object sender, EventArgs e)
        {
            ScrollLoc -= 3;
            Point loc = label1.Location;
            loc.Y = ScrollLoc;
            label1.Location = loc;
            if (scrollTimer.Interval == 5000)
                scrollTimer.Interval = TIMERINTERVAL;
        }

        void HelpDialog_MouseWheel(object sender, MouseEventArgs e)
        {
            scrollTimer.Stop();
            scrollTimer.Interval = 5000;
            scrollTimer.Start();
            int scroll = e.Delta / 8;
            ScrollLoc += scroll;
            Point loc = label1.Location;
            loc.Y = ScrollLoc;
            label1.Location = loc;
        }


        private void Start()
        {
            ScrollLoc = Height;
            Point loc = label1.Location;
            loc.Y = ScrollLoc;
            label1.Location = loc;
            Focus();
            scrollTimer.Start();
        }

        private void Stop()
        {
            scrollTimer.Stop();
        }
    }
}
