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
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonLevelEditor = new System.Windows.Forms.Button();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(0, 0);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(150, 23);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "Start Game";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonLevelEditor
            // 
            this.ButtonLevelEditor.Location = new System.Drawing.Point(0, 29);
            this.ButtonLevelEditor.Name = "ButtonLevelEditor";
            this.ButtonLevelEditor.Size = new System.Drawing.Size(150, 23);
            this.ButtonLevelEditor.TabIndex = 1;
            this.ButtonLevelEditor.Text = "Level Editor";
            this.ButtonLevelEditor.UseVisualStyleBackColor = true;
            this.ButtonLevelEditor.Click += new System.EventHandler(this.ButtonLevelEditor_Click);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Location = new System.Drawing.Point(0, 58);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(72, 23);
            this.ButtonHelp.TabIndex = 2;
            this.ButtonHelp.Text = "Help";
            this.ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(78, 58);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(72, 23);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.ButtonLevelEditor);
            this.Controls.Add(this.ButtonStart);
            this.Name = "MainMenuControl";
            this.Size = new System.Drawing.Size(150, 80);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonLevelEditor;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.Button ButtonExit;
    }
}
