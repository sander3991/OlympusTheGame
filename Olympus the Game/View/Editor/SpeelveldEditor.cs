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

        public int EnteredWidth { get; private set; }

        public int EnteredHeight { get; private set; }

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
            this.ToepassenSpeelveld.Click += ClickCallback;
        }

        private void ClickCallback(object source, EventArgs e)
        {
            int height, width;

            // Parse info
            try
            {
                // Parse height and width
                height = Convert.ToInt32(this.GrootteYInput.Text);
                width = Convert.ToInt32(this.GrootteXInput.Text);

                // If no exceptions raised
                Height = height;
                Width = width;

                // Only call this when valid change happened
                ApplyClick();
            }
            catch (FormatException) { }
        }
    }
}
