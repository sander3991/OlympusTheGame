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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityEditor));
            this.ToepassenEntity = new System.Windows.Forms.Button();
            this.EntityNaamLabel = new System.Windows.Forms.Label();
            this.EntityUitleg = new System.Windows.Forms.RichTextBox();
            this.YLocationInput = new System.Windows.Forms.TextBox();
            this.EntityYLocation = new System.Windows.Forms.Label();
            this.EntityXLocation = new System.Windows.Forms.Label();
            this.XLocationInput = new System.Windows.Forms.TextBox();
            this.EntityImageLarge = new System.Windows.Forms.Panel();
            this.moveButton1 = new Olympus_the_Game.View.Buttons.MoveButton();
            this.popupButton1 = new Olympus_the_Game.View.Buttons.PopupButton();
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
            this.ToepassenEntity.Click += new System.EventHandler(this.ToepassenEntity_Click);
            // 
            // EntityNaamLabel
            // 
            this.EntityNaamLabel.AutoSize = true;
            this.EntityNaamLabel.Location = new System.Drawing.Point(48, 13);
            this.EntityNaamLabel.Name = "EntityNaamLabel";
            this.EntityNaamLabel.Size = new System.Drawing.Size(0, 13);
            this.EntityNaamLabel.TabIndex = 37;
            // 
            // EntityUitleg
            // 
            this.EntityUitleg.BackColor = System.Drawing.SystemColors.Menu;
            this.EntityUitleg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EntityUitleg.Location = new System.Drawing.Point(322, 50);
            this.EntityUitleg.Name = "EntityUitleg";
            this.EntityUitleg.ReadOnly = true;
            this.EntityUitleg.Size = new System.Drawing.Size(174, 59);
            this.EntityUitleg.TabIndex = 36;
            this.EntityUitleg.Text = "Pas meerdere waardes aan van de geselecteerde entity door middel van deze DetailE" +
    "ditor.";
            // 
            // YLocationInput
            // 
            this.YLocationInput.Location = new System.Drawing.Point(203, 80);
            this.YLocationInput.Name = "YLocationInput";
            this.YLocationInput.Size = new System.Drawing.Size(100, 20);
            this.YLocationInput.TabIndex = 33;
            this.YLocationInput.Visible = false;
            // 
            // EntityYLocation
            // 
            this.EntityYLocation.AutoSize = true;
            this.EntityYLocation.Location = new System.Drawing.Point(172, 83);
            this.EntityYLocation.Name = "EntityYLocation";
            this.EntityYLocation.Size = new System.Drawing.Size(20, 13);
            this.EntityYLocation.TabIndex = 30;
            this.EntityYLocation.Text = "Y: ";
            this.EntityYLocation.Visible = false;
            // 
            // EntityXLocation
            // 
            this.EntityXLocation.AutoSize = true;
            this.EntityXLocation.Location = new System.Drawing.Point(172, 53);
            this.EntityXLocation.Name = "EntityXLocation";
            this.EntityXLocation.Size = new System.Drawing.Size(20, 13);
            this.EntityXLocation.TabIndex = 29;
            this.EntityXLocation.Text = "X: ";
            this.EntityXLocation.Visible = false;
            // 
            // XLocationInput
            // 
            this.XLocationInput.Location = new System.Drawing.Point(203, 50);
            this.XLocationInput.Name = "XLocationInput";
            this.XLocationInput.Size = new System.Drawing.Size(100, 20);
            this.XLocationInput.TabIndex = 28;
            this.XLocationInput.Visible = false;
            // 
            // EntityImageLarge
            // 
            this.EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.missing;
            this.EntityImageLarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EntityImageLarge.Location = new System.Drawing.Point(9, 44);
            this.EntityImageLarge.Name = "EntityImageLarge";
            this.EntityImageLarge.Size = new System.Drawing.Size(125, 125);
            this.EntityImageLarge.TabIndex = 27;
            // 
            // moveButton1
            // 
            this.moveButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveButton1.BackgroundImage")));
            this.moveButton1.Image = ((System.Drawing.Image)(resources.GetObject("moveButton1.Image")));
            this.moveButton1.Location = new System.Drawing.Point(4, 4);
            this.moveButton1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.moveButton1.Name = "moveButton1";
            this.moveButton1.Size = new System.Drawing.Size(40, 40);
            this.moveButton1.TabIndex = 39;
            this.moveButton1.Text = "moveButton1";
            this.moveButton1.UseVisualStyleBackColor = true;
            // 
            // popupButton1
            // 
            this.popupButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("popupButton1.BackgroundImage")));
            this.popupButton1.Image = ((System.Drawing.Image)(resources.GetObject("popupButton1.Image")));
            this.popupButton1.Location = new System.Drawing.Point(51, 4);
            this.popupButton1.Name = "popupButton1";
            this.popupButton1.Size = new System.Drawing.Size(40, 40);
            this.popupButton1.TabIndex = 40;
            this.popupButton1.Text = "popupButton1";
            this.popupButton1.UseVisualStyleBackColor = true;
            // 
            // EntityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupButton1);
            this.Controls.Add(this.moveButton1);
            this.Controls.Add(this.ToepassenEntity);
            this.Controls.Add(this.EntityNaamLabel);
            this.Controls.Add(this.EntityUitleg);
            this.Controls.Add(this.YLocationInput);
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
        private System.Windows.Forms.TextBox YLocationInput;
        private System.Windows.Forms.Label EntityYLocation;
        private System.Windows.Forms.Label EntityXLocation;
        private System.Windows.Forms.TextBox XLocationInput;
        private System.Windows.Forms.Panel EntityImageLarge;
        private Buttons.MoveButton moveButton1;
        private Buttons.PopupButton popupButton1;
    }
}
