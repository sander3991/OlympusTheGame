using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Olympus_the_Game.View
{
    public partial class EntityEditor : UserControl
    {
        public EntityEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Laad de data van de entity in de EntityEditor
        /// </summary>
        public void LoadData(GameObject go)
        {
            XLocationInput.Text = go.X.ToString();
            YLocationInput.Text = go.Y.ToString();
            EntityNaamLabel.Text = go.Type.ToString();
            

            if (go.Type.ToString() == "CREEPER")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.creeper;
                HideTextureInput();
            }
            else if (go.Type.ToString() == "SLOWER")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.spider;
                HideTextureInput();
            }
            else if (go.Type.ToString() == "EXPLODE")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.tnt;
                HideTextureInput();
            }
            else if (go.Type.ToString() == "TIMEBOMB")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.timebomb;
                HideTextureInput();
            }
            else if (go.Type.ToString() == "CAKE")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cake;
                HideTextureInput();
            }
            else if (go.Type.ToString() == "HOME")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.huis;
                HideTextureInput();
            }
            else if (go.Type.ToString() == "OBSTACLE")
            {
                EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cobble;
                TextureInput.Visible = true;
                ObjectTexture.Visible = true;
            }
            else
            {
                Console.WriteLine("Type niet bekend");
            }

        }

        private void HideTextureInput()
        {
            TextureInput.Visible = false;
            ObjectTexture.Visible = false;
        }
    }
}
