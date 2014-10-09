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
    public partial class SpeelveldEditor : UserControl
    {
        public event Action ApplyClick;

        private Size prop_size;
        private PlayField prop_PlayField;
        public PlayField Playfield
        {
            get
            {
                return prop_PlayField;
            }
            set
            {
                prop_PlayField = value;
                if (value != null && this.GrootteXInput != null && this.GrootteYInput != null && this.TitelInput != null) // If everything is initialized
                {
                    this.GrootteXInput.Text = value.Width.ToString();
                    this.GrootteYInput.Text = value.Height.ToString();
                    this.TitelInput.Text = value.Name;
                }
            }
        }
        public Size EnteredSize
        {
            get
            {
                return prop_size;
            }
            set
            {
                prop_size = value;
                this.GrootteXInput.Text = prop_size.Width.ToString();
                this.GrootteYInput.Text = prop_size.Height.ToString();

                if (Playfield != null)
                {
                    if (prop_size.Width >= 1)
                        Playfield.Height = prop_size.Height;
                    if (prop_size.Height >= 1)
                        Playfield.Width = prop_size.Height;
                }
            }
        }

        public string Title
        {
            get
            {
                return this.TitelInput.Text;
            }
        }

        public SpeelveldEditor()
        {
            InitializeComponent();
            this.label1.Visible = false;
            this.ToepassenSpeelveld.Click += ClickCallback;
        }

        private void ClickCallback(object source, EventArgs e)
        {
            // Parse info
            try
            {
                // Parse height and width
                int height = Convert.ToInt32(this.GrootteYInput.Text);
                int width = Convert.ToInt32(this.GrootteXInput.Text);

                // If no exceptions raised
                EnteredSize = new Size(width, height);

                // Set warning label to invisible
                this.label1.Visible = false;

                // Only call this when valid change happened
                ApplyClick();
            }
            catch (FormatException)
            {
                // Set warning label to visible
                this.label1.Visible = true;
            }
        }
    }
}
