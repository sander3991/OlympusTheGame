﻿namespace Olympus_the_Game.View
{
    partial class LevelDialog
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.LoadXMLfile = new System.Windows.Forms.Button();
            this.DungeonLevel = new System.Windows.Forms.Button();
            this.BeachLevel = new System.Windows.Forms.Button();
            this.HeavenLevel = new System.Windows.Forms.Button();
            this.HellLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(9, 10);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(298, 32);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Laad een van de standaard levels die meegeleverd zijn.";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(49, 79);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(245, 28);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "Laad zelf een (geëxporteerd) .xml bestand.";
            // 
            // LoadXMLfile
            // 
            this.LoadXMLfile.Location = new System.Drawing.Point(98, 111);
            this.LoadXMLfile.Margin = new System.Windows.Forms.Padding(2);
            this.LoadXMLfile.Name = "LoadXMLfile";
            this.LoadXMLfile.Size = new System.Drawing.Size(123, 19);
            this.LoadXMLfile.TabIndex = 2;
            this.LoadXMLfile.Text = "Laad .xml bestand";
            this.LoadXMLfile.UseVisualStyleBackColor = true;
            this.LoadXMLfile.Click += new System.EventHandler(this.LoadXMLfile_Click);
            // 
            // DungeonLevel
            // 
            this.DungeonLevel.Location = new System.Drawing.Point(11, 46);
            this.DungeonLevel.Margin = new System.Windows.Forms.Padding(2);
            this.DungeonLevel.Name = "DungeonLevel";
            this.DungeonLevel.Size = new System.Drawing.Size(71, 19);
            this.DungeonLevel.TabIndex = 3;
            this.DungeonLevel.Tag = "DUNGEON";
            this.DungeonLevel.Text = "Dungeon";
            this.DungeonLevel.UseVisualStyleBackColor = true;
            this.DungeonLevel.Click += new System.EventHandler(this.LevelSelect_Click);
            // 
            // BeachLevel
            // 
            this.BeachLevel.Location = new System.Drawing.Point(236, 46);
            this.BeachLevel.Margin = new System.Windows.Forms.Padding(2);
            this.BeachLevel.Name = "BeachLevel";
            this.BeachLevel.Size = new System.Drawing.Size(71, 19);
            this.BeachLevel.TabIndex = 4;
            this.BeachLevel.Tag = "BEACH";
            this.BeachLevel.Text = "Beach";
            this.BeachLevel.UseVisualStyleBackColor = true;
            this.BeachLevel.Click += new System.EventHandler(this.LevelSelect_Click);
            // 
            // HeavenLevel
            // 
            this.HeavenLevel.Location = new System.Drawing.Point(161, 46);
            this.HeavenLevel.Margin = new System.Windows.Forms.Padding(2);
            this.HeavenLevel.Name = "HeavenLevel";
            this.HeavenLevel.Size = new System.Drawing.Size(71, 19);
            this.HeavenLevel.TabIndex = 5;
            this.HeavenLevel.Tag = "HEAVEN";
            this.HeavenLevel.Text = "Heaven";
            this.HeavenLevel.UseVisualStyleBackColor = true;
            this.HeavenLevel.Click += new System.EventHandler(this.LevelSelect_Click);
            // 
            // HellLevel
            // 
            this.HellLevel.Location = new System.Drawing.Point(86, 46);
            this.HellLevel.Margin = new System.Windows.Forms.Padding(2);
            this.HellLevel.Name = "HellLevel";
            this.HellLevel.Size = new System.Drawing.Size(71, 19);
            this.HellLevel.TabIndex = 6;
            this.HellLevel.Tag = "HELL";
            this.HellLevel.Text = "Hell";
            this.HellLevel.UseVisualStyleBackColor = true;
            this.HellLevel.Click += new System.EventHandler(this.LevelSelect_Click);
            // 
            // LevelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 156);
            this.Controls.Add(this.HellLevel);
            this.Controls.Add(this.HeavenLevel);
            this.Controls.Add(this.BeachLevel);
            this.Controls.Add(this.DungeonLevel);
            this.Controls.Add(this.LoadXMLfile);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(100, 120);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LevelDialog";
            this.Text = "Kies een level";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button LoadXMLfile;
        private System.Windows.Forms.Button DungeonLevel;
        private System.Windows.Forms.Button BeachLevel;
        private System.Windows.Forms.Button HeavenLevel;
        private System.Windows.Forms.Button HellLevel;
    }
}