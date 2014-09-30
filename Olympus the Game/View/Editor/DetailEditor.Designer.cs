namespace Olympus_the_Game.View.Editor
{
    partial class DetailEditor
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
            this.EntityImageLarge = new System.Windows.Forms.Panel();
            this.XLocationInput = new System.Windows.Forms.TextBox();
            this.EntityXLocation = new System.Windows.Forms.Label();
            this.EntityYLocation = new System.Windows.Forms.Label();
            this.EntitySpeed = new System.Windows.Forms.Label();
            this.ObjectTexture = new System.Windows.Forms.Label();
            this.YLocationInput = new System.Windows.Forms.TextBox();
            this.SpeedInput = new System.Windows.Forms.TextBox();
            this.TextureInput = new System.Windows.Forms.ComboBox();
            this.EntityUitleg = new System.Windows.Forms.RichTextBox();
            this.Splitter = new System.Windows.Forms.Panel();
            this.EntityNaamLabel = new System.Windows.Forms.Label();
            this.SpeelveldUitleg = new System.Windows.Forms.RichTextBox();
            this.SpeelveldLabel = new System.Windows.Forms.Label();
            this.TitelInput = new System.Windows.Forms.TextBox();
            this.GrootteYInput = new System.Windows.Forms.TextBox();
            this.SpeelveldTitelLabel = new System.Windows.Forms.Label();
            this.SpeelveldYLabel = new System.Windows.Forms.Label();
            this.SpeelveldXLabel = new System.Windows.Forms.Label();
            this.GrootteXInput = new System.Windows.Forms.TextBox();
            this.ToepassenSpeelveld = new System.Windows.Forms.Button();
            this.ToepassenEntity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EntityImageLarge
            // 
            this.EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.creeper;
            this.EntityImageLarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EntityImageLarge.Location = new System.Drawing.Point(399, 42);
            this.EntityImageLarge.Name = "EntityImageLarge";
            this.EntityImageLarge.Size = new System.Drawing.Size(125, 125);
            this.EntityImageLarge.TabIndex = 0;
            // 
            // XLocationInput
            // 
            this.XLocationInput.Location = new System.Drawing.Point(593, 48);
            this.XLocationInput.Name = "XLocationInput";
            this.XLocationInput.Size = new System.Drawing.Size(100, 20);
            this.XLocationInput.TabIndex = 1;
            // 
            // EntityXLocation
            // 
            this.EntityXLocation.AutoSize = true;
            this.EntityXLocation.Location = new System.Drawing.Point(562, 51);
            this.EntityXLocation.Name = "EntityXLocation";
            this.EntityXLocation.Size = new System.Drawing.Size(20, 13);
            this.EntityXLocation.TabIndex = 2;
            this.EntityXLocation.Text = "X: ";
            // 
            // EntityYLocation
            // 
            this.EntityYLocation.AutoSize = true;
            this.EntityYLocation.Location = new System.Drawing.Point(562, 81);
            this.EntityYLocation.Name = "EntityYLocation";
            this.EntityYLocation.Size = new System.Drawing.Size(20, 13);
            this.EntityYLocation.TabIndex = 3;
            this.EntityYLocation.Text = "Y: ";
            // 
            // EntitySpeed
            // 
            this.EntitySpeed.AutoSize = true;
            this.EntitySpeed.Location = new System.Drawing.Point(538, 113);
            this.EntitySpeed.Name = "EntitySpeed";
            this.EntitySpeed.Size = new System.Drawing.Size(44, 13);
            this.EntitySpeed.TabIndex = 4;
            this.EntitySpeed.Text = "Speed: ";
            // 
            // ObjectTexture
            // 
            this.ObjectTexture.AutoSize = true;
            this.ObjectTexture.Location = new System.Drawing.Point(538, 144);
            this.ObjectTexture.Name = "ObjectTexture";
            this.ObjectTexture.Size = new System.Drawing.Size(49, 13);
            this.ObjectTexture.TabIndex = 7;
            this.ObjectTexture.Text = "Texture: ";
            // 
            // YLocationInput
            // 
            this.YLocationInput.Location = new System.Drawing.Point(593, 78);
            this.YLocationInput.Name = "YLocationInput";
            this.YLocationInput.Size = new System.Drawing.Size(100, 20);
            this.YLocationInput.TabIndex = 8;
            // 
            // SpeedInput
            // 
            this.SpeedInput.Location = new System.Drawing.Point(593, 110);
            this.SpeedInput.Name = "SpeedInput";
            this.SpeedInput.Size = new System.Drawing.Size(100, 20);
            this.SpeedInput.TabIndex = 9;
            // 
            // TextureInput
            // 
            this.TextureInput.FormattingEnabled = true;
            this.TextureInput.Items.AddRange(new object[] {
            "Wood",
            "Cobblestone",
            "Bricks",
            "Gold"});
            this.TextureInput.Location = new System.Drawing.Point(593, 141);
            this.TextureInput.Name = "TextureInput";
            this.TextureInput.Size = new System.Drawing.Size(100, 21);
            this.TextureInput.TabIndex = 13;
            // 
            // EntityUitleg
            // 
            this.EntityUitleg.BackColor = System.Drawing.SystemColors.Menu;
            this.EntityUitleg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntityUitleg.Location = new System.Drawing.Point(712, 48);
            this.EntityUitleg.Name = "EntityUitleg";
            this.EntityUitleg.Size = new System.Drawing.Size(174, 119);
            this.EntityUitleg.TabIndex = 14;
            this.EntityUitleg.Text = "Pas meerdere waardes aan van de geselecteerde entity door middel van deze DetailE" +
    "ditor.";
            // 
            // Splitter
            // 
            this.Splitter.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Splitter.BackgroundImage = global::Olympus_the_Game.Properties.Resources.dirt;
            this.Splitter.Location = new System.Drawing.Point(367, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(20, 179);
            this.Splitter.TabIndex = 15;
            // 
            // EntityNaamLabel
            // 
            this.EntityNaamLabel.AutoSize = true;
            this.EntityNaamLabel.Location = new System.Drawing.Point(438, 11);
            this.EntityNaamLabel.Name = "EntityNaamLabel";
            this.EntityNaamLabel.Size = new System.Drawing.Size(50, 13);
            this.EntityNaamLabel.TabIndex = 16;
            this.EntityNaamLabel.Text = "Creeper1";
            // 
            // SpeelveldUitleg
            // 
            this.SpeelveldUitleg.BackColor = System.Drawing.SystemColors.Menu;
            this.SpeelveldUitleg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SpeelveldUitleg.Location = new System.Drawing.Point(197, 48);
            this.SpeelveldUitleg.Name = "SpeelveldUitleg";
            this.SpeelveldUitleg.Size = new System.Drawing.Size(164, 41);
            this.SpeelveldUitleg.TabIndex = 17;
            this.SpeelveldUitleg.Text = "Pas waardes en eigenschappen van het speelveld aan.";
            // 
            // SpeelveldLabel
            // 
            this.SpeelveldLabel.AutoSize = true;
            this.SpeelveldLabel.Location = new System.Drawing.Point(89, 16);
            this.SpeelveldLabel.Name = "SpeelveldLabel";
            this.SpeelveldLabel.Size = new System.Drawing.Size(54, 13);
            this.SpeelveldLabel.TabIndex = 18;
            this.SpeelveldLabel.Text = "Speelveld";
            // 
            // TitelInput
            // 
            this.TitelInput.Location = new System.Drawing.Point(62, 113);
            this.TitelInput.Name = "TitelInput";
            this.TitelInput.Size = new System.Drawing.Size(100, 20);
            this.TitelInput.TabIndex = 24;
            // 
            // GrootteYInput
            // 
            this.GrootteYInput.Location = new System.Drawing.Point(62, 81);
            this.GrootteYInput.Name = "GrootteYInput";
            this.GrootteYInput.Size = new System.Drawing.Size(100, 20);
            this.GrootteYInput.TabIndex = 23;
            // 
            // SpeelveldTitelLabel
            // 
            this.SpeelveldTitelLabel.AutoSize = true;
            this.SpeelveldTitelLabel.Location = new System.Drawing.Point(26, 117);
            this.SpeelveldTitelLabel.Name = "SpeelveldTitelLabel";
            this.SpeelveldTitelLabel.Size = new System.Drawing.Size(30, 13);
            this.SpeelveldTitelLabel.TabIndex = 22;
            this.SpeelveldTitelLabel.Text = "Titel:";
            // 
            // SpeelveldYLabel
            // 
            this.SpeelveldYLabel.AutoSize = true;
            this.SpeelveldYLabel.Location = new System.Drawing.Point(3, 84);
            this.SpeelveldYLabel.Name = "SpeelveldYLabel";
            this.SpeelveldYLabel.Size = new System.Drawing.Size(58, 13);
            this.SpeelveldYLabel.TabIndex = 21;
            this.SpeelveldYLabel.Text = "Grootte Y: ";
            // 
            // SpeelveldXLabel
            // 
            this.SpeelveldXLabel.AutoSize = true;
            this.SpeelveldXLabel.Location = new System.Drawing.Point(3, 55);
            this.SpeelveldXLabel.Name = "SpeelveldXLabel";
            this.SpeelveldXLabel.Size = new System.Drawing.Size(58, 13);
            this.SpeelveldXLabel.TabIndex = 20;
            this.SpeelveldXLabel.Text = "Grootte X: ";
            // 
            // GrootteXInput
            // 
            this.GrootteXInput.Location = new System.Drawing.Point(62, 51);
            this.GrootteXInput.Name = "GrootteXInput";
            this.GrootteXInput.Size = new System.Drawing.Size(100, 20);
            this.GrootteXInput.TabIndex = 19;
            // 
            // ToepassenSpeelveld
            // 
            this.ToepassenSpeelveld.Location = new System.Drawing.Point(272, 144);
            this.ToepassenSpeelveld.Name = "ToepassenSpeelveld";
            this.ToepassenSpeelveld.Size = new System.Drawing.Size(75, 23);
            this.ToepassenSpeelveld.TabIndex = 25;
            this.ToepassenSpeelveld.Text = "Toepassen";
            this.ToepassenSpeelveld.UseVisualStyleBackColor = true;
            // 
            // ToepassenEntity
            // 
            this.ToepassenEntity.Location = new System.Drawing.Point(801, 144);
            this.ToepassenEntity.Name = "ToepassenEntity";
            this.ToepassenEntity.Size = new System.Drawing.Size(75, 23);
            this.ToepassenEntity.TabIndex = 26;
            this.ToepassenEntity.Text = "Toepassen";
            this.ToepassenEntity.UseVisualStyleBackColor = true;
            // 
            // DetailEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToepassenEntity);
            this.Controls.Add(this.ToepassenSpeelveld);
            this.Controls.Add(this.TitelInput);
            this.Controls.Add(this.GrootteYInput);
            this.Controls.Add(this.SpeelveldTitelLabel);
            this.Controls.Add(this.SpeelveldYLabel);
            this.Controls.Add(this.SpeelveldXLabel);
            this.Controls.Add(this.GrootteXInput);
            this.Controls.Add(this.SpeelveldLabel);
            this.Controls.Add(this.SpeelveldUitleg);
            this.Controls.Add(this.EntityNaamLabel);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.EntityUitleg);
            this.Controls.Add(this.TextureInput);
            this.Controls.Add(this.SpeedInput);
            this.Controls.Add(this.YLocationInput);
            this.Controls.Add(this.ObjectTexture);
            this.Controls.Add(this.EntitySpeed);
            this.Controls.Add(this.EntityYLocation);
            this.Controls.Add(this.EntityXLocation);
            this.Controls.Add(this.XLocationInput);
            this.Controls.Add(this.EntityImageLarge);
            this.Name = "DetailEditor";
            this.Size = new System.Drawing.Size(894, 179);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel EntityImageLarge;
        private System.Windows.Forms.TextBox XLocationInput;
        private System.Windows.Forms.Label EntityXLocation;
        private System.Windows.Forms.Label EntityYLocation;
        private System.Windows.Forms.Label EntitySpeed;
        private System.Windows.Forms.Label ObjectTexture;
        private System.Windows.Forms.TextBox YLocationInput;
        private System.Windows.Forms.TextBox SpeedInput;
        private System.Windows.Forms.ComboBox TextureInput;
        private System.Windows.Forms.RichTextBox EntityUitleg;
        private System.Windows.Forms.Panel Splitter;
        private System.Windows.Forms.Label EntityNaamLabel;
        private System.Windows.Forms.RichTextBox SpeelveldUitleg;
        private System.Windows.Forms.Label SpeelveldLabel;
        private System.Windows.Forms.TextBox TitelInput;
        private System.Windows.Forms.TextBox GrootteYInput;
        private System.Windows.Forms.Label SpeelveldTitelLabel;
        private System.Windows.Forms.Label SpeelveldYLabel;
        private System.Windows.Forms.Label SpeelveldXLabel;
        private System.Windows.Forms.TextBox GrootteXInput;
        private System.Windows.Forms.Button ToepassenSpeelveld;
        private System.Windows.Forms.Button ToepassenEntity;
    }
}
