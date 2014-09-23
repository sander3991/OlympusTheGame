namespace Olympus_the_Game.View
{
    partial class InfoPanel
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
            this.StatistiekenTab = new System.Windows.Forms.TabControl();
            this.Statistieken = new System.Windows.Forms.TabPage();
            this.StatistiekenTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatistiekenTab
            // 
            this.StatistiekenTab.Controls.Add(this.Statistieken);
            this.StatistiekenTab.Location = new System.Drawing.Point(3, 3);
            this.StatistiekenTab.Name = "StatistiekenTab";
            this.StatistiekenTab.SelectedIndex = 0;
            this.StatistiekenTab.Size = new System.Drawing.Size(365, 550);
            this.StatistiekenTab.TabIndex = 0;
            // 
            // Statistieken
            // 
            this.Statistieken.Location = new System.Drawing.Point(4, 25);
            this.Statistieken.Name = "Statistieken";
            this.Statistieken.Padding = new System.Windows.Forms.Padding(3);
            this.Statistieken.Size = new System.Drawing.Size(357, 521);
            this.Statistieken.TabIndex = 0;
            this.Statistieken.Text = "tabPage1";
            this.Statistieken.UseVisualStyleBackColor = true;
            // 
            // InfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StatistiekenTab);
            this.Name = "InfoPanel";
            this.Size = new System.Drawing.Size(368, 556);
            this.StatistiekenTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl StatistiekenTab;
        private System.Windows.Forms.TabPage Statistieken;
    }
}
