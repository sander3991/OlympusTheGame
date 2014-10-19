using System;
using System.Linq;
using System.Windows.Forms;
using Olympus_the_Game.Model;

namespace Olympus_the_Game.View.Editor
{
    public partial class EntitySourcePanelList : UserControl
    {
        private const int PaddingTop = 15;

        public EntitySourcePanelList()
        {
            InitializeComponent();
        }

        private void EntitySourcePanelList_Load(object sender, EventArgs e)
        {
            int pad = PaddingTop;

            foreach (EntitySourcePanel esp in GameObject.ConstructorList.Select(a => new EntitySourcePanel(a.Key)))
            {
                esp.Left = (Width - esp.Width) / 2;
                esp.Top = pad;

                pad += esp.Height;
                pad += PaddingTop * 2;

                Controls.Add(esp);
            }

            // Add events
            Scroll += delegate { Invalidate(); };
        }
    }
}