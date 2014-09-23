namespace Olympus_the_Game.View
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.DungeonLevel = new System.Windows.Forms.Button();
            this.BeachLevel = new System.Windows.Forms.Button();
            this.HellLevel = new System.Windows.Forms.Button();
            this.CloudsLevel = new System.Windows.Forms.Button();
            this.KiesLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(404, 43);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Kies uit een van de volgende levels die standaard worden meegeleverd.";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(3, 119);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(404, 43);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "Laad zelf een level uit een (geëxporteerd) .xml bestand.";
            // 
            // DungeonLevel
            // 
            this.DungeonLevel.Location = new System.Drawing.Point(3, 52);
            this.DungeonLevel.Name = "DungeonLevel";
            this.DungeonLevel.Size = new System.Drawing.Size(75, 23);
            this.DungeonLevel.TabIndex = 2;
            this.DungeonLevel.Text = "Dungeon";
            this.DungeonLevel.UseVisualStyleBackColor = true;
            // 
            // BeachLevel
            // 
            this.BeachLevel.Location = new System.Drawing.Point(84, 52);
            this.BeachLevel.Name = "BeachLevel";
            this.BeachLevel.Size = new System.Drawing.Size(75, 23);
            this.BeachLevel.TabIndex = 3;
            this.BeachLevel.Text = "Beach";
            this.BeachLevel.UseVisualStyleBackColor = true;
            // 
            // HellLevel
            // 
            this.HellLevel.Location = new System.Drawing.Point(165, 52);
            this.HellLevel.Name = "HellLevel";
            this.HellLevel.Size = new System.Drawing.Size(75, 23);
            this.HellLevel.TabIndex = 4;
            this.HellLevel.Text = "Hell";
            this.HellLevel.UseVisualStyleBackColor = true;
            // 
            // CloudsLevel
            // 
            this.CloudsLevel.Location = new System.Drawing.Point(246, 52);
            this.CloudsLevel.Name = "CloudsLevel";
            this.CloudsLevel.Size = new System.Drawing.Size(75, 23);
            this.CloudsLevel.TabIndex = 5;
            this.CloudsLevel.Text = "Clouds";
            this.CloudsLevel.UseVisualStyleBackColor = true;
            // 
            // KiesLevel
            // 
            this.KiesLevel.Location = new System.Drawing.Point(106, 154);
            this.KiesLevel.Name = "KiesLevel";
            this.KiesLevel.Size = new System.Drawing.Size(116, 23);
            this.KiesLevel.TabIndex = 6;
            this.KiesLevel.Text = "Laad .xml";
            this.KiesLevel.UseVisualStyleBackColor = true;
            // 
            // LevelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KiesLevel);
            this.Controls.Add(this.CloudsLevel);
            this.Controls.Add(this.HellLevel);
            this.Controls.Add(this.BeachLevel);
            this.Controls.Add(this.DungeonLevel);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "LevelDialog";
            this.Size = new System.Drawing.Size(359, 228);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button DungeonLevel;
        private System.Windows.Forms.Button BeachLevel;
        private System.Windows.Forms.Button HellLevel;
        private System.Windows.Forms.Button CloudsLevel;
        private System.Windows.Forms.Button KiesLevel;
    }
}
