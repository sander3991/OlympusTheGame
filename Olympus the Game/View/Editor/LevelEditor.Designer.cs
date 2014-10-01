namespace Olympus_the_Game.View
{
    partial class LevelEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.Creeper = new System.Windows.Forms.Panel();
            this.Tnt = new System.Windows.Forms.Panel();
            this.TimeBomb = new System.Windows.Forms.Panel();
            this.Cake = new System.Windows.Forms.Panel();
            this.Home = new System.Windows.Forms.Panel();
            this.richTextBox8 = new System.Windows.Forms.RichTextBox();
            this.Obstakel = new System.Windows.Forms.Panel();
            this.richTextBox9 = new System.Windows.Forms.RichTextBox();
            this.Spider = new System.Windows.Forms.Panel();
            this.Menubar = new System.Windows.Forms.MenuStrip();
            this.Opslaan = new System.Windows.Forms.ToolStripMenuItem();
            this.Inladen = new System.Windows.Forms.ToolStripMenuItem();
            this.Afsluiten = new System.Windows.Forms.ToolStripMenuItem();
            this.speelveldEditor1 = new Olympus_the_Game.View.SpeelveldEditor();
            this.entityEditor1 = new Olympus_the_Game.View.EntityEditor();
            this.gamePanelEditor = new Olympus_the_Game.View.GamePanel();
            this.Menubar.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(1003, 92);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(63, 50);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "Creeper";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(1003, 148);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(63, 50);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "Spider";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(1003, 204);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(63, 50);
            this.richTextBox4.TabIndex = 10;
            this.richTextBox4.Text = "TnT";
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Location = new System.Drawing.Point(1003, 260);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.Size = new System.Drawing.Size(63, 50);
            this.richTextBox5.TabIndex = 11;
            this.richTextBox5.Text = "TimeBomb";
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Location = new System.Drawing.Point(1003, 316);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ReadOnly = true;
            this.richTextBox6.Size = new System.Drawing.Size(63, 50);
            this.richTextBox6.TabIndex = 12;
            this.richTextBox6.Text = "Cake";
            // 
            // richTextBox7
            // 
            this.richTextBox7.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox7.Location = new System.Drawing.Point(935, 498);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.ReadOnly = true;
            this.richTextBox7.Size = new System.Drawing.Size(131, 58);
            this.richTextBox7.TabIndex = 13;
            this.richTextBox7.Text = "Versleep de entiteiten in het veld waar jij ze wilt hebben.";
            // 
            // Creeper
            // 
            this.Creeper.AllowDrop = true;
            this.Creeper.BackgroundImage = global::Olympus_the_Game.Properties.Resources.creeper;
            this.Creeper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Creeper.Location = new System.Drawing.Point(935, 92);
            this.Creeper.Name = "Creeper";
            this.Creeper.Size = new System.Drawing.Size(50, 50);
            this.Creeper.TabIndex = 15;
            this.Creeper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Creeper_MouseDown);
            // 
            // Tnt
            // 
            this.Tnt.AllowDrop = true;
            this.Tnt.BackgroundImage = global::Olympus_the_Game.Properties.Resources.tnt;
            this.Tnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tnt.Location = new System.Drawing.Point(935, 204);
            this.Tnt.Name = "Tnt";
            this.Tnt.Size = new System.Drawing.Size(50, 50);
            this.Tnt.TabIndex = 17;
            this.Tnt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tnt_MouseDown);
            // 
            // TimeBomb
            // 
            this.TimeBomb.AllowDrop = true;
            this.TimeBomb.BackgroundImage = global::Olympus_the_Game.Properties.Resources.timebomb;
            this.TimeBomb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TimeBomb.Location = new System.Drawing.Point(935, 260);
            this.TimeBomb.Name = "TimeBomb";
            this.TimeBomb.Size = new System.Drawing.Size(50, 50);
            this.TimeBomb.TabIndex = 18;
            this.TimeBomb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeBomb_MouseDown);
            // 
            // Cake
            // 
            this.Cake.AllowDrop = true;
            this.Cake.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cake;
            this.Cake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cake.Location = new System.Drawing.Point(935, 316);
            this.Cake.Name = "Cake";
            this.Cake.Size = new System.Drawing.Size(50, 50);
            this.Cake.TabIndex = 19;
            this.Cake.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cake_MouseDown);
            // 
            // Home
            // 
            this.Home.AllowDrop = true;
            this.Home.BackgroundImage = global::Olympus_the_Game.Properties.Resources.huis;
            this.Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Home.Location = new System.Drawing.Point(935, 372);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(50, 50);
            this.Home.TabIndex = 20;
            this.Home.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Home_MouseDown);
            // 
            // richTextBox8
            // 
            this.richTextBox8.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox8.Location = new System.Drawing.Point(1003, 372);
            this.richTextBox8.Name = "richTextBox8";
            this.richTextBox8.ReadOnly = true;
            this.richTextBox8.Size = new System.Drawing.Size(63, 50);
            this.richTextBox8.TabIndex = 21;
            this.richTextBox8.Text = "Home";
            // 
            // Obstakel
            // 
            this.Obstakel.AllowDrop = true;
            this.Obstakel.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cobble;
            this.Obstakel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Obstakel.Location = new System.Drawing.Point(935, 428);
            this.Obstakel.Name = "Obstakel";
            this.Obstakel.Size = new System.Drawing.Size(50, 50);
            this.Obstakel.TabIndex = 22;
            this.Obstakel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Obstakel_MouseDown);
            // 
            // richTextBox9
            // 
            this.richTextBox9.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox9.Location = new System.Drawing.Point(1003, 428);
            this.richTextBox9.Name = "richTextBox9";
            this.richTextBox9.ReadOnly = true;
            this.richTextBox9.Size = new System.Drawing.Size(63, 50);
            this.richTextBox9.TabIndex = 23;
            this.richTextBox9.Text = "Obstakel";
            // 
            // Spider
            // 
            this.Spider.AllowDrop = true;
            this.Spider.BackgroundImage = global::Olympus_the_Game.Properties.Resources.spider;
            this.Spider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Spider.Location = new System.Drawing.Point(935, 148);
            this.Spider.Name = "Spider";
            this.Spider.Size = new System.Drawing.Size(50, 50);
            this.Spider.TabIndex = 18;
            this.Spider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Spider_MouseDown);
            // 
            // Menubar
            // 
            this.Menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opslaan,
            this.Inladen,
            this.Afsluiten});
            this.Menubar.Location = new System.Drawing.Point(0, 0);
            this.Menubar.Name = "Menubar";
            this.Menubar.Size = new System.Drawing.Size(1084, 24);
            this.Menubar.TabIndex = 24;
            this.Menubar.Text = "menuStrip1";
            // 
            // Opslaan
            // 
            this.Opslaan.Name = "Opslaan";
            this.Opslaan.Size = new System.Drawing.Size(104, 20);
            this.Opslaan.Text = "Opslaan als .xml";
            this.Opslaan.Click += new System.EventHandler(this.Opslaan_Click);
            // 
            // Inladen
            // 
            this.Inladen.Name = "Inladen";
            this.Inladen.Size = new System.Drawing.Size(128, 20);
            this.Inladen.Text = ".xml bestand inladen";
            this.Inladen.Click += new System.EventHandler(this.Inladen_Click);
            // 
            // Afsluiten
            // 
            this.Afsluiten.Name = "Afsluiten";
            this.Afsluiten.Size = new System.Drawing.Size(55, 20);
            this.Afsluiten.Text = "Sluit af";
            this.Afsluiten.Click += new System.EventHandler(this.Afsluiten_Click);
            // 
            // speelveldEditor1
            // 
            this.speelveldEditor1.Location = new System.Drawing.Point(12, 498);
            this.speelveldEditor1.Name = "speelveldEditor1";
            this.speelveldEditor1.Size = new System.Drawing.Size(368, 182);
            this.speelveldEditor1.TabIndex = 19;
            // 
            // entityEditor1
            // 
            this.entityEditor1.Location = new System.Drawing.Point(399, 498);
            this.entityEditor1.Name = "entityEditor1";
            this.entityEditor1.Size = new System.Drawing.Size(517, 182);
            this.entityEditor1.TabIndex = 18;
            // 
            // gamePanelEditor
            // 
            this.gamePanelEditor.AllowDrop = true;
            this.gamePanelEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanelEditor.BackgroundImage")));
            this.gamePanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanelEditor.Location = new System.Drawing.Point(12, 36);
            this.gamePanelEditor.Name = "gamePanelEditor";
            this.gamePanelEditor.Size = new System.Drawing.Size(904, 452);
            this.gamePanelEditor.TabIndex = 16;
            this.gamePanelEditor.DragDrop += new System.Windows.Forms.DragEventHandler(this.drag_drop);
            this.gamePanelEditor.DragEnter += new System.Windows.Forms.DragEventHandler(this.enter);
            this.gamePanelEditor.DoubleClick += new System.EventHandler(this.Mouse_DoubleClick);
            this.gamePanelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Clicked);
            this.gamePanelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Start_InPanel_Drag);
            this.gamePanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InPanel_Mouse_Move);
            this.gamePanelEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stop_InPanel_Drag);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Olympus_the_Game.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(1084, 696);
            this.Controls.Add(this.Spider);
            this.Controls.Add(this.speelveldEditor1);
            this.Controls.Add(this.entityEditor1);
            this.Controls.Add(this.Obstakel);
            this.Controls.Add(this.richTextBox9);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.richTextBox8);
            this.Controls.Add(this.gamePanelEditor);
            this.Controls.Add(this.Cake);
            this.Controls.Add(this.TimeBomb);
            this.Controls.Add(this.Tnt);
            this.Controls.Add(this.Creeper);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.Menubar);
            this.MainMenuStrip = this.Menubar;
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.drag_drop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.enter);
            this.Menubar.ResumeLayout(false);
            this.Menubar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.Panel Creeper;
        private System.Windows.Forms.Panel Spider;
        private System.Windows.Forms.Panel Tnt;
        private System.Windows.Forms.Panel TimeBomb;
        private System.Windows.Forms.Panel Cake;
        private GamePanel gamePanelEditor;
        private System.Windows.Forms.Panel Home;
        private System.Windows.Forms.RichTextBox richTextBox8;
        private System.Windows.Forms.Panel Obstakel;
        private System.Windows.Forms.RichTextBox richTextBox9;
        private EntityEditor entityEditor1;
        private SpeelveldEditor speelveldEditor1;
        private System.Windows.Forms.MenuStrip Menubar;
        private System.Windows.Forms.ToolStripMenuItem Opslaan;
        private System.Windows.Forms.ToolStripMenuItem Inladen;
        private System.Windows.Forms.ToolStripMenuItem Afsluiten;

    }
}