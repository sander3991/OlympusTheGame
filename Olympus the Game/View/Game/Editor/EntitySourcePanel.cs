using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game.View.Game.Editor
{
    public partial class EntitySourcePanel : UserControl
    {

        public ObjectType EntityType { get; private set; }

        public EntitySourcePanel()
            : this(ObjectType.UNKNOWN)
        { }

        public EntitySourcePanel(ObjectType ot)
        {
            InitializeComponent();
            EntityType = ot;
        }

        private void EntitySourcePanel_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.dirt;
            Sprite s = ImagePool.GetPicture(EntityType, this.picturePreview.Size);
            if (s != null)
                this.picturePreview.Image = s[-1.0f];
            this.label1.Text = EntityType.ToString();
            this.label2.Text = "Toets";
            this.label3.Text = "";
        }

        private void EntitySourcePanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.picturePreview.DoDragDrop(EntityType, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
