﻿namespace Olympus_the_Game.View
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
            this.ButtonAanpassen = new System.Windows.Forms.Button();
            this.textBoxDown = new System.Windows.Forms.TextBox();
            this.textBoxUp = new System.Windows.Forms.TextBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.SleepKnop = new System.Windows.Forms.Button();
            this.ArrowKeyRight = new System.Windows.Forms.Button();
            this.ArrowKeyLeft = new System.Windows.Forms.Button();
            this.ArrowKeyDown = new System.Windows.Forms.Button();
            this.ArrowKeyUp = new System.Windows.Forms.Button();
            this.LabelControl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.ButtonAanpassen);
            this.panel1.Controls.Add(this.textBoxDown);
            this.panel1.Controls.Add(this.textBoxUp);
            this.panel1.Controls.Add(this.textBoxLeft);
            this.panel1.Controls.Add(this.textBoxRight);
            this.panel1.Controls.Add(this.SleepKnop);
            this.panel1.Controls.Add(this.ArrowKeyRight);
            this.panel1.Controls.Add(this.ArrowKeyLeft);
            this.panel1.Controls.Add(this.ArrowKeyDown);
            this.panel1.Controls.Add(this.ArrowKeyUp);
            this.panel1.Controls.Add(this.LabelControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 205);
            this.panel1.TabIndex = 2;
            // 
            // ButtonAanpassen
            // 
            this.ButtonAanpassen.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ButtonAanpassen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAanpassen.Location = new System.Drawing.Point(12, 70);
            this.ButtonAanpassen.Name = "ButtonAanpassen";
            this.ButtonAanpassen.Size = new System.Drawing.Size(76, 40);
            this.ButtonAanpassen.TabIndex = 5;
            this.ButtonAanpassen.Text = "Toetsen aanpassen";
            this.ButtonAanpassen.UseVisualStyleBackColor = false;
            this.ButtonAanpassen.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDown
            // 
            this.textBoxDown.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDown.Location = new System.Drawing.Point(39, 44);
            this.textBoxDown.Name = "textBoxDown";
            this.textBoxDown.Size = new System.Drawing.Size(21, 20);
            this.textBoxDown.TabIndex = 3;
            this.textBoxDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxDown.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBoxUp
            // 
            this.textBoxUp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxUp.Location = new System.Drawing.Point(39, 18);
            this.textBoxUp.Name = "textBoxUp";
            this.textBoxUp.Size = new System.Drawing.Size(21, 20);
            this.textBoxUp.TabIndex = 1;
            this.textBoxUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxUp.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxLeft.Location = new System.Drawing.Point(12, 44);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(21, 20);
            this.textBoxLeft.TabIndex = 2;
            this.textBoxLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxLeft.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBoxRight
            // 
            this.textBoxRight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxRight.Location = new System.Drawing.Point(66, 44);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(21, 20);
            this.textBoxRight.TabIndex = 4;
            this.textBoxRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxRight.Enter += new System.EventHandler(this.textBox_Enter);
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
            this.ArrowKeyRight.Location = new System.Drawing.Point(214, 110);
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
            this.ArrowKeyLeft.Location = new System.Drawing.Point(22, 110);
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
            this.ArrowKeyDown.Location = new System.Drawing.Point(118, 110);
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
            this.ArrowKeyUp.Location = new System.Drawing.Point(118, 20);
            this.ArrowKeyUp.Name = "ArrowKeyUp";
            this.ArrowKeyUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ArrowKeyUp.Size = new System.Drawing.Size(90, 84);
            this.ArrowKeyUp.TabIndex = 6;
            this.ArrowKeyUp.UseVisualStyleBackColor = true;
            this.ArrowKeyUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ArrowKey_MouseDown);
            this.ArrowKeyUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopMoving);
            // 
            // LabelControl
            // 
            this.LabelControl.AutoSize = true;
            this.LabelControl.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LabelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelControl.Location = new System.Drawing.Point(0, 0);
            this.LabelControl.Name = "LabelControl";
            this.LabelControl.Size = new System.Drawing.Size(60, 13);
            this.LabelControl.TabIndex = 0;
            this.LabelControl.Text = "Besturing";
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
        private System.Windows.Forms.Label LabelControl;
        private System.Windows.Forms.Button SleepKnop;
        private System.Windows.Forms.Button ButtonAanpassen;
        private System.Windows.Forms.TextBox textBoxDown;
        private System.Windows.Forms.TextBox textBoxUp;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxRight;
    }
}
