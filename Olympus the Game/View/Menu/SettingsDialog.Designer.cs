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
            this.ButtonGeluidDempen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonGeluidDempen
            // 
            this.ButtonGeluidDempen.AccessibleDescription = "x";
            this.ButtonGeluidDempen.BackColor = System.Drawing.Color.LightGray;
            this.ButtonGeluidDempen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonGeluidDempen.BackgroundImage")));
            this.ButtonGeluidDempen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGeluidDempen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonGeluidDempen.Location = new System.Drawing.Point(3, 3);
            this.ButtonGeluidDempen.Name = "ButtonGeluidDempen";
            this.ButtonGeluidDempen.Size = new System.Drawing.Size(420, 49);
            this.ButtonGeluidDempen.TabIndex = 2;
            this.ButtonGeluidDempen.Text = "Geluid uitzetten";
            this.ButtonGeluidDempen.UseVisualStyleBackColor = false;
            this.ButtonGeluidDempen.Click += new System.EventHandler(this.ButtonGeluidDempen_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonGeluidDempen);
            this.Name = "SettingsDialog";
            this.Size = new System.Drawing.Size(425, 110);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ButtonGeluidDempen;
    }
}
