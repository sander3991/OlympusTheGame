using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using Olympus_the_Game.Properties;
using Olympus_the_Game.View.Imaging;
using System.Reflection;

namespace Olympus_the_Game.View.Editor
{
    public partial class EntityEditor : UserControl
    {
        private const int BorderPadding = 3;

        private const int RowHeight = 20;

        private GameObject _selectedObject;

        private Dictionary<PropertyInfo, TextBox> _inputs;

        public EntityEditor()
        {
            InitializeComponent();
            // Set styles
            Utils.SetButtonStyle(ToepassenEntity);
        }

        public event Action EntityChanged;

        /// <summary>
        /// Laad de data van de entity in de EntityEditor
        /// </summary>
        public void LoadData(GameObject go)
        {
            // Save GameObject
            _selectedObject = go;

            // Deze if statement is nodig om een NullReference error te voorkomen
            if (go == null) return;
            // Set image
            Sprite s = DataPool.GetPicture(go.Type, EntityImageLarge.Size);
            if (s != null)
            {
                EntityImageLarge.BackgroundImage = s[-1.0f];
            }

            // Set name
            labelName.Text = go.ToString();

            // Clear everything
            panel1.Controls.Clear();
            _inputs = new Dictionary<PropertyInfo, TextBox>();

            // Start reflection
            int pad = BorderPadding;
            foreach (PropertyInfo fi in go.GetType().GetProperties().Where(
                delegate(PropertyInfo pi)
                {
                    object[] attributes = pi.GetCustomAttributes(typeof(ExcludeFromEditor), true);
                    return pi.CanWrite && (!attributes.Any() || !((ExcludeFromEditor)attributes[0]).Exclude);
                }))
            {
                // Create label
                Label l = new Label { Text = fi.Name, Left = BorderPadding, Top = pad, Height = RowHeight };

                // Create textbox
                TextBox tb = new TextBox
                {
                    Text = fi.GetValue(go, new object[] { }).ToString(),
                    Top = pad,
                    Left = 150,
                    Height = RowHeight,
                    Width = 150
                };

                object[] attributes = fi.GetCustomAttributes(typeof(EditorTooltip), true);
                if (attributes != null && attributes.Length > 0)
                {
                    EditorTooltip attr_tooltip = attributes[0] as EditorTooltip;
                    if (attr_tooltip != null)
                    {
                        ToolTip tooltip = new ToolTip();
                        tooltip.InitialDelay = 0;
                        tooltip.UseAnimation = true;
                        tooltip.SetToolTip(tb, attr_tooltip.Description);
                        l.Text = attr_tooltip.Name;
                    }
                }


                // Add to dictionary
                _inputs.Add(fi, tb);

                // Add to panel
                panel1.Controls.Add(l);
                panel1.Controls.Add(tb);

                // Update padding
                pad += BorderPadding + l.Height;
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
            foreach (KeyValuePair<PropertyInfo, TextBox> prop in _inputs)
            {
                // Get vars
                object val = null;
                PropertyInfo pi = prop.Key;
                TextBox tb = prop.Value;
                string text = tb.Text;

                // Parse value
                try
                {
                    if (pi.PropertyType == typeof(Int32))
                    {
                        val = Convert.ToInt32(text);
                    }
                    else if (pi.PropertyType == typeof(Boolean))
                    {
                        val = Convert.ToBoolean(text);
                    }

                    // Set property
                    pi.SetValue(_selectedObject, val, new object[] { });
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
            ToepassenEntity.BackgroundImage = Resources.stone;
        }
    }
}