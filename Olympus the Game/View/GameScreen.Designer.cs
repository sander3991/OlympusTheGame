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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.infoPanel2 = new Olympus_the_Game.View.InfoPanel();
            this.arrowPanel1 = new Olympus_the_Game.View.ArrowPanel();
            this.menuPanel = new Olympus_the_Game.View.MenuPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.SuspendLayout();
            // 
            // infoPanel2
            // 
            this.infoPanel2.Location = new System.Drawing.Point(1081, 12);
            this.infoPanel2.Name = "infoPanel2";
            this.infoPanel2.Size = new System.Drawing.Size(344, 666);
            this.infoPanel2.TabIndex = 4;
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.Location = new System.Drawing.Point(458, 449);
            this.arrowPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.arrowPanel1.Name = "arrowPanel1";
            this.arrowPanel1.Size = new System.Drawing.Size(449, 304);
            this.arrowPanel1.TabIndex = 3;
            // 
            // menuPanel
            // 
            this.menuPanel.Location = new System.Drawing.Point(20, 442);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(5);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(428, 322);
            this.menuPanel.TabIndex = 2;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel1.BackgroundImage")));
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(16, 15);
            this.gamePanel1.Margin = new System.Windows.Forms.Padding(5);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(1046, 419);
            this.gamePanel1.TabIndex = 0;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 767);
            this.Controls.Add(this.infoPanel2);
            this.Controls.Add(this.arrowPanel1);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.gamePanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Olympus the Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Close);
            this.ResumeLayout(false);

        }

        #endregion

        public GamePanel gamePanel1;
        private MenuPanel menuPanel;
        private ArrowPanel arrowPanel1;
        private InfoPanel infoPanel2;

    }
}