namespace Olympus_the_Game.View.Menu {
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
            this.ButtonSettings = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.AccessibleDescription = "x";
            this.ButtonSettings.BackColor = System.Drawing.Color.LightGray;
            this.ButtonSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonSettings.BackgroundImage")));
            this.ButtonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonSettings.Location = new System.Drawing.Point(3, 113);
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Size = new System.Drawing.Size(420, 49);
            this.ButtonSettings.TabIndex = 2;
            this.ButtonSettings.Text = "Instellingen";
            this.ButtonSettings.UseVisualStyleBackColor = false;
            // 
            // ButtonExit
            // 
            this.ButtonExit.AccessibleDescription = "x";
            this.ButtonExit.BackColor = System.Drawing.Color.LightGray;
            this.ButtonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonExit.BackgroundImage")));
            this.ButtonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonExit.Location = new System.Drawing.Point(218, 168);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(205, 49);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.Text = "Stoppen";
            this.ButtonExit.UseVisualStyleBackColor = false;
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
            this.ButtonStart.Text = "Spel Starten";
            this.ButtonStart.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "x";
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(3, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonSettings);
            this.Controls.Add(this.ButtonLevelEditor);
            this.Controls.Add(this.ButtonStart);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "MainMenuControl";
            this.Size = new System.Drawing.Size(426, 221);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ButtonLevelEditor;
        public System.Windows.Forms.Button ButtonSettings;
        public System.Windows.Forms.Button ButtonExit;
        public System.Windows.Forms.Button ButtonStart;
        public System.Windows.Forms.Button button1;

    }
}
