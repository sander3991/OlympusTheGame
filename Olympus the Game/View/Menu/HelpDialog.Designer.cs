namespace Olympus_the_Game.View.Menu
{
    partial class HelpDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpDialog));
            this.REMOVEME = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // REMOVEME
            // 
            this.REMOVEME.BackColor = System.Drawing.Color.Magenta;
            this.REMOVEME.Location = new System.Drawing.Point(1222, 3);
            this.REMOVEME.Name = "REMOVEME";
            this.REMOVEME.Size = new System.Drawing.Size(42, 45);
            this.REMOVEME.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 0);
            this.label1.MaximumSize = new System.Drawing.Size(624, 0);
            this.label1.MinimumSize = new System.Drawing.Size(624, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 594);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // HelpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.REMOVEME);
            this.DoubleBuffered = true;
            this.Name = "HelpDialog";
            this.Size = new System.Drawing.Size(1264, 680);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel REMOVEME;
        private System.Windows.Forms.Label label1;


    }
}
