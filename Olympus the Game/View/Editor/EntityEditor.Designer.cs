namespace Olympus_the_Game.View
{
    partial class EntityEditor
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
            this.ToepassenEntity = new System.Windows.Forms.Button();
            this.EntityNaamLabel = new System.Windows.Forms.Label();
            this.EntityUitleg = new System.Windows.Forms.RichTextBox();
            this.TextureInput = new System.Windows.Forms.ComboBox();
            this.SpeedInput = new System.Windows.Forms.TextBox();
            this.YLocationInput = new System.Windows.Forms.TextBox();
            this.ObjectTexture = new System.Windows.Forms.Label();
            this.EntitySpeed = new System.Windows.Forms.Label();
            this.EntityYLocation = new System.Windows.Forms.Label();
            this.EntityXLocation = new System.Windows.Forms.Label();
            this.XLocationInput = new System.Windows.Forms.TextBox();
            this.EntityImageLarge = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ToepassenEntity
            // 
            this.ToepassenEntity.Location = new System.Drawing.Point(411, 146);
            this.ToepassenEntity.Name = "ToepassenEntity";
            this.ToepassenEntity.Size = new System.Drawing.Size(75, 23);
            this.ToepassenEntity.TabIndex = 38;
            this.ToepassenEntity.Text = "Toepassen";
            this.ToepassenEntity.UseVisualStyleBackColor = true;
            // 
            // EntityNaamLabel
            // 
            this.EntityNaamLabel.AutoSize = true;
            this.EntityNaamLabel.Location = new System.Drawing.Point(48, 13);
            this.EntityNaamLabel.Name = "EntityNaamLabel";
            this.EntityNaamLabel.Size = new System.Drawing.Size(50, 13);
            this.EntityNaamLabel.TabIndex = 37;
            this.EntityNaamLabel.Text = "Creeper1";
            // 
            // EntityUitleg
            // 
            this.EntityUitleg.BackColor = System.Drawing.SystemColors.Menu;
            this.EntityUitleg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntityUitleg.Location = new System.Drawing.Point(322, 50);
            this.EntityUitleg.Name = "EntityUitleg";
            this.EntityUitleg.Size = new System.Drawing.Size(174, 119);
            this.EntityUitleg.TabIndex = 36;
            this.EntityUitleg.Text = "Pas meerdere waardes aan van de geselecteerde entity door middel van deze DetailE" +
    "ditor.";
            // 
            // TextureInput
            // 
            this.TextureInput.FormattingEnabled = true;
            this.TextureInput.Items.AddRange(new object[] {
            "Wood",
            "Cobblestone",
            "Bricks",
            "Gold"});
            this.TextureInput.Location = new System.Drawing.Point(203, 143);
            this.TextureInput.Name = "TextureInput";
            this.TextureInput.Size = new System.Drawing.Size(100, 21);
            this.TextureInput.TabIndex = 35;
            // 
            // SpeedInput
            // 
            this.SpeedInput.Location = new System.Drawing.Point(203, 112);
            this.SpeedInput.Name = "SpeedInput";
            this.SpeedInput.Size = new System.Drawing.Size(100, 20);
            this.SpeedInput.TabIndex = 34;
            // 
            // YLocationInput
            // 
            this.YLocationInput.Location = new System.Drawing.Point(203, 80);
            this.YLocationInput.Name = "YLocationInput";
            this.YLocationInput.Size = new System.Drawing.Size(100, 20);
            this.YLocationInput.TabIndex = 33;
            // 
            // ObjectTexture
            // 
            this.ObjectTexture.AutoSize = true;
            this.ObjectTexture.Location = new System.Drawing.Point(148, 146);
            this.ObjectTexture.Name = "ObjectTexture";
            this.ObjectTexture.Size = new System.Drawing.Size(49, 13);
            this.ObjectTexture.TabIndex = 32;
            this.ObjectTexture.Text = "Texture: ";
            // 
            // EntitySpeed
            // 
            this.EntitySpeed.AutoSize = true;
            this.EntitySpeed.Location = new System.Drawing.Point(148, 115);
            this.EntitySpeed.Name = "EntitySpeed";
            this.EntitySpeed.Size = new System.Drawing.Size(44, 13);
            this.EntitySpeed.TabIndex = 31;
            this.EntitySpeed.Text = "Speed: ";
            // 
            // EntityYLocation
            // 
            this.EntityYLocation.AutoSize = true;
            this.EntityYLocation.Location = new System.Drawing.Point(172, 83);
            this.EntityYLocation.Name = "EntityYLocation";
            this.EntityYLocation.Size = new System.Drawing.Size(20, 13);
            this.EntityYLocation.TabIndex = 30;
            this.EntityYLocation.Text = "Y: ";
            // 
            // EntityXLocation
            // 
            this.EntityXLocation.AutoSize = true;
            this.EntityXLocation.Location = new System.Drawing.Point(172, 53);
            this.EntityXLocation.Name = "EntityXLocation";
            this.EntityXLocation.Size = new System.Drawing.Size(20, 13);
            this.EntityXLocation.TabIndex = 29;
            this.EntityXLocation.Text = "X: ";
            // 
            // XLocationInput
            // 
            this.XLocationInput.Location = new System.Drawing.Point(203, 50);
            this.XLocationInput.Name = "XLocationInput";
            this.XLocationInput.Size = new System.Drawing.Size(100, 20);
            this.XLocationInput.TabIndex = 28;
            // 
            // EntityImageLarge
            // 
            this.EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.creeper;
            this.EntityImageLarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EntityImageLarge.Location = new System.Drawing.Point(9, 44);
            this.EntityImageLarge.Name = "EntityImageLarge";
            this.EntityImageLarge.Size = new System.Drawing.Size(125, 125);
            this.EntityImageLarge.TabIndex = 27;
            // 
            // EntityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToepassenEntity);
            this.Controls.Add(this.EntityNaamLabel);
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
            this.Name = "EntityEditor";
            this.Size = new System.Drawing.Size(517, 182);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ToepassenEntity;
        private System.Windows.Forms.Label EntityNaamLabel;
        private System.Windows.Forms.RichTextBox EntityUitleg;
        private System.Windows.Forms.ComboBox TextureInput;
        private System.Windows.Forms.TextBox SpeedInput;
        private System.Windows.Forms.TextBox YLocationInput;
        private System.Windows.Forms.Label ObjectTexture;
        private System.Windows.Forms.Label EntitySpeed;
        private System.Windows.Forms.Label EntityYLocation;
        private System.Windows.Forms.Label EntityXLocation;
        private System.Windows.Forms.TextBox XLocationInput;
        private System.Windows.Forms.Panel EntityImageLarge;
    }
}
