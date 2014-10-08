using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    class Utils
    {

        public static Form MaskForm { get; private set; }

        static Utils()
        {
            MaskForm = new Form() { BackColor = Color.Black, FormBorderStyle = FormBorderStyle.None, ShowInTaskbar = false, TopMost = true };
        }

        /// <summary>
        /// Geeft de parent terug van een gegeven control.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Control getParentControl(Control c)
        {
            Control c2 = c;
            while (!typeof(UserControl).IsAssignableFrom(c2.GetType()))
            {
                c2 = c2.Parent;
            }
            return c2;
        }

        public static void ShowMask(bool showMask)
        {
            if (!MaskForm.IsHandleCreated)
                MaskForm.Show();
            MaskForm.Invoke((Action<bool>)ShowMaskUnsafe, new object[] {showMask});
        }

        private static void ShowMaskUnsafe(bool showMask)
        {
            
            MaskForm.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            MaskForm.Location = Point.Empty;
            MaskForm.Opacity = showMask ? 0.0f : 1.0f;
            
            Mp3Player.FadeOut(1000);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            MaskForm.Visible = true;
            while (sw.ElapsedMilliseconds < 4000)
            {
                float i = (float)sw.ElapsedMilliseconds / (float)4000;
                MaskForm.Opacity = showMask ? i : 1.0f - i;
                MaskForm.Invalidate();
                Application.DoEvents();
            }
            MaskForm.Visible = showMask;
        }
    }
}
