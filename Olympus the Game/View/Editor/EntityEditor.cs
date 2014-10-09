using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Olympus_the_Game.View.Imaging;
using System.Reflection;

namespace Olympus_the_Game.View
{
    public partial class EntityEditor : UserControl
    {
        private static readonly int PADDING = 3;

        private static readonly int ROW_HEIGHT = 20;

        private static readonly string[] filteredProperties = new string[] { "frame", "type", "previousx", "previousy", "playfield" , "entitycontrolledbyai"};

        public event Action EntityChanged;

        private GameObject SelectedObject;

        private Dictionary<PropertyInfo, TextBox> inputs;

        public EntityEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Laad de data van de entity in de EntityEditor
        /// </summary>
        public void LoadData(GameObject go)
        {
            // Save GameObject
            this.SelectedObject = go;

            // Deze if statement is nodig om een NullReference error te voorkomen
            if (go != null)
            {
                // Set image
                Sprite s = DataPool.GetPicture(go.Type, this.EntityImageLarge.Size);
                if (s != null)
                {
                    this.EntityImageLarge.BackgroundImage = s[-1.0f];
                }

                // Set name
                this.labelName.Text = go.ToString();

                // Clear everything
                this.panel1.Controls.Clear();
                this.inputs = new Dictionary<PropertyInfo, TextBox>();

                // Start reflection
                int pad = PADDING;
                foreach (PropertyInfo fi in go.GetType().GetProperties().Where<PropertyInfo>(
                    delegate(PropertyInfo pi)
                    {
                        string name = pi.Name;
                        return !filteredProperties.Contains(name.ToLower()) && pi.CanWrite;
                    }))
                {
                    // Create label
                    Label l = new Label();
                    l.Text = fi.Name;
                    l.Left = PADDING;
                    l.Top = pad;
                    l.Height = ROW_HEIGHT;

                    // Create textbox
                    TextBox tb = new TextBox();
                    tb.Text = fi.GetValue(go, new object[] { }).ToString();
                    tb.Top = pad;
                    tb.Left = 150;
                    tb.Height = ROW_HEIGHT;
                    tb.Width = 150;

                    // Add to dictionary
                    inputs.Add(fi, tb);

                    // Add to panel
                    this.panel1.Controls.Add(l);
                    this.panel1.Controls.Add(tb);

                    // Update padding
                    pad += PADDING + l.Height;
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
            foreach (KeyValuePair<PropertyInfo, TextBox> prop in inputs)
            {
                // Get vars
                object val = null;
                PropertyInfo pi = prop.Key;
                TextBox tb = prop.Value;
                string text = tb.Text;

                // Parse value
                try
                {
                    if (pi.PropertyType == typeof(System.Int32))
                    {
                        val = Convert.ToInt32(text);
                    }
                    else if (pi.PropertyType == typeof(System.Boolean))
                    {
                        val = Convert.ToBoolean(text);
                    }

                    // Set property
                    pi.SetValue(SelectedObject, val, new object[] { });
                    tb.BackColor = Color.White;
                }
                catch (FormatException)
                {
                    tb.BackColor = Color.Red;
                }
            }

            // Call event
            EntityChanged();
        }

        private void EntityEditor_Load(object sender, EventArgs e)
        {
            this.ToepassenEntity.BackgroundImage = Properties.Resources.stone;
        }
    }
}
