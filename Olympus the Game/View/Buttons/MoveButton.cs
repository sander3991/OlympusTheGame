using System.Drawing;
using System.Windows.Forms;

namespace Olympus_the_Game.View.Buttons
{
    public partial class MoveButton : Button
    {
        // Punt zodat het panel versleept kan worden

        public MoveButton()
        {
            InitializeComponent();

            MouseDownLocation = new Point(0, 0);

            MouseDown += SleepKnop_MouseDown;
            MouseMove += SleepKnop_MouseMove;
        }

        public Point MouseDownLocation { get; set; }

        /// <summary>
        /// Functie om het panel op runtime te verslepen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepKnop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Control c = Utils.GetParentControl(this);
            c.Left = e.X + c.Left - MouseDownLocation.X;
            c.Top = e.Y + c.Top - MouseDownLocation.Y;
            c.BringToFront();
        }

        /// <summary>
        /// Functie die het scherm plaatst als je die muis loslaat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SleepKnop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Control c = Utils.GetParentControl(this);
            c.Left = e.X + c.Left - MouseDownLocation.X;
            c.Top = e.Y + c.Top - MouseDownLocation.Y;
            c.BackColor = Color.Transparent;
        }
    }
}