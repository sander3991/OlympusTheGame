namespace Olympus_the_Game.View
{
    partial class GameScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.TabControl();
            this.MenuTab = new System.Windows.Forms.TabPage();
            this.QuitGame = new System.Windows.Forms.Button();
            this.InformationTab = new System.Windows.Forms.TabPage();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PauseGame = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            this.MenuTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.MenuTab);
            this.Menu.Controls.Add(this.InformationTab);
            this.Menu.Controls.Add(this.SettingsTab);
            this.Menu.Location = new System.Drawing.Point(17, 435);
            this.Menu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(417, 321);
            this.Menu.TabIndex = 0;
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.label2);
            this.MenuTab.Controls.Add(this.PauseGame);
            this.MenuTab.Controls.Add(this.label1);
            this.MenuTab.Controls.Add(this.QuitGame);
            this.MenuTab.Location = new System.Drawing.Point(4, 25);
            this.MenuTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MenuTab.Size = new System.Drawing.Size(409, 292);
            this.MenuTab.TabIndex = 0;
            this.MenuTab.Text = "Menu";
            this.MenuTab.UseVisualStyleBackColor = true;
            this.MenuTab.Click += new System.EventHandler(this.MenuTab_Click);
            // 
            // QuitGame
            // 
            this.QuitGame.Location = new System.Drawing.Point(6, 37);
            this.QuitGame.Name = "QuitGame";
            this.QuitGame.Size = new System.Drawing.Size(132, 23);
            this.QuitGame.TabIndex = 0;
            this.QuitGame.Text = "Sluit af";
            this.QuitGame.UseVisualStyleBackColor = true;
            this.QuitGame.Click += new System.EventHandler(this.QuitGame_Click);
            // 
            // InformationTab
            // 
            this.InformationTab.Location = new System.Drawing.Point(4, 25);
            this.InformationTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InformationTab.Name = "InformationTab";
            this.InformationTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InformationTab.Size = new System.Drawing.Size(409, 292);
            this.InformationTab.TabIndex = 1;
            this.InformationTab.Text = "Information";
            this.InformationTab.UseVisualStyleBackColor = true;
            this.InformationTab.Click += new System.EventHandler(this.InformationTab_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Location = new System.Drawing.Point(4, 25);
            this.SettingsTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SettingsTab.Size = new System.Drawing.Size(409, 292);
            this.SettingsTab.TabIndex = 2;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            this.SettingsTab.Click += new System.EventHandler(this.SettingsTab_Click);
            // 
            // gamePanel1
            // 
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(17, 15);
            this.gamePanel1.Margin = new System.Windows.Forms.Padding(5);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(1374, 413);
            this.gamePanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sluit het spel af";
            // 
            // PauseGame
            // 
            this.PauseGame.Location = new System.Drawing.Point(6, 80);
            this.PauseGame.Name = "PauseGame";
            this.PauseGame.Size = new System.Drawing.Size(132, 23);
            this.PauseGame.TabIndex = 2;
            this.PauseGame.Text = "Pauzeer spel";
            this.PauseGame.UseVisualStyleBackColor = true;
            this.PauseGame.Click += new System.EventHandler(this.PauseGame_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pauzeer het spel";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 767);
            this.Controls.Add(this.gamePanel1);
            this.Controls.Add(this.Menu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Olympus the Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Close);
            this.Menu.ResumeLayout(false);
            this.MenuTab.ResumeLayout(false);
            this.MenuTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Menu;
        private System.Windows.Forms.TabPage MenuTab;
        private System.Windows.Forms.TabPage InformationTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private GamePanel gamePanel1;
        private System.Windows.Forms.Button QuitGame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PauseGame;
        private System.Windows.Forms.Label label1;
    }
}