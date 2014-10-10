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
    public struct HelpItem
    {
        public PictureBox picture;
        public Label label;
        public int Y {
            get
            {
                return picture.Location.Y;
            }
            set
            {
                if(value != picture.Location.Y)
                {
                    Point picLoc = picture.Location;
                    Point labelLoc = label.Location;
                    picLoc.Y = value;
                    labelLoc.Y = value;
                    picture.Location = picLoc;
                    label.Location = labelLoc;

                }
            }
        }
        public HelpItem(PictureBox picture, Label label)
        {
            this.picture = picture;
            this.label = label;
        }
    }

    public partial class HelpDialog : UserControl
    {
        private int prop_scroll;
        private const int TIMERINTERVAL = 50;
        private readonly Timer scrollTimer;
        private readonly HelpItem[] helpItems;
        private readonly int totalScrollHeight;
        private static readonly Color fontColor = Color.FromArgb(247, 112, 22);
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
                else if (value < totalScrollHeight)
                    prop_scroll = totalScrollHeight;
                else
                    prop_scroll = value;
            }
        }
        public HelpDialog()
        {
            InitializeComponent();
            this.Visible = false;
            label1.Text = label1.Text.ToUpper();
            label1.ForeColor = fontColor;
            scrollTimer = new Timer();
            scrollTimer.Interval = TIMERINTERVAL;
            scrollTimer.Tick += scrollTimer_Tick;
            VisibleChanged += OnVisibleChanged;

            //initialiseer alle plaatjes in een lijst van volgorde
            helpItems = new HelpItem[9]{
                new HelpItem(PicSteve, LabelSteve),
                new HelpItem(PicHuis, LabelHuis),
                new HelpItem(PicCake, LabelCake),
                new HelpItem(PicCreeper, LabelCreeper),
                new HelpItem(PicObstacle, LabelObstacle),
                new HelpItem(PicSpider, LabelSpider),
                new HelpItem(PicBomb, LabelBomb),
                new HelpItem(PicTimeBomb, LabelTimeBomb),
                new HelpItem(PicGhast, LabelGhast),
            };
            Point picLoc = new Point(0, Height);
            Point labelLoc = new Point(100, Height);
            for (int i = 0; i < helpItems.Length; i++ )
            {
                HelpItem item = helpItems[i];
                item.label.Location = labelLoc;
                item.picture.Location = picLoc;
                item.label.ForeColor = fontColor;
            }
            totalScrollHeight = -(label1.Height + helpItems.Length * 100);
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
            ScrollContent(-4);
            if (scrollTimer.Interval == 5000)
                scrollTimer.Interval = TIMERINTERVAL;
        }

        void HelpDialog_MouseWheel(object sender, MouseEventArgs e)
        {
            scrollTimer.Stop();
            scrollTimer.Interval = 5000;
            scrollTimer.Start();
            int scroll = e.Delta / 8;
            ScrollContent(scroll);

        }

        private void ScrollContent(int scrollAmount)
        {
            ScrollLoc += scrollAmount;
            Point loc = label1.Location;
            loc.Y = ScrollLoc;
            label1.Location = loc;
           // scrollingHelpItem = Math.Max(-1,(ScrollLoc - label1.Height) / 100);
            for (int i = 0; i < helpItems.Length; i++)
            {
                HelpItem item = helpItems[i];
                item.Y = Math.Min(Height, ScrollLoc + label1.Height + i * 100);
            }
        }


        private void Start()
        {
            this.MouseWheel += HelpDialog_MouseWheel;
            ScrollLoc = Height;
            Point loc = label1.Location;
            loc.Y = ScrollLoc;
            label1.Location = loc;
            Focus();
            scrollTimer.Start();
        }

        private void Stop()
        {
            this.MouseWheel -= HelpDialog_MouseWheel;
            scrollTimer.Stop();
        }
    }
}
