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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.weergaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistiekenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informatieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bedieningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.verbergAllesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.volledigeWeergaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herstartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMuziekSpeler = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speelpauzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herhalenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeDempenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMusicFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.infoBox1 = new Olympus_the_Game.View.InfoBox();
            this.arrowPanel1 = new Olympus_the_Game.View.ArrowPanel();
            this.gamePanel1 = new Olympus_the_Game.View.GamePanel();
            this.infoView1 = new Olympus_the_Game.View.InfoView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weergaveToolStripMenuItem,
            this.herstartenToolStripMenuItem,
            this.pauzeToolStripMenuItem,
            this.MenuMuziekSpeler});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // weergaveToolStripMenuItem
            // 
            this.weergaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statistiekenToolStripMenuItem,
            this.informatieToolStripMenuItem,
            this.bedieningToolStripMenuItem,
            this.aToolStripMenuItem,
            this.verbergAllesToolStripMenuItem,
            this.aToolStripMenuItem1,
            this.volledigeWeergaveToolStripMenuItem});
            this.weergaveToolStripMenuItem.Name = "weergaveToolStripMenuItem";
            this.weergaveToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.weergaveToolStripMenuItem.Text = "Weergave";
            // 
            // statistiekenToolStripMenuItem
            // 
            this.statistiekenToolStripMenuItem.CheckOnClick = true;
            this.statistiekenToolStripMenuItem.Name = "statistiekenToolStripMenuItem";
            this.statistiekenToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.statistiekenToolStripMenuItem.Text = "Statistieken";
            this.statistiekenToolStripMenuItem.Click += new System.EventHandler(this.changeLayoutButtonClicked);
            // 
            // informatieToolStripMenuItem
            // 
            this.informatieToolStripMenuItem.Checked = true;
            this.informatieToolStripMenuItem.CheckOnClick = true;
            this.informatieToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.informatieToolStripMenuItem.Name = "informatieToolStripMenuItem";
            this.informatieToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.informatieToolStripMenuItem.Text = "Informatie";
            this.informatieToolStripMenuItem.Click += new System.EventHandler(this.changeLayoutButtonClicked);
            // 
            // bedieningToolStripMenuItem
            // 
            this.bedieningToolStripMenuItem.Checked = true;
            this.bedieningToolStripMenuItem.CheckOnClick = true;
            this.bedieningToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bedieningToolStripMenuItem.Name = "bedieningToolStripMenuItem";
            this.bedieningToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.bedieningToolStripMenuItem.Text = "Bediening";
            this.bedieningToolStripMenuItem.Click += new System.EventHandler(this.changeLayoutButtonClicked);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(198, 6);
            // 
            // verbergAllesToolStripMenuItem
            // 
            this.verbergAllesToolStripMenuItem.CheckOnClick = true;
            this.verbergAllesToolStripMenuItem.Name = "verbergAllesToolStripMenuItem";
            this.verbergAllesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.verbergAllesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.verbergAllesToolStripMenuItem.Text = "Verberg alles";
            this.verbergAllesToolStripMenuItem.Click += new System.EventHandler(this.verbergAllesToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // volledigeWeergaveToolStripMenuItem
            // 
            this.volledigeWeergaveToolStripMenuItem.CheckOnClick = true;
            this.volledigeWeergaveToolStripMenuItem.Name = "volledigeWeergaveToolStripMenuItem";
            this.volledigeWeergaveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.volledigeWeergaveToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.volledigeWeergaveToolStripMenuItem.Text = "Volledige weergave";
            this.volledigeWeergaveToolStripMenuItem.Click += new System.EventHandler(this.changeLayoutButtonClicked);
            // 
            // herstartenToolStripMenuItem
            // 
            this.herstartenToolStripMenuItem.Name = "herstartenToolStripMenuItem";
            this.herstartenToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.herstartenToolStripMenuItem.Text = "Herstarten";
            this.herstartenToolStripMenuItem.Click += new System.EventHandler(this.herstartenToolStripMenuItem_Click);
            // 
            // pauzeToolStripMenuItem
            // 
            this.pauzeToolStripMenuItem.CheckOnClick = true;
            this.pauzeToolStripMenuItem.Name = "pauzeToolStripMenuItem";
            this.pauzeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauzeToolStripMenuItem.Text = "Pauze";
            this.pauzeToolStripMenuItem.Click += new System.EventHandler(this.pauzeToolStripMenuItem_Click);
            // 
            // MenuMuziekSpeler
            // 
            this.MenuMuziekSpeler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.speelpauzeToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.herhalenToolStripMenuItem,
            this.volumeDempenToolStripMenuItem});
            this.MenuMuziekSpeler.Name = "MenuMuziekSpeler";
            this.MenuMuziekSpeler.Size = new System.Drawing.Size(92, 20);
            this.MenuMuziekSpeler.Text = "Muziek Speler";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // speelpauzeToolStripMenuItem
            // 
            this.speelpauzeToolStripMenuItem.Checked = true;
            this.speelpauzeToolStripMenuItem.CheckOnClick = true;
            this.speelpauzeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.speelpauzeToolStripMenuItem.Name = "speelpauzeToolStripMenuItem";
            this.speelpauzeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.speelpauzeToolStripMenuItem.Text = "Speel/Pauze";
            this.speelpauzeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.speelpauzeToolStripMenuItem_CheckedChanged);
            this.speelpauzeToolStripMenuItem.Click += new System.EventHandler(this.speelpauzeToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // herhalenToolStripMenuItem
            // 
            this.herhalenToolStripMenuItem.Checked = true;
            this.herhalenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.herhalenToolStripMenuItem.Name = "herhalenToolStripMenuItem";
            this.herhalenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.herhalenToolStripMenuItem.Text = "Herhalen";
            this.herhalenToolStripMenuItem.CheckedChanged += new System.EventHandler(this.herhalenToolStripMenuItem_CheckedChanged);
            this.herhalenToolStripMenuItem.Click += new System.EventHandler(this.herhalenToolStripMenuItem_Click);
            // 
            // volumeDempenToolStripMenuItem
            // 
            this.volumeDempenToolStripMenuItem.Name = "volumeDempenToolStripMenuItem";
            this.volumeDempenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.volumeDempenToolStripMenuItem.Text = "Volume dempen";
            this.volumeDempenToolStripMenuItem.CheckedChanged += new System.EventHandler(this.volumeDempenToolStripMenuItem_CheckedChanged);
            this.volumeDempenToolStripMenuItem.Click += new System.EventHandler(this.volumeDempenToolStripMenuItem_Click);
            // 
            // OpenMusicFileDialog
            // 
            this.OpenMusicFileDialog.FileName = "OpenMusicFileDialog";
            this.OpenMusicFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenMusicFileDialog_FileOk);
            // 
            // infoBox1
            // 
            this.infoBox1.BackColor = System.Drawing.Color.Transparent;
            this.infoBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("infoBox1.BackgroundImage")));
            this.infoBox1.Location = new System.Drawing.Point(67, 522);
            this.infoBox1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.infoBox1.Name = "infoBox1";
            this.infoBox1.Size = new System.Drawing.Size(692, 207);
            this.infoBox1.TabIndex = 6;
            // 
            // arrowPanel1
            // 
            this.arrowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.arrowPanel1.Location = new System.Drawing.Point(835, 536);
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
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "GameScreen";
            this.Text = "Olympus The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public GamePanel gamePanel1;
        private ArrowPanel arrowPanel1;
        public InfoView infoView1;
        private System.Windows.Forms.Timer timer1;
        private InfoBox infoBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem weergaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistiekenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informatieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bedieningToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verbergAllesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem volledigeWeergaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuMuziekSpeler;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speelpauzeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenMusicFileDialog;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herhalenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeDempenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herstartenToolStripMenuItem;
    }
}