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
            this.infoPanel1 = new Olympus_the_Game.View.InfoPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.customMenuBar1 = new Olympus_the_Game.View.MenuBar.CustomMenuBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.X = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Y = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.arrowPanel1.Location = new System.Drawing.Point(915, 602);
            this.arrowPanel1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.arrowPanel1.Name = "arrowPanel1";
            this.arrowPanel1.Size = new System.Drawing.Size(337, 247);
            this.arrowPanel1.TabIndex = 3;
            // 
            // infoPanel1
            // 
            this.infoPanel1.BackColor = System.Drawing.Color.Transparent;
            this.infoPanel1.Location = new System.Drawing.Point(517, 443);
            this.infoPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.infoPanel1.Name = "infoPanel1";
            this.infoPanel1.Size = new System.Drawing.Size(258, 541);
            this.infoPanel1.TabIndex = 0;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel1.BackgroundImage")));
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(12, 41);
            this.gamePanel1.Name = "gamePanel1";
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.X,
            this.Y,
            this.Speed});
            this.listView1.Location = new System.Drawing.Point(996, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(251, 489);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Naam";
            // 
            // X
            // 
            this.X.Text = "X";
            // 
            // Y
            // 
            this.Y.Text = "Y";
            // 
            // Speed
            // 
            this.Speed.Text = "Snelheid";
            this.Speed.Width = 111;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Olympus_the_Game.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(1264, 861);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.arrowPanel1);
            this.Controls.Add(this.gamePanel1);
            this.Controls.Add(this.infoPanel1);
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

        private InfoPanel infoPanel1;
        public GamePanel gamePanel1;
        private ArrowPanel arrowPanel1;
        private MenuBar.CustomMenuBar customMenuBar1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader X;
        private System.Windows.Forms.ColumnHeader Y;
        private System.Windows.Forms.ColumnHeader Speed;
    }
}