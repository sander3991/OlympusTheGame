using System;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Model;

namespace Olympus_the_Game.View.Editor
{
    public partial class SpeelveldEditor : UserControl
    {
        private PlayField prop_PlayField;
        private Size prop_size;

        public SpeelveldEditor()
        {
            InitializeComponent();
            label1.Visible = false;
            ToepassenSpeelveld.Click += ClickCallback;
        }

        public PlayField Playfield
        {
            get { return prop_PlayField; }
            set
            {
                prop_PlayField = value;
                if (value == null || GrootteXInput == null || GrootteYInput == null || TitelInput == null) return;
                GrootteXInput.Text = value.Width.ToString();
                GrootteYInput.Text = value.Height.ToString();
                TitelInput.Text = value.Name;
            }
        }

        public Size EnteredSize
        {
            get { return prop_size; }
            set
            {
                prop_size = value;
                GrootteXInput.Text = prop_size.Width.ToString();
                GrootteYInput.Text = prop_size.Height.ToString();

                if (Playfield == null) return;
                if (prop_size.Width >= 1)
                    Playfield.Height = prop_size.Height;
                if (prop_size.Height >= 1)
                    Playfield.Width = prop_size.Height;
            }
        }

        public string Title
        {
            get { return TitelInput.Text; }
        }

        public event Action ApplyClick;

        private void ClickCallback(object source, EventArgs e)
        {
            // Parse info
            try
            {
                // Parse height and width
                int height = Convert.ToInt32(GrootteYInput.Text);
                int width = Convert.ToInt32(GrootteXInput.Text);

                // If no exceptions raised
                EnteredSize = new Size(width, height);

                // Set warning label to invisible
                label1.Visible = false;

                // Only call this when valid change happened
                ApplyClick();
            }
            catch (FormatException)
            {
                // Set warning label to visible
                label1.Visible = true;
            }
        }
    }
}