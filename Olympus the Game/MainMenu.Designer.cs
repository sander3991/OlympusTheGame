namespace Olympus_the_Game {
    partial class MainMenu {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ExitGame = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.LevelEditor = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.ExitGame);
            this.MenuPanel.Controls.Add(this.Settings);
            this.MenuPanel.Controls.Add(this.LevelEditor);
            this.MenuPanel.Controls.Add(this.StartGame);
            this.MenuPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MenuPanel.Location = new System.Drawing.Point(33, 12);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(297, 114);
            this.MenuPanel.TabIndex = 0;
            // 
            // ExitGame
            // 
            this.ExitGame.Location = new System.Drawing.Point(154, 78);
            this.ExitGame.Name = "ExitGame";
            this.ExitGame.Size = new System.Drawing.Size(140, 30);
            this.ExitGame.TabIndex = 3;
            this.ExitGame.Text = "Exit Game";
            this.ExitGame.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(4, 78);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(140, 30);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            // 
            // LevelEditor
            // 
            this.LevelEditor.Location = new System.Drawing.Point(4, 42);
            this.LevelEditor.Name = "LevelEditor";
            this.LevelEditor.Size = new System.Drawing.Size(290, 30);
            this.LevelEditor.TabIndex = 1;
            this.LevelEditor.Text = "Level Editor";
            this.LevelEditor.UseVisualStyleBackColor = true;
            // 
            // StartGame
            // 
            this.StartGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartGame.Location = new System.Drawing.Point(4, 4);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(290, 30);
            this.StartGame.TabIndex = 0;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(994, 605);
            this.Controls.Add(this.MenuPanel);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button ExitGame;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button LevelEditor;
        private System.Windows.Forms.Button StartGame;
    }
}