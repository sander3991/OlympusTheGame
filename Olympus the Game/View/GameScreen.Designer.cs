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
            this.arrowPanel1 = new Olympus_the_Game.View.ArrowPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.menuPanel1 = new Olympus_the_Game.View.MenuPanel();
            this.infoPanel1 = new Olympus_the_Game.View.InfoPanel();
            this.SuspendLayout();
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.Location = new System.Drawing.Point(588, 560);
            this.arrowPanel1.Name = "arrowPanel1";
            this.arrowPanel1.Size = new System.Drawing.Size(337, 247);
            this.arrowPanel1.TabIndex = 3;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel1.BackgroundImage")));
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(12, 11);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(978, 489);
            this.gamePanel1.TabIndex = 2;
            // 
            // menuPanel1
            // 
            this.menuPanel1.Location = new System.Drawing.Point(931, 557);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(321, 250);
            this.menuPanel1.TabIndex = 1;
            // 
            // infoPanel1
            // 
            this.infoPanel1.Location = new System.Drawing.Point(995, 11);
            this.infoPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.infoPanel1.Name = "infoPanel1";
            this.infoPanel1.Size = new System.Drawing.Size(258, 541);
            this.infoPanel1.TabIndex = 0;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.arrowPanel1);
            this.Controls.Add(this.gamePanel1);
            this.Controls.Add(this.menuPanel1);
            this.Controls.Add(this.infoPanel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Olympus The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private InfoPanel infoPanel1;
        private MenuPanel menuPanel1;
        public GamePanel gamePanel1;
        private ArrowPanel arrowPanel1;
    }
}