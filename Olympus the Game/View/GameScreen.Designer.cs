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
            this.infoPanel1 = new Olympus_the_Game.View.InfoPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.arrowPanel1 = new Olympus_the_Game.View.ArrowPanel();
            this.SuspendLayout();
            // 
            // infoPanel1
            // 
            this.infoPanel1.Location = new System.Drawing.Point(15, 359);
            this.infoPanel1.Name = "infoPanel1";
            this.infoPanel1.Size = new System.Drawing.Size(313, 262);
            this.infoPanel1.TabIndex = 2;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel1.BackgroundImage")));
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(12, 12);
            this.gamePanel1.Name = "gamePanel1";
            this.gamePanel1.Size = new System.Drawing.Size(785, 341);
            this.gamePanel1.TabIndex = 0;
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.Location = new System.Drawing.Point(334, 364);
            this.arrowPanel1.Name = "arrowPanel1";
            this.arrowPanel1.Size = new System.Drawing.Size(337, 247);
            this.arrowPanel1.TabIndex = 3;
            this.arrowPanel1.Load += new System.EventHandler(this.arrowPanel1_Load);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 623);
            this.Controls.Add(this.arrowPanel1);
            this.Controls.Add(this.infoPanel1);
            this.Controls.Add(this.gamePanel1);
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Olympus the Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Close);
            this.ResumeLayout(false);

        }

        #endregion

        private GamePanel gamePanel1;
        private InfoPanel infoPanel1;
        private ArrowPanel arrowPanel1;

    }
}