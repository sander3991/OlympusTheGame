using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Olympus_the_Game.Model;

namespace Olympus_the_Game.View.Editor
{
    public partial class EntitySourcePanelList : UserControl
    {
        private readonly int PADDING_TOP = 15;

        public EntitySourcePanelList()
        {
            InitializeComponent();
        }

        private void EntitySourcePanelList_Load(object sender, EventArgs e)
        {
            int pad = PADDING_TOP;

            foreach (KeyValuePair<ObjectType, Func<GameObject>> a in GameObject.ConstructorList)
            {
                EntitySourcePanel esp = new EntitySourcePanel(a.Key);
                esp.Left = (this.Width - esp.Width) / 2;
                esp.Top = pad;

                pad += esp.Height;
                pad += PADDING_TOP * 2;

                this.Controls.Add(esp);
            }

            // Add events
            this.Scroll += delegate(object source, ScrollEventArgs ea) { this.Invalidate(); };
        }
    }
}
