using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game
{
    internal class Utils
    {
        public static readonly int MaskFadeDuration = 500;

        public static Form MaskForm { get; private set; }

        /// <summary>
        /// Geeft de parent terug van een gegeven control.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Control GetParentControl(Control c)
        {
            Control c2 = c;
            while (!(c2 is UserControl))
            {
                c2 = c2.Parent;
            }
            return c2;
        }

        public static void ShowMask(bool showMask)
        {
            if (MaskForm == null || MaskForm.IsDisposed)
                MaskForm = new Form
                {
                    BackColor = Color.Black,
                    FormBorderStyle = FormBorderStyle.None,
                    ShowInTaskbar = false,
                    TopMost = true
                };
            if (!MaskForm.IsHandleCreated)
                MaskForm.Show();
            MaskForm.Invoke((Action<bool>) ShowMaskUnsafe, new object[] {showMask});
        }

        private static void ShowMaskUnsafe(bool showMask)
        {
            MaskForm.Size = GetScreenSize();
            MaskForm.Location = Point.Empty;
            MaskForm.Opacity = showMask ? 0.0f : 1.0f;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            MaskForm.Visible = true;
            while (sw.ElapsedMilliseconds < MaskFadeDuration)
            {
                float i = sw.ElapsedMilliseconds/(float) MaskFadeDuration;
                MaskForm.Opacity = showMask ? i : 1.0f - i;
                MaskForm.Invalidate();
                Application.DoEvents();
            }
            MaskForm.Opacity = showMask ? 1.0f : 0.0f;
            sw.Stop();
            MaskForm.Visible = showMask;
        }

        public static Size GetScreenSize()
        {
            return new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public static void FullScreen(Form f, bool fullScreen)
        {
            if (fullScreen)
            {
                f.FormBorderStyle = FormBorderStyle.None;
                f.Size = GetScreenSize();
                f.Location = Point.Empty;
            }
            else
            {
                f.FormBorderStyle = FormBorderStyle.Fixed3D;
                f.Size = new Size(1024, 768);
                Size full = GetScreenSize();
                f.Location = new Point((full.Width - f.Width)/2, (full.Height - f.Height)/2);
            }
        }

        public static void SetButtonStyle(Button b)
        {
            b.BackgroundImage = Resources.stone;
            b.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            b.ForeColor = Color.Black;
        }

        public static GameObject CreateObjectOfType(ObjectType ot)
        {
            Func<GameObject> result;
            GameObject.ConstructorList.TryGetValue(ot, out result);

            return result == null ? null : result();
        }
    }
}