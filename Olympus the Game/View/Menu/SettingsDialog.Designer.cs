namespace Olympus_the_Game.View.Menu
{
    partial class SettingsDialog
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.ButtonNewEditor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonNewEditor
            // 
            this.ButtonNewEditor.AccessibleDescription = "x";
            this.ButtonNewEditor.BackColor = System.Drawing.Color.LightGray;
            this.ButtonNewEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonNewEditor.BackgroundImage")));
            this.ButtonNewEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNewEditor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonNewEditor.Location = new System.Drawing.Point(3, 3);
            this.ButtonNewEditor.Name = "ButtonNewEditor";
            this.ButtonNewEditor.Size = new System.Drawing.Size(420, 49);
            this.ButtonNewEditor.TabIndex = 2;
            this.ButtonNewEditor.Text = "Geluid";
            this.ButtonNewEditor.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "x";
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(0, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(420, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Snelheid";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonNewEditor);
            this.Name = "SettingsDialog";
            this.Size = new System.Drawing.Size(425, 150);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ButtonNewEditor;
        public System.Windows.Forms.Button button1;
    }
}
