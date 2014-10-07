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
            Olympus_the_Game.PlayField playField1 = new Olympus_the_Game.PlayField();
            this.arrowPanel1 = new Olympus_the_Game.View.ArrowPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.customMenuBar1 = new Olympus_the_Game.View.MenuBar.CustomMenuBar();
            this.weergaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statestiekenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informatieSchermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pijltjestoetsenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.volledigeWeergaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoView1 = new Olympus_the_Game.View.InfoView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.infoBox1 = new Olympus_the_Game.View.InfoBox();
            this.customMenuBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.arrowPanel1.Location = new System.Drawing.Point(835, 536);
            this.arrowPanel1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.arrowPanel1.Name = "arrowPanel1";
            this.arrowPanel1.Size = new System.Drawing.Size(337, 207);
            this.arrowPanel1.TabIndex = 3;
            // 
            // gamePanel1
            // 
            this.gamePanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel1.BackgroundImage")));
            this.gamePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanel1.Location = new System.Drawing.Point(12, 41);
            this.gamePanel1.Name = "gamePanel1";
            playField1.Height = 500;
            playField1.Name = "Map_0";
            playField1.Width = 1000;
            this.gamePanel1.Playfield = playField1;
            this.gamePanel1.Size = new System.Drawing.Size(978, 489);
            this.gamePanel1.TabIndex = 2;
            // 
            // customMenuBar1
            // 
            this.customMenuBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weergaveToolStripMenuItem,
            this.pauzeToolStripMenuItem,
            this.verderToolStripMenuItem});
            this.customMenuBar1.Location = new System.Drawing.Point(0, 0);
            this.customMenuBar1.Name = "customMenuBar1";
            this.customMenuBar1.Size = new System.Drawing.Size(1264, 24);
            this.customMenuBar1.TabIndex = 4;
            this.customMenuBar1.Text = "customMenuBar1";
            // 
            // weergaveToolStripMenuItem
            // 
            this.weergaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statestiekenToolStripMenuItem,
            this.informatieSchermToolStripMenuItem,
            this.pijltjestoetsenToolStripMenuItem,
            this.toolStripSeparator1,
            this.volledigeWeergaveToolStripMenuItem});
            this.weergaveToolStripMenuItem.Name = "weergaveToolStripMenuItem";
            this.weergaveToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.weergaveToolStripMenuItem.Text = "Weergave";
            // 
            // statestiekenToolStripMenuItem
            // 
            this.statestiekenToolStripMenuItem.Checked = true;
            this.statestiekenToolStripMenuItem.CheckOnClick = true;
            this.statestiekenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statestiekenToolStripMenuItem.Name = "statestiekenToolStripMenuItem";
            this.statestiekenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.statestiekenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.statestiekenToolStripMenuItem.Text = "Statistieken";
            this.statestiekenToolStripMenuItem.Click += new System.EventHandler(this.statistiekenToolStripMenuItem_Click);
            // 
            // informatieSchermToolStripMenuItem
            // 
            this.informatieSchermToolStripMenuItem.Checked = true;
            this.informatieSchermToolStripMenuItem.CheckOnClick = true;
            this.informatieSchermToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.informatieSchermToolStripMenuItem.Name = "informatieSchermToolStripMenuItem";
            this.informatieSchermToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.informatieSchermToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.informatieSchermToolStripMenuItem.Text = "Informatiescherm";
            this.informatieSchermToolStripMenuItem.Click += new System.EventHandler(this.informatieSchermToolStripMenuItem_Click);
            // 
            // pijltjestoetsenToolStripMenuItem
            // 
            this.pijltjestoetsenToolStripMenuItem.Checked = true;
            this.pijltjestoetsenToolStripMenuItem.CheckOnClick = true;
            this.pijltjestoetsenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pijltjestoetsenToolStripMenuItem.Name = "pijltjestoetsenToolStripMenuItem";
            this.pijltjestoetsenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pijltjestoetsenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.pijltjestoetsenToolStripMenuItem.Text = "Pijltjestoetsen";
            this.pijltjestoetsenToolStripMenuItem.Click += new System.EventHandler(this.pijltjestoetsenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // volledigeWeergaveToolStripMenuItem
            // 
            this.volledigeWeergaveToolStripMenuItem.CheckOnClick = true;
            this.volledigeWeergaveToolStripMenuItem.Name = "volledigeWeergaveToolStripMenuItem";
            this.volledigeWeergaveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.volledigeWeergaveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.volledigeWeergaveToolStripMenuItem.Text = "Volledige weergave";
            this.volledigeWeergaveToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.volledigeWeergaveToolStripMenuItem.Click += new System.EventHandler(this.volledigeWeergaveToolStripMenuItem_Click);
            // 
            // pauzeToolStripMenuItem
            // 
            this.pauzeToolStripMenuItem.Name = "pauzeToolStripMenuItem";
            this.pauzeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauzeToolStripMenuItem.Text = "Pauze";
            this.pauzeToolStripMenuItem.Click += new System.EventHandler(this.pauzeToolStripMenuItem_Click);
            // 
            // verderToolStripMenuItem
            // 
            this.verderToolStripMenuItem.Name = "verderToolStripMenuItem";
            this.verderToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.verderToolStripMenuItem.Text = "Verder";
            this.verderToolStripMenuItem.Click += new System.EventHandler(this.verderToolStripMenuItem_Click);
            // 
            // infoView1
            // 
            this.infoView1.BackColor = System.Drawing.Color.Transparent;
            this.infoView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoView1.IsResized = false;
            this.infoView1.Location = new System.Drawing.Point(1008, 41);
            this.infoView1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.infoView1.Name = "infoView1";
            this.infoView1.Size = new System.Drawing.Size(240, 489);
            this.infoView1.TabIndex = 5;
            // 
            // infoBox1
            // 
            this.infoBox1.BackColor = System.Drawing.Color.Transparent;
            this.infoBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("infoBox1.BackgroundImage")));
            this.infoBox1.Location = new System.Drawing.Point(70, 567);
            this.infoBox1.MouseDownLocation = new System.Drawing.Point(0, 0);
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
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.customMenuBar1.ResumeLayout(false);
            this.customMenuBar1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem weergaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statestiekenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informatieSchermToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pijltjestoetsenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volledigeWeergaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pauzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verderToolStripMenuItem;
    }
}