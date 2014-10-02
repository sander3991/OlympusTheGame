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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            Olympus_the_Game.PlayField playField2 = new Olympus_the_Game.PlayField();
            this.arrowPanel1 = new Olympus_the_Game.View.ArrowPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.customMenuBar1 = new Olympus_the_Game.View.MenuBar.CustomMenuBar();
            this.infoView1 = new Olympus_the_Game.View.InfoView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.infoBox1 = new Olympus_the_Game.View.InfoBox();
            this.SuspendLayout();
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.arrowPanel1.Location = new System.Drawing.Point(889, 536);
            this.arrowPanel1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.arrowPanel1.Name = "arrowPanel1";
            this.arrowPanel1.Size = new System.Drawing.Size(337, 247);
            this.arrowPanel1.TabIndex = 3;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel1.BackgroundImage")));
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(12, 41);
            this.gamePanel1.Name = "gamePanel1";
            playField2.Name = "Map_0";
            this.gamePanel1.Playfield = playField2;
            this.gamePanel1.Size = new System.Drawing.Size(978, 489);
            this.gamePanel1.TabIndex = 2;
            // 
            // customMenuBar1
            // 
            this.customMenuBar1.Location = new System.Drawing.Point(0, 0);
            this.customMenuBar1.Name = "customMenuBar1";
            this.customMenuBar1.Size = new System.Drawing.Size(1264, 24);
            this.customMenuBar1.TabIndex = 4;
            this.customMenuBar1.Text = "customMenuBar1";
            // 
            // infoView1
            // 
            this.infoView1.Entitys = null;
            this.infoView1.IsResized = false;
            this.infoView1.Location = new System.Drawing.Point(1008, 41);
            this.infoView1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.infoView1.Name = "infoView1";
            this.infoView1.Size = new System.Drawing.Size(240, 489);
            this.infoView1.TabIndex = 5;
            // 
            // infoBox1
            // 
            this.infoBox1.Location = new System.Drawing.Point(12, 536);
            this.infoBox1.Name = "infoBox1";
            this.infoBox1.Size = new System.Drawing.Size(692, 162);
            this.infoBox1.TabIndex = 6;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Olympus_the_Game.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(1264, 741);
            this.Controls.Add(this.infoBox1);
            this.Controls.Add(this.arrowPanel1);
            this.Controls.Add(this.gamePanel1);
            this.Controls.Add(this.infoView1);
            this.Controls.Add(this.customMenuBar1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.customMenuBar1;
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Olympus The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GamePanel gamePanel1;
        private ArrowPanel arrowPanel1;
        private MenuBar.CustomMenuBar customMenuBar1;
        public InfoView infoView1;
        private System.Windows.Forms.Timer timer1;
        private InfoBox infoBox1;
    }
}