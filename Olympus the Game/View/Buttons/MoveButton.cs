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
    public partial class MoveButton : Button
    {
        // Punt zodat het panel versleept kan worden
        public Point MouseDownLocation { get; set; }

        public MoveButton()
        {
            InitializeComponent();

            MouseDownLocation = new Point(0, 0);

            this.MouseDown += SleepKnop_MouseDown;
            this.MouseMove += SleepKnop_MouseMove;
        }

        /// <summary>
        /// Functie om het panel op runtime te verslepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepKnop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Control c = Utils.getParentControl(this);
                c.Left = e.X + c.Left - MouseDownLocation.X;
                c.Top = e.Y + c.Top - MouseDownLocation.Y;
                c.BringToFront();
            }
        }

        /// <summary>
        /// Functie die het scherm plaatst als je die muis loslaat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepKnop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Control c = Utils.getParentControl(this);
                c.Left = e.X + c.Left - MouseDownLocation.X;
                c.Top = e.Y + c.Top - MouseDownLocation.Y;
                c.BackColor = Color.Transparent;
            }
        }
    }
}
