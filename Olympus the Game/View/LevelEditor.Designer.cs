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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.richTextBox5 = new System.Windows.Forms.RichTextBox();
            this.richTextBox6 = new System.Windows.Forms.RichTextBox();
            this.richTextBox7 = new System.Windows.Forms.RichTextBox();
            this.Player = new System.Windows.Forms.Panel();
            this.Creeper = new System.Windows.Forms.Panel();
            this.Spider = new System.Windows.Forms.Panel();
            this.Tnt = new System.Windows.Forms.Panel();
            this.TimeBomb = new System.Windows.Forms.Panel();
            this.Cake = new System.Windows.Forms.Panel();
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
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
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
            this.richTextBox5.Text = "TimeBomb";
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
            this.richTextBox6.Text = "Cake";
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
            // Player
            // 
            this.Player.AllowDrop = true;
            this.Player.BackgroundImage = global::Olympus_the_Game.Properties.Resources.player;
            this.Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player.Location = new System.Drawing.Point(996, 12);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(70, 70);
            this.Player.TabIndex = 14;
            this.Player.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Player_MouseDown);
            // 
            // Creeper
            // 
            this.Creeper.AllowDrop = true;
            this.Creeper.BackgroundImage = global::Olympus_the_Game.Properties.Resources.creeper;
            this.Creeper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Creeper.Location = new System.Drawing.Point(996, 88);
            this.Creeper.Name = "Creeper";
            this.Creeper.Size = new System.Drawing.Size(70, 70);
            this.Creeper.TabIndex = 15;
            this.Creeper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Creeper_MouseDown);
            // 
            // Spider
            // 
            this.Spider.AllowDrop = true;
            this.Spider.BackgroundImage = global::Olympus_the_Game.Properties.Resources.spider;
            this.Spider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Spider.Location = new System.Drawing.Point(996, 164);
            this.Spider.Name = "Spider";
            this.Spider.Size = new System.Drawing.Size(70, 70);
            this.Spider.TabIndex = 15;
            this.Spider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Spider_MouseDown);
            // 
            // Tnt
            // 
            this.Tnt.AllowDrop = true;
            this.Tnt.BackgroundImage = global::Olympus_the_Game.Properties.Resources.tnt;
            this.Tnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tnt.Location = new System.Drawing.Point(996, 240);
            this.Tnt.Name = "Tnt";
            this.Tnt.Size = new System.Drawing.Size(70, 70);
            this.Tnt.TabIndex = 15;
            this.Tnt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tnt_MouseDown);
            // 
            // TimeBomb
            // 
            this.TimeBomb.AllowDrop = true;
            this.TimeBomb.BackgroundImage = global::Olympus_the_Game.Properties.Resources.timebomb;
            this.TimeBomb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TimeBomb.Location = new System.Drawing.Point(996, 316);
            this.TimeBomb.Name = "TimeBomb";
            this.TimeBomb.Size = new System.Drawing.Size(70, 70);
            this.TimeBomb.TabIndex = 15;
            this.TimeBomb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TimeBomb_MouseDown);
            // 
            // Cake
            // 
            this.Cake.AllowDrop = true;
            this.Cake.BackgroundImage = global::Olympus_the_Game.Properties.Resources.cake;
            this.Cake.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cake.Location = new System.Drawing.Point(996, 392);
            this.Cake.Name = "Cake";
            this.Cake.Size = new System.Drawing.Size(70, 70);
            this.Cake.TabIndex = 15;
            this.Cake.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cake_MouseDown);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 733);
            this.Controls.Add(this.Cake);
            this.Controls.Add(this.TimeBomb);
            this.Controls.Add(this.Tnt);
            this.Controls.Add(this.Spider);
            this.Controls.Add(this.Creeper);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.richTextBox7);
            this.Controls.Add(this.richTextBox6);
            this.Controls.Add(this.richTextBox5);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.Panel Player;
        private System.Windows.Forms.Panel Creeper;
        private System.Windows.Forms.Panel Spider;
        private System.Windows.Forms.Panel Tnt;
        private System.Windows.Forms.Panel TimeBomb;
        private System.Windows.Forms.Panel Cake;
    }
}