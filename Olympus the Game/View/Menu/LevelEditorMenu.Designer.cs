namespace Olympus_the_Game.View.Menu
{
    partial class LevelEditorMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditorMenu));
            this.ButtonNewEditor = new System.Windows.Forms.Button();
            this.ButtonLoadEditor = new System.Windows.Forms.Button();
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
            this.ButtonNewEditor.TabIndex = 1;
            this.ButtonNewEditor.Text = "Nieuw Speelveld";
            this.ButtonNewEditor.UseVisualStyleBackColor = false;
            // 
            // ButtonLoadEditor
            // 
            this.ButtonLoadEditor.AccessibleDescription = "x";
            this.ButtonLoadEditor.BackColor = System.Drawing.Color.LightGray;
            this.ButtonLoadEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonLoadEditor.BackgroundImage")));
            this.ButtonLoadEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLoadEditor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonLoadEditor.Location = new System.Drawing.Point(3, 58);
            this.ButtonLoadEditor.Name = "ButtonLoadEditor";
            this.ButtonLoadEditor.Size = new System.Drawing.Size(420, 49);
            this.ButtonLoadEditor.TabIndex = 2;
            this.ButtonLoadEditor.Text = "Speelveld Laden";
            this.ButtonLoadEditor.UseVisualStyleBackColor = false;
            // 
            // LevelEditorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonLoadEditor);
            this.Controls.Add(this.ButtonNewEditor);
            this.Name = "LevelEditorMenu";
            this.Size = new System.Drawing.Size(426, 110);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ButtonNewEditor;
        public System.Windows.Forms.Button ButtonLoadEditor;
    }
}
