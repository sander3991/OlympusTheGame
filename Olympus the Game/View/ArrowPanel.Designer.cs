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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SleepKnop = new System.Windows.Forms.Button();
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.SleepKnop);
            this.panel1.Controls.Add(this.ArrowKeyRight);
            this.panel1.Controls.Add(this.ArrowKeyLeft);
            this.panel1.Controls.Add(this.ArrowKeyDown);
            this.panel1.Controls.Add(this.ArrowKeyUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 241);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Toetsen aanpassen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox4
            // 
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.Location = new System.Drawing.Point(30, 60);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(21, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBox4.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBox3
            // 
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(30, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(21, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBox3.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(3, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(21, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBox2.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(57, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(21, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBox1.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // SleepKnop
            // 
            this.SleepKnop.FlatAppearance.BorderSize = 0;
            this.SleepKnop.ForeColor = System.Drawing.Color.Transparent;
            this.SleepKnop.Image = global::Olympus_the_Game.Properties.Resources.rsz_1dragbutton;
            this.SleepKnop.Location = new System.Drawing.Point(287, 3);
            this.SleepKnop.Name = "SleepKnop";
            this.SleepKnop.Size = new System.Drawing.Size(40, 40);
            this.SleepKnop.TabIndex = 6;
            this.SleepKnop.UseVisualStyleBackColor = true;
            this.SleepKnop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SleepKnop_MouseDown);
            this.SleepKnop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SleepKnop_MouseMove);
            // 
            // ArrowKeyRight
            // 
            this.ArrowKeyRight.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyRight.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowright;
            this.ArrowKeyRight.Location = new System.Drawing.Point(216, 154);
            this.ArrowKeyRight.Name = "ArrowKeyRight";
            this.ArrowKeyRight.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyRight.TabIndex = 9;
            this.ArrowKeyRight.UseVisualStyleBackColor = true;
            this.ArrowKeyRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // ArrowKeyLeft
            // 
            this.ArrowKeyLeft.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyLeft.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowleft;
            this.ArrowKeyLeft.Location = new System.Drawing.Point(24, 154);
            this.ArrowKeyLeft.Name = "ArrowKeyLeft";
            this.ArrowKeyLeft.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyLeft.TabIndex = 7;
            this.ArrowKeyLeft.UseVisualStyleBackColor = true;
            this.ArrowKeyLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // ArrowKeyDown
            // 
            this.ArrowKeyDown.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyDown.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowdown;
            this.ArrowKeyDown.Location = new System.Drawing.Point(120, 154);
            this.ArrowKeyDown.Name = "ArrowKeyDown";
            this.ArrowKeyDown.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyDown.TabIndex = 8;
            this.ArrowKeyDown.UseVisualStyleBackColor = true;
            this.ArrowKeyDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // ArrowKeyUp
            // 
            this.ArrowKeyUp.ForeColor = System.Drawing.Color.Transparent;
            this.ArrowKeyUp.Image = global::Olympus_the_Game.Properties.Resources.rsz_arrowup;
            this.ArrowKeyUp.Location = new System.Drawing.Point(120, 64);
            this.ArrowKeyUp.Name = "ArrowKeyUp";
            this.ArrowKeyUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ArrowKeyUp.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyUp.TabIndex = 6;
            this.ArrowKeyUp.UseVisualStyleBackColor = true;
            this.ArrowKeyUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
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
        private System.Windows.Forms.Button SleepKnop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
