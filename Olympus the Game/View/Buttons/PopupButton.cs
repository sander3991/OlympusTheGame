using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View.Buttons
{
    public partial class PopupButton : Button
    {
        private Point loc;

        private Form SourceForm;

        public PopupButton()
        {
            InitializeComponent();
            this.Click += ButtonRemove_Click;
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            Control parent = Utils.getParentControl(this);
            loc = parent.Location;
            SourceForm = parent.FindForm();
            SourceForm.Controls.Remove(parent);

            // Make move button invisible
            foreach (Control c in this.Parent.Controls)
                if (c.GetType() == typeof(MoveButton))
                    c.Visible = false;

            Form f = new Form();
            f.Width = parent.Width + 10;
            f.Height = parent.Height + 35;
            f.BackgroundImage = Properties.Resources.dirt;
            f.Controls.Add(parent);
            parent.Location = new Point(0, 0);
            f.MaximizeBox = false;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.FormClosed += BringBack;
            this.Visible = false;
            f.Show();
        }

        private void BringBack(object source, EventArgs e)
        {
            Control parent = Utils.getParentControl(this);

            Form f = parent.FindForm();
            f.Controls.Remove(parent);
            f.Dispose();

            SourceForm.Controls.Add(parent);
            this.Visible = true;

            // Make move button visible
            foreach (Control c in this.Parent.Controls)
                if (c.GetType() == typeof(MoveButton))
                    c.Visible = true;

            parent.Location = loc;
            parent.Visible = true;
        }
    }
}
