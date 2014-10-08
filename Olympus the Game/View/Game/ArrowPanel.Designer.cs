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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrowPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.moveButton1 = new Olympus_the_Game.View.Buttons.MoveButton();
            this.popupButton1 = new Olympus_the_Game.View.Buttons.PopupButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDown = new System.Windows.Forms.TextBox();
            this.textBoxUp = new System.Windows.Forms.TextBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.ArrowKeyRight = new System.Windows.Forms.Button();
            this.ArrowKeyLeft = new System.Windows.Forms.Button();
            this.ArrowKeyDown = new System.Windows.Forms.Button();
            this.ArrowKeyUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.moveButton1);
            this.panel1.Controls.Add(this.popupButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxDown);
            this.panel1.Controls.Add(this.textBoxUp);
            this.panel1.Controls.Add(this.textBoxLeft);
            this.panel1.Controls.Add(this.textBoxRight);
            this.panel1.Controls.Add(this.ArrowKeyRight);
            this.panel1.Controls.Add(this.ArrowKeyLeft);
            this.panel1.Controls.Add(this.ArrowKeyDown);
            this.panel1.Controls.Add(this.ArrowKeyUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 205);
            this.panel1.TabIndex = 2;
            // 
            // moveButton1
            // 
            this.moveButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveButton1.BackgroundImage")));
            this.moveButton1.Image = ((System.Drawing.Image)(resources.GetObject("moveButton1.Image")));
            this.moveButton1.Location = new System.Drawing.Point(287, 3);
            this.moveButton1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.moveButton1.Name = "moveButton1";
            this.moveButton1.Size = new System.Drawing.Size(40, 40);
            this.moveButton1.TabIndex = 12;
            this.moveButton1.UseVisualStyleBackColor = true;
            // 
            // popupButton1
            // 
            this.popupButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("popupButton1.BackgroundImage")));
            this.popupButton1.Image = global::Olympus_the_Game.Properties.Resources.new_window_icon;
            this.popupButton1.Location = new System.Drawing.Point(241, 3);
            this.popupButton1.Name = "popupButton1";
            this.popupButton1.Size = new System.Drawing.Size(40, 40);
            this.popupButton1.TabIndex = 11;
            this.popupButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pas besturing aan";
            // 
            // textBoxDown
            // 
            this.textBoxDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDown.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDown.Location = new System.Drawing.Point(49, 62);
            this.textBoxDown.Name = "textBoxDown";
            this.textBoxDown.Size = new System.Drawing.Size(21, 20);
            this.textBoxDown.TabIndex = 3;
            this.textBoxDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxDown.TextChanged += new System.EventHandler(this.Textfield_ChangeControls);
            this.textBoxDown.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBoxUp
            // 
            this.textBoxUp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUp.Location = new System.Drawing.Point(49, 36);
            this.textBoxUp.Name = "textBoxUp";
            this.textBoxUp.Size = new System.Drawing.Size(21, 20);
            this.textBoxUp.TabIndex = 1;
            this.textBoxUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxUp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxUp.TextChanged += new System.EventHandler(this.Textfield_ChangeControls);
            this.textBoxUp.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLeft.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLeft.Location = new System.Drawing.Point(22, 62);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(21, 20);
            this.textBoxLeft.TabIndex = 2;
            this.textBoxLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxLeft.TextChanged += new System.EventHandler(this.Textfield_ChangeControls);
            this.textBoxLeft.Enter += new System.EventHandler(this.textBox_Enter);
            // 
            // textBoxRight
            // 
            this.textBoxRight.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRight.Location = new System.Drawing.Point(76, 62);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(21, 20);
            this.textBoxRight.TabIndex = 4;
            this.textBoxRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_EnterWithMouse);
            this.textBoxRight.TextChanged += new System.EventHandler(this.Textfield_ChangeControls);
            this.textBoxRight.Enter += new System.EventHandler(this.textBox_Enter);
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
            // ArrowPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Name = "ArrowPanel";
            this.Size = new System.Drawing.Size(337, 204);
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
        private System.Windows.Forms.TextBox textBoxDown;
        private System.Windows.Forms.TextBox textBoxUp;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.Label label1;
        private Buttons.PopupButton popupButton1;
        private Buttons.MoveButton moveButton1;
    }
}
