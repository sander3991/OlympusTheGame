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
        private static readonly bool DISABLE_MASK = false;// TODO Release: Deze regel verwijderen

        public static readonly int MASK_FADE_DURATION = 500;

        public static Form MaskForm { get; private set; }

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
            if(MaskForm == null || MaskForm.IsDisposed)
                MaskForm = new Form() { BackColor = Color.Black, FormBorderStyle = FormBorderStyle.None, ShowInTaskbar = false, TopMost = true };
            if (!MaskForm.IsHandleCreated)
                MaskForm.Show();
            MaskForm.Invoke((Action<bool>)ShowMaskUnsafe, new object[] {showMask});
        }

        private static void ShowMaskUnsafe(bool showMask)
        {
            if (DISABLE_MASK) { MaskForm.Visible = false; return; } // TODO Release: Deze regel verwijderen
            MaskForm.Size = getScreenSize();
            MaskForm.Location = Point.Empty;
            MaskForm.Opacity = showMask ? 0.0f : 1.0f;
            
            Stopwatch sw = new Stopwatch();

            sw.Start();
            MaskForm.Visible = true;
            while (sw.ElapsedMilliseconds < MASK_FADE_DURATION)
            {
                float i = (float)sw.ElapsedMilliseconds / (float)MASK_FADE_DURATION;
                MaskForm.Opacity = showMask ? i : 1.0f - i;
                MaskForm.Invalidate();
                Application.DoEvents();
            }
            MaskForm.Opacity = showMask ? 1.0f : 0.0f;
            sw.Stop();
            MaskForm.Visible = showMask;
        }

        public static Size getScreenSize()
        {
            return new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public static void FullScreen(Form f, bool fullScreen)
        {
            if (fullScreen)
            {
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                f.Size = Utils.getScreenSize();
                f.Location = Point.Empty;
            }
            else
            {
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
                f.Size = new Size(1024, 768);
                Size full = Utils.getScreenSize();
                f.Location = new Point((full.Width - f.Width) / 2, (full.Height - f.Height) / 2);
            }
        }

        public static Dictionary<ObjectType, Type> TypeLijst = new Dictionary<ObjectType, Type>();

        public static GameObject getObjectOfType(ObjectType ot)
        {
            Type t = TypeLijst[ot];
            if (t == null) return null;

            return (GameObject) t.GetConstructor(new Type[] {}).Invoke(new object[] {});
        }
    }
}
