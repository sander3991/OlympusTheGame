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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Player = new System.Windows.Forms.PictureBox();
            this.Creeper = new System.Windows.Forms.PictureBox();
            this.Spider = new System.Windows.Forms.PictureBox();
            this.TnT = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Creeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TnT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BackgroundImage = global::Olympus_the_Game.Properties.Resources.Background;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 540);
            this.panel1.TabIndex = 0;
            // 
            // Player
            // 
            this.Player.Image = global::Olympus_the_Game.Properties.Resources.player;
            this.Player.Location = new System.Drawing.Point(996, 12);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(70, 70);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 1;
            this.Player.TabStop = false;
            this.Player.Click += new System.EventHandler(this.Player_MouseDown);
            // 
            // Creeper
            // 
            this.Creeper.Image = global::Olympus_the_Game.Properties.Resources.creeper;
            this.Creeper.Location = new System.Drawing.Point(996, 88);
            this.Creeper.Name = "Creeper";
            this.Creeper.Size = new System.Drawing.Size(70, 70);
            this.Creeper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Creeper.TabIndex = 2;
            this.Creeper.TabStop = false;
            this.Creeper.Click += new System.EventHandler(this.Creeper_MouseDown);
            // 
            // Spider
            // 
            this.Spider.Image = global::Olympus_the_Game.Properties.Resources.spider;
            this.Spider.Location = new System.Drawing.Point(996, 164);
            this.Spider.Name = "Spider";
            this.Spider.Size = new System.Drawing.Size(70, 70);
            this.Spider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Spider.TabIndex = 3;
            this.Spider.TabStop = false;
            this.Spider.Click += new System.EventHandler(this.Spider_MouseDown);
            // 
            // TnT
            // 
            this.TnT.Image = global::Olympus_the_Game.Properties.Resources.tnt;
            this.TnT.Location = new System.Drawing.Point(996, 240);
            this.TnT.Name = "TnT";
            this.TnT.Size = new System.Drawing.Size(70, 70);
            this.TnT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TnT.TabIndex = 4;
            this.TnT.TabStop = false;
            this.TnT.Click += new System.EventHandler(this.TnT_MouseDown);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Olympus_the_Game.Properties.Resources.Background;
            this.pictureBox5.Location = new System.Drawing.Point(996, 316);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(70, 70);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Olympus_the_Game.Properties.Resources.Background;
            this.pictureBox6.Location = new System.Drawing.Point(996, 392);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(70, 70);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(1072, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(63, 70);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "Speler";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(1072, 88);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(63, 70);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "Creeper";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(1072, 164);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(63, 70);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "Spider";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(1072, 240);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.ReadOnly = true;
            this.richTextBox4.Size = new System.Drawing.Size(63, 70);
            this.richTextBox4.TabIndex = 10;
            this.richTextBox4.Text = "TnT";
            // 
            // richTextBox5
            // 
            this.richTextBox5.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox5.Location = new System.Drawing.Point(1072, 316);
            this.richTextBox5.Name = "richTextBox5";
            this.richTextBox5.ReadOnly = true;
            this.richTextBox5.Size = new System.Drawing.Size(63, 70);
            this.richTextBox5.TabIndex = 11;
            this.richTextBox5.Text = "Nog nader te bepalen";
            // 
            // richTextBox6
            // 
            this.richTextBox6.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox6.Location = new System.Drawing.Point(1072, 392);
            this.richTextBox6.Name = "richTextBox6";
            this.richTextBox6.ReadOnly = true;
            this.richTextBox6.Size = new System.Drawing.Size(63, 70);
            this.richTextBox6.TabIndex = 12;
            this.richTextBox6.Text = "Nog nader te bepalen";
            // 
            // richTextBox7
            // 
            this.richTextBox7.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox7.Location = new System.Drawing.Point(996, 494);
            this.richTextBox7.Name = "richTextBox7";
            this.richTextBox7.ReadOnly = true;
            this.richTextBox7.Size = new System.Drawing.Size(163, 58);
            this.richTextBox7.TabIndex = 13;
            this.richTextBox7.Text = "Versleep de entiteiten in het veld waar jij ze wilt hebben.";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 733);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.TnT);
            this.Controls.Add(this.Spider);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Creeper);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.panel1);
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Creeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Spider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TnT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.PictureBox Creeper;
        private System.Windows.Forms.PictureBox Spider;
        private System.Windows.Forms.PictureBox TnT;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.RichTextBox richTextBox7;
    }
}