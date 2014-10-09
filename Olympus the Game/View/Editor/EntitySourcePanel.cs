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

        public ObjectType RepresentingType { get; private set; }

        public EntitySourcePanel()
            : this(ObjectType.CREEPER)
        { }

        public EntitySourcePanel(ObjectType et)
        {
            InitializeComponent();
            RepresentingType = et;
        }

        private void EntitySourcePanel_Load(object sender, EventArgs e)
        {
            // Change image
            Sprite s = DataPool.GetPicture(RepresentingType, this.picturePreview.Size);
            if (s != null)
                this.picturePreview.Image = s[-1.0f];

            // Change name
            this.label1.Text = RepresentingType.ToString();

            // Change shortcut key
            this.label2.Text = "Toets";

            // Change description
            GameObject go = Utils.CreateObjectOfType(RepresentingType);
            if(go != null)
                this.label3.Text = go.getDescription();
        }

        private void EntitySourcePanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.picturePreview.DoDragDrop(RepresentingType, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
