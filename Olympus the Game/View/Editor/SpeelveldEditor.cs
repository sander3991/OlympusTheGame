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
        public PlayField Playfield { get; set; }
        public Size EnteredSize { 
            get {
                return prop_size;
            } 
            set { 
                prop_size = value;
                this.GrootteXInput.Text = prop_size.Width.ToString();
                this.GrootteYInput.Text = prop_size.Height.ToString();
                
                if(Playfield != null)
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

                // Only call this when valid change happened
                ApplyClick();
            }
            catch (FormatException) 
            { 
                // TODO Ruben: Opvangen!
            }
        }
    }
}
