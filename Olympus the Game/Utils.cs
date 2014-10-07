using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    class Utils
    {
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
    }
}
