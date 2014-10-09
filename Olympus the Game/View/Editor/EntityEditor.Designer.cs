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
            this.EntityImageLarge = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.popupButton1 = new Olympus_the_Game.View.Buttons.PopupButton();
            this.moveButton1 = new Olympus_the_Game.View.Buttons.MoveButton();
            this.SuspendLayout();
            // 
            // ToepassenEntity
            // 
            this.ToepassenEntity.Location = new System.Drawing.Point(4, 181);
            this.ToepassenEntity.Name = "ToepassenEntity";
            this.ToepassenEntity.Size = new System.Drawing.Size(125, 35);
            this.ToepassenEntity.TabIndex = 38;
            this.ToepassenEntity.Text = "Toepassen";
            this.ToepassenEntity.UseVisualStyleBackColor = true;
            this.ToepassenEntity.Click += new System.EventHandler(this.ToepassenEntity_Click);
            // 
            // EntityImageLarge
            // 
            this.EntityImageLarge.BackgroundImage = global::Olympus_the_Game.Properties.Resources.missing;
            this.EntityImageLarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EntityImageLarge.Location = new System.Drawing.Point(4, 50);
            this.EntityImageLarge.Name = "EntityImageLarge";
            this.EntityImageLarge.Size = new System.Drawing.Size(125, 125);
            this.EntityImageLarge.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(135, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 166);
            this.panel1.TabIndex = 41;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(132, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 37);
            this.labelName.TabIndex = 42;
            // 
            // popupButton1
            // 
            this.popupButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("popupButton1.BackgroundImage")));
            this.popupButton1.Image = ((System.Drawing.Image)(resources.GetObject("popupButton1.Image")));
            this.popupButton1.Location = new System.Drawing.Point(51, 4);
            this.popupButton1.Name = "popupButton1";
            this.popupButton1.Size = new System.Drawing.Size(40, 40);
            this.popupButton1.TabIndex = 40;
            this.popupButton1.UseVisualStyleBackColor = true;
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
            this.moveButton1.UseVisualStyleBackColor = true;
            // 
            // EntityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.popupButton1);
            this.Controls.Add(this.moveButton1);
            this.Controls.Add(this.ToepassenEntity);
            this.Controls.Add(this.EntityImageLarge);
            this.Name = "EntityEditor";
            this.Size = new System.Drawing.Size(517, 223);
            this.Load += new System.EventHandler(this.EntityEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ToepassenEntity;
        private System.Windows.Forms.Panel EntityImageLarge;
        private Buttons.MoveButton moveButton1;
        private Buttons.PopupButton popupButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelName;
    }
}
