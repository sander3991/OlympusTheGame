using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            if (this.picturePreview != null)
                this.picturePreview.Image = ImagePool.GetPicture(EntityType, this.picturePreview.Size)[-1.0f];
            this.label1.Text = EntityType.ToString();
            this.label2.Text = "Toets";
            this.label3.Text = "Omschrijving";
        }

        private void EntitySourcePanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(EntityType, DragDropEffects.Copy | DragDropEffects.Move);
        }


    }
}
