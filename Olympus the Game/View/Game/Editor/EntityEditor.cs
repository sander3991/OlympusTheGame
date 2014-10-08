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
        private GameObject SelectedObject;

        public EntityEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Laad de data van de entity in de EntityEditor
        /// </summary>
        public void LoadData(GameObject go)
        {

            // Deze if statement is nodig om een NullReference error te voorkomen
            if (go != null)
            {
                // Maak alle X en Y inputs visible 
                XLocationInput.Visible = true;
                YLocationInput.Visible = true;
                EntityYLocation.Visible = true;
                EntityXLocation.Visible = true;

                // Verkrijg de waardes van het GameObject
                XLocationInput.Text = go.X.ToString();
                YLocationInput.Text = go.Y.ToString();
                EntityNaamLabel.Text = go.Type.ToString();

                // Bewaar GameObject
                SelectedObject = go;


                // Laat het plaatje van het GameObject zien
                if (go.Type.ToString() == "CREEPER")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.creeper;
                }
                else if (go.Type.ToString() == "SLOWER")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.spider;
                }
                else if (go.Type.ToString() == "EXPLODE")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.tnt;
                }
                else if (go.Type.ToString() == "TIMEBOMB")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.timebomb;
                }
                else if (go.Type.ToString() == "CAKE")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cake;
                }
                else if (go.Type.ToString() == "HOME")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.huis;
                }
                else if (go.Type.ToString() == "OBSTACLE")
                {
                    EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cobble;
                }
                else
                {
                    Console.WriteLine("Type niet bekend");
                }
            }
        }

        /// <summary>
        /// Krijg de waardes van de ingevoerde X en Y en 
        /// pas deze toe op de geselecteerde entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToepassenEntity_Click(object sender, EventArgs e)
        {
            int X;
            int Y;
            X = Convert.ToInt32(XLocationInput.Text);
            Y = Convert.ToInt32(YLocationInput.Text);
            X = int.Parse(XLocationInput.Text);
            Y = int.Parse(YLocationInput.Text);

            SelectedObject.X = X;
            SelectedObject.Y = Y;
        }

    }
}
