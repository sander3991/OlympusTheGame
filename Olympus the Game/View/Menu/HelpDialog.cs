using System;
using System.Drawing;
using System.Windows.Forms;

namespace Olympus_the_Game.View.Menu
{
    public struct HelpItem
    {
        public readonly Label Label;
        public readonly PictureBox Picture;

        public HelpItem(PictureBox picture, Label label)
        {
            Picture = picture;
            Label = label;
        }

        public int Y
        {
            get { return Picture.Location.Y; }
            set
            {
                if (value != Picture.Location.Y)
                {
                    Point picLoc = Picture.Location;
                    Point labelLoc = Label.Location;
                    picLoc.Y = value;
                    labelLoc.Y = value;
                    Picture.Location = picLoc;
                    Label.Location = labelLoc;
                }
            }
        }
    }

    public partial class HelpDialog : UserControl
    {
        private const int Timerinterval = 50;
        private static readonly Color FontColor = Color.FromArgb(247, 112, 22);
        private readonly HelpItem[] helpItems;
        private readonly Timer scrollTimer;
        private readonly int totalScrollHeight;
        private int prop_scroll;

        public HelpDialog()
        {
            InitializeComponent();
            Visible = false;
            label1.Text = label1.Text.ToUpper();
            label1.ForeColor = FontColor;
            scrollTimer = new Timer { Interval = Timerinterval };
            scrollTimer.Tick += scrollTimer_Tick;
            VisibleChanged += OnVisibleChanged;

            //initialiseer alle plaatjes in een lijst van volgorde
            helpItems = new[]
            {
                new HelpItem(PicSteve, LabelSteve),
                new HelpItem(PicHuis, LabelHuis),
                new HelpItem(PicCake, LabelCake),
                new HelpItem(PicCreeper, LabelCreeper),
                new HelpItem(PicObstacle, LabelObstacle),
                new HelpItem(PicSpider, LabelSpider),
                new HelpItem(PicBomb, LabelBomb),
                new HelpItem(PicTimeBomb, LabelTimeBomb),
                new HelpItem(PicGhast, LabelGhast),
                new HelpItem(PicSilverfish, LabelSilverfish)
            };
            Point picLoc = new Point(0, Height);
            Point labelLoc = new Point(100, Height);
            foreach (HelpItem item in helpItems)
            {
                item.Label.Location = labelLoc;
                item.Picture.Location = picLoc;
                item.Label.ForeColor = FontColor;
            }
            totalScrollHeight = -(label1.Height + helpItems.Length * 100);
        }

        public int ScrollLoc
        {
            get { return prop_scroll; }
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

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                Start();
            else
                Stop();
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            ScrollContent(-4);
            if (scrollTimer.Interval == 5000)
                scrollTimer.Interval = Timerinterval;
        }

        private void HelpDialog_MouseWheel(object sender, MouseEventArgs e)
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
            MouseWheel += HelpDialog_MouseWheel;
            ScrollLoc = Height;
            Point loc = label1.Location;
            loc.Y = ScrollLoc;
            label1.Location = loc;
            Focus();
            scrollTimer.Start();
        }

        private void Stop()
        {
            MouseWheel -= HelpDialog_MouseWheel;
            scrollTimer.Stop();
        }
    }
}