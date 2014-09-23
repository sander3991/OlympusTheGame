namespace Olympus_the_Game.View
{
    partial class InfoPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.PauseGame = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.QuitGame = new System.Windows.Forms.Button();
            this.InformationTab = new System.Windows.Forms.TabPage();
            this.Menu.SuspendLayout();
            this.MenuTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.MenuTab);
            this.Menu.Controls.Add(this.InformationTab);
            this.Menu.Location = new System.Drawing.Point(2, 2);
            this.Menu.Margin = new System.Windows.Forms.Padding(2);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(313, 261);
            this.Menu.TabIndex = 3;
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.label2);
            this.MenuTab.Controls.Add(this.PauseGame);
            this.MenuTab.Controls.Add(this.label3);
            this.MenuTab.Controls.Add(this.QuitGame);
            this.MenuTab.Location = new System.Drawing.Point(4, 22);
            this.MenuTab.Margin = new System.Windows.Forms.Padding(2);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Padding = new System.Windows.Forms.Padding(2);
            this.MenuTab.Size = new System.Drawing.Size(305, 235);
            this.MenuTab.TabIndex = 0;
            this.MenuTab.Text = "Menu";
            this.MenuTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pauzeer het spel";
            // 
            // PauseGame
            // 
            this.PauseGame.Location = new System.Drawing.Point(4, 65);
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
            this.label3.Location = new System.Drawing.Point(108, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sluit het spel af";
            // 
            // QuitGame
            // 
            this.QuitGame.Location = new System.Drawing.Point(4, 30);
            this.QuitGame.Margin = new System.Windows.Forms.Padding(2);
            this.QuitGame.Name = "QuitGame";
            this.QuitGame.Size = new System.Drawing.Size(99, 19);
            this.QuitGame.TabIndex = 0;
            this.QuitGame.Text = "Sluit af";
            this.QuitGame.UseVisualStyleBackColor = true;
            // 
            // InformationTab
            // 
            this.InformationTab.Location = new System.Drawing.Point(4, 22);
            this.InformationTab.Margin = new System.Windows.Forms.Padding(2);
            this.InformationTab.Name = "InformationTab";
            this.InformationTab.Padding = new System.Windows.Forms.Padding(2);
            this.InformationTab.Size = new System.Drawing.Size(305, 235);
            this.InformationTab.TabIndex = 1;
            this.InformationTab.Text = "Information";
            this.InformationTab.UseVisualStyleBackColor = true;
            // 
            // InfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Menu);
            this.Name = "InfoPanel";
            this.Size = new System.Drawing.Size(313, 262);
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
        private System.Windows.Forms.TabPage InformationTab;
    }
}
