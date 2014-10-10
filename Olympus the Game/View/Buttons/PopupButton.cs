using System;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game.View.Buttons
{
    public partial class PopupButton : Button
    {
        private Form SourceForm;
        private Point loc;

        public PopupButton()
        {
            InitializeComponent();
            Click += ButtonRemove_Click;
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            Control parent = Utils.GetParentControl(this);
            loc = parent.Location;
            SourceForm = parent.FindForm();
            if (SourceForm != null) SourceForm.Controls.Remove(parent);

            // Make move button invisible
            foreach (Control c in Parent.Controls)
                if (c.GetType() == typeof (MoveButton))
                    c.Visible = false;

            Form f = new Form {Width = parent.Width + 10, Height = parent.Height + 35, BackgroundImage = Resources.dirt};
            f.Controls.Add(parent);
            parent.Location = new Point(0, 0);
            f.MaximizeBox = false;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.FormClosed += BringBack;
            Visible = false;
            f.Show();
        }

        private void BringBack(object source, EventArgs e)
        {
            Control parent = Utils.GetParentControl(this);

            Form f = parent.FindForm();
            if (f != null)
            {
                f.Controls.Remove(parent);
                f.Dispose();
            }

            SourceForm.Controls.Add(parent);
            Visible = true;

            // Make move button visible
            foreach (Control c in Parent.Controls)
                if (c.GetType() == typeof (MoveButton))
                    c.Visible = true;

            parent.Location = loc;
            parent.Visible = true;
        }
    }
}