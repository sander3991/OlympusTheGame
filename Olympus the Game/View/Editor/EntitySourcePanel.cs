using System;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game.View.Editor
{
    public partial class EntitySourcePanel : UserControl
    {
        public EntitySourcePanel()
            : this(ObjectType.Creeper)
        {
        }

        public EntitySourcePanel(ObjectType et)
        {
            InitializeComponent();
            RepresentingType = et;
        }

        public ObjectType RepresentingType { get; private set; }

        private void EntitySourcePanel_Load(object sender, EventArgs e)
        {
            // Change image
            Sprite s = DataPool.GetPicture(RepresentingType, picturePreview.Size);
            if (s != null)
                picturePreview.Image = s[-1.0f];

            // Change name
            label1.Text = RepresentingType.ToString();

            // Change shortcut key
            label2.Text = "toets";

            // Change description
            GameObject go = Utils.CreateObjectOfType(RepresentingType);
            if (go == null) return;
            label3.Text = go.GetDescription();
            go.OnRemoved(true);
                //Deze regel zorgt ervoor dat hij zichzelf weer unsubscribed bij eventuele events. De objecten bleven bestaan!! ~Sander
        }

        private void EntitySourcePanel_MouseDown(object sender, MouseEventArgs e)
        {
            picturePreview.DoDragDrop(RepresentingType, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}