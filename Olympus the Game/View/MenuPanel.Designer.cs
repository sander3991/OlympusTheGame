namespace Olympus_the_Game.View
{
    partial class MenuPanel
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
            this.Menu = new System.Windows.Forms.TabControl();
            this.MenuTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.LevelEditor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadLevel = new System.Windows.Forms.Button();
            this.SpelUitleg = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PauseGame = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.QuitGame = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.MenuTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.MenuTab);
            this.Menu.Location = new System.Drawing.Point(3, 2);
            this.Menu.Margin = new System.Windows.Forms.Padding(2);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(313, 243);
            this.Menu.TabIndex = 3;
            // 
            // MenuTab
            // 
            this.MenuTab.BackColor = System.Drawing.SystemColors.Control;
            this.MenuTab.Controls.Add(this.label4);
            this.MenuTab.Controls.Add(this.LevelEditor);
            this.MenuTab.Controls.Add(this.label1);
            this.MenuTab.Controls.Add(this.LoadLevel);
            this.MenuTab.Controls.Add(this.SpelUitleg);
            this.MenuTab.Controls.Add(this.label2);
            this.MenuTab.Controls.Add(this.PauseGame);
            this.MenuTab.Controls.Add(this.label3);
            this.MenuTab.Controls.Add(this.QuitGame);
            this.MenuTab.ForeColor = System.Drawing.Color.Black;
            this.MenuTab.Location = new System.Drawing.Point(4, 22);
            this.MenuTab.Margin = new System.Windows.Forms.Padding(2);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Padding = new System.Windows.Forms.Padding(2);
            this.MenuTab.Size = new System.Drawing.Size(305, 217);
            this.MenuTab.TabIndex = 0;
            this.MenuTab.Text = "Menu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maak je eigen level";
            // 
            // LevelEditor
            // 
            this.LevelEditor.Location = new System.Drawing.Point(4, 106);
            this.LevelEditor.Margin = new System.Windows.Forms.Padding(2);
            this.LevelEditor.Name = "LevelEditor";
            this.LevelEditor.Size = new System.Drawing.Size(99, 19);
            this.LevelEditor.TabIndex = 7;
            this.LevelEditor.Text = "Level Editor";
            this.LevelEditor.UseVisualStyleBackColor = true;
            this.LevelEditor.Click += new System.EventHandler(this.LevelEditor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Laad een level";
            // 
            // LoadLevel
            // 
            this.LoadLevel.Location = new System.Drawing.Point(4, 27);
            this.LoadLevel.Margin = new System.Windows.Forms.Padding(2);
            this.LoadLevel.Name = "LoadLevel";
            this.LoadLevel.Size = new System.Drawing.Size(99, 19);
            this.LoadLevel.TabIndex = 5;
            this.LoadLevel.Text = "Laad level";
            this.LoadLevel.UseVisualStyleBackColor = true;
            this.LoadLevel.Click += new System.EventHandler(this.LoadLevel_Click);
            // 
            // SpelUitleg
            // 
            this.SpelUitleg.BackColor = System.Drawing.SystemColors.Menu;
            this.SpelUitleg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpelUitleg.DetectUrls = false;
            this.SpelUitleg.Location = new System.Drawing.Point(28, 138);
            this.SpelUitleg.Margin = new System.Windows.Forms.Padding(2);
            this.SpelUitleg.Name = "SpelUitleg";
            this.SpelUitleg.ReadOnly = true;
            this.SpelUitleg.ShortcutsEnabled = false;
            this.SpelUitleg.Size = new System.Drawing.Size(243, 64);
            this.SpelUitleg.TabIndex = 4;
            this.SpelUitleg.Text = "Doel van het spel:\n\nKrijg het poppetje van het huisje naar de ster zonder dood te" +
    " gaan!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pauzeer het spel";
            // 
            // PauseGame
            // 
            this.PauseGame.Location = new System.Drawing.Point(4, 49);
            this.PauseGame.Margin = new System.Windows.Forms.Padding(2);
            this.PauseGame.Name = "PauseGame";
            this.PauseGame.Size = new System.Drawing.Size(99, 19);
            this.PauseGame.TabIndex = 2;
            this.PauseGame.Text = "Pauzeer spel";
            this.PauseGame.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sluit het spel af";
            // 
            // QuitGame
            // 
            this.QuitGame.Location = new System.Drawing.Point(4, 71);
            this.QuitGame.Margin = new System.Windows.Forms.Padding(2);
            this.QuitGame.Name = "QuitGame";
            this.QuitGame.Size = new System.Drawing.Size(99, 19);
            this.QuitGame.TabIndex = 0;
            this.QuitGame.Text = "Sluit af";
            this.QuitGame.UseVisualStyleBackColor = true;
            this.QuitGame.Click += new System.EventHandler(this.QuitGame_Click);
            // 
            // MenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Menu);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(321, 254);
            this.Menu.ResumeLayout(false);
            this.MenuTab.ResumeLayout(false);
            this.MenuTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Menu;
        private System.Windows.Forms.TabPage MenuTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PauseGame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button QuitGame;
        private System.Windows.Forms.RichTextBox SpelUitleg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoadLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LevelEditor;
    }
}
