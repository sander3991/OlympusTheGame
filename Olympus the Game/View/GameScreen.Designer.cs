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
            this.InformationTab = new System.Windows.Forms.TabPage();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.MenuTab);
            this.Menu.Controls.Add(this.InformationTab);
            this.Menu.Controls.Add(this.SettingsTab);
            this.Menu.Location = new System.Drawing.Point(9, 377);
            this.Menu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(308, 236);
            this.Menu.TabIndex = 0;
            // 
            // MenuTab
            // 
            this.MenuTab.Location = new System.Drawing.Point(4, 22);
            this.MenuTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MenuTab.Size = new System.Drawing.Size(300, 210);
            this.MenuTab.TabIndex = 0;
            this.MenuTab.Text = "Menu";
            this.MenuTab.UseVisualStyleBackColor = true;
            this.MenuTab.Click += new System.EventHandler(this.MenuTab_Click);
            // 
            // InformationTab
            // 
            this.InformationTab.Location = new System.Drawing.Point(4, 22);
            this.InformationTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InformationTab.Name = "InformationTab";
            this.InformationTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.InformationTab.Size = new System.Drawing.Size(300, 210);
            this.InformationTab.TabIndex = 1;
            this.InformationTab.Text = "Information";
            this.InformationTab.UseVisualStyleBackColor = true;
            this.InformationTab.Click += new System.EventHandler(this.InformationTab_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SettingsTab.Size = new System.Drawing.Size(300, 210);
            this.SettingsTab.TabIndex = 2;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            this.SettingsTab.Click += new System.EventHandler(this.SettingsTab_Click);
            // 
            // gamePanel1
            // 
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(13, 12);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(1031, 336);
            this.gamePanel1.TabIndex = 1;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 623);
            this.Controls.Add(this.gamePanel1);
            this.Controls.Add(this.Menu);
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Olympus the Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Close);
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Menu;
        private System.Windows.Forms.TabPage MenuTab;
        private System.Windows.Forms.TabPage InformationTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private GamePanel gamePanel1;
    }
}