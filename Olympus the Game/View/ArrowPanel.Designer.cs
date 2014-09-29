namespace Olympus_the_Game.View
{
    partial class ArrowPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ArrowKeyRight = new System.Windows.Forms.Button();
            this.ArrowKeyLeft = new System.Windows.Forms.Button();
            this.ArrowKeyDown = new System.Windows.Forms.Button();
            this.ArrowKeyUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ArrowKeyRight);
            this.panel1.Controls.Add(this.ArrowKeyLeft);
            this.panel1.Controls.Add(this.ArrowKeyDown);
            this.panel1.Controls.Add(this.ArrowKeyUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 241);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ArrowKeyRight
            // 
            this.ArrowKeyRight.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyRight.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowright;
            this.ArrowKeyRight.Location = new System.Drawing.Point(216, 132);
            this.ArrowKeyRight.Name = "ArrowKeyRight";
            this.ArrowKeyRight.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyRight.TabIndex = 4;
            this.ArrowKeyRight.UseVisualStyleBackColor = true;
            this.ArrowKeyRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // ArrowKeyLeft
            // 
            this.ArrowKeyLeft.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyLeft.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowleft;
            this.ArrowKeyLeft.Location = new System.Drawing.Point(24, 132);
            this.ArrowKeyLeft.Name = "ArrowKeyLeft";
            this.ArrowKeyLeft.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyLeft.TabIndex = 3;
            this.ArrowKeyLeft.UseVisualStyleBackColor = true;
            this.ArrowKeyLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // ArrowKeyDown
            // 
            this.ArrowKeyDown.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyDown.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowdown;
            this.ArrowKeyDown.Location = new System.Drawing.Point(120, 132);
            this.ArrowKeyDown.Name = "ArrowKeyDown";
            this.ArrowKeyDown.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyDown.TabIndex = 2;
            this.ArrowKeyDown.UseVisualStyleBackColor = true;
            this.ArrowKeyDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // ArrowKeyUp
            // 
            this.ArrowKeyUp.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyUp.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowup;
            this.ArrowKeyUp.Location = new System.Drawing.Point(120, 42);
            this.ArrowKeyUp.Name = "ArrowKeyUp";
            this.ArrowKeyUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ArrowKeyUp.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyUp.TabIndex = 1;
            this.ArrowKeyUp.UseVisualStyleBackColor = true;
            this.ArrowKeyUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controls";
            // 
            // ArrowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "ArrowPanel";
            this.Size = new System.Drawing.Size(337, 247);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ArrowKeyRight;
        private System.Windows.Forms.Button ArrowKeyLeft;
        private System.Windows.Forms.Button ArrowKeyDown;
        private System.Windows.Forms.Button ArrowKeyUp;
        private System.Windows.Forms.Label label1;
    }
}
