namespace Olympus_the_Game.View {
    partial class MainMenuControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuControl));
            this.ButtonLevelEditor = new System.Windows.Forms.Button();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonLevelEditor
            // 
            this.ButtonLevelEditor.AccessibleDescription = "x";
            this.ButtonLevelEditor.BackColor = System.Drawing.Color.LightGray;
            this.ButtonLevelEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonLevelEditor.BackgroundImage")));
            this.ButtonLevelEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLevelEditor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonLevelEditor.Location = new System.Drawing.Point(3, 58);
            this.ButtonLevelEditor.Name = "ButtonLevelEditor";
            this.ButtonLevelEditor.Size = new System.Drawing.Size(420, 49);
            this.ButtonLevelEditor.TabIndex = 1;
            this.ButtonLevelEditor.Text = "Level Editor";
            this.ButtonLevelEditor.UseVisualStyleBackColor = false;
            this.ButtonLevelEditor.Click += new System.EventHandler(this.ButtonLevelEditor_Click);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.AccessibleDescription = "x";
            this.ButtonHelp.BackColor = System.Drawing.Color.LightGray;
            this.ButtonHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonHelp.BackgroundImage")));
            this.ButtonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonHelp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonHelp.Location = new System.Drawing.Point(3, 113);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(205, 49);
            this.ButtonHelp.TabIndex = 2;
            this.ButtonHelp.Text = "Help";
            this.ButtonHelp.UseVisualStyleBackColor = false;
            this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.AccessibleDescription = "x";
            this.ButtonExit.BackColor = System.Drawing.Color.LightGray;
            this.ButtonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonExit.BackgroundImage")));
            this.ButtonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonExit.Location = new System.Drawing.Point(218, 113);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(205, 49);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = false;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.AccessibleDescription = "x";
            this.ButtonStart.BackColor = System.Drawing.Color.LightGray;
            this.ButtonStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonStart.BackgroundImage")));
            this.ButtonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonStart.Location = new System.Drawing.Point(3, 3);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(420, 49);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start Game";
            this.ButtonStart.UseVisualStyleBackColor = false;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.ButtonLevelEditor);
            this.Controls.Add(this.ButtonStart);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "MainMenuControl";
            this.Size = new System.Drawing.Size(497, 167);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLevelEditor;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonStart;

    }
}
