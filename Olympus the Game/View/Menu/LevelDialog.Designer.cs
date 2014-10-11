namespace Olympus_the_Game.View.Menu
{
    partial class LevelDialog
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
            this.ScrollArrowUp = new System.Windows.Forms.PictureBox();
            this.ScrollArrowDown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollArrowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollArrowDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ScrollArrowUp
            // 
            this.ScrollArrowUp.Image = global::Olympus_the_Game.Properties.Resources.ScrollArrowUp;
            this.ScrollArrowUp.Location = new System.Drawing.Point(106, 0);
            this.ScrollArrowUp.Name = "ScrollArrowUp";
            this.ScrollArrowUp.Size = new System.Drawing.Size(213, 50);
            this.ScrollArrowUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScrollArrowUp.TabIndex = 0;
            this.ScrollArrowUp.TabStop = false;
            this.ScrollArrowUp.Click += new System.EventHandler(this.ScrollArrowUp_Click);
            // 
            // ScrollArrowDown
            // 
            this.ScrollArrowDown.Image = global::Olympus_the_Game.Properties.Resources.ScrollArrowDown;
            this.ScrollArrowDown.Location = new System.Drawing.Point(106, 350);
            this.ScrollArrowDown.Name = "ScrollArrowDown";
            this.ScrollArrowDown.Size = new System.Drawing.Size(213, 50);
            this.ScrollArrowDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScrollArrowDown.TabIndex = 1;
            this.ScrollArrowDown.TabStop = false;
            this.ScrollArrowDown.Click += new System.EventHandler(this.ScrollArrowDown_Click);
            // 
            // LevelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ScrollArrowDown);
            this.Controls.Add(this.ScrollArrowUp);
            this.Name = "LevelDialog";
            this.Size = new System.Drawing.Size(426, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ScrollArrowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollArrowDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ScrollArrowUp;
        private System.Windows.Forms.PictureBox ScrollArrowDown;


    }
}
