namespace Olympus_the_Game.View
{
    partial class InfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoView));
            this.listView1 = new System.Windows.Forms.ListView();
            this.EntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntitySpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.popupButton1 = new Olympus_the_Game.View.Buttons.PopupButton();
            this.moveButton1 = new Olympus_the_Game.View.Buttons.MoveButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EntityName,
            this.PosX,
            this.PosY,
            this.EntitySpeed});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(265, 520);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // EntityName
            // 
            this.EntityName.Text = "Naam";
            this.EntityName.Width = 89;
            // 
            // PosX
            // 
            this.PosX.Text = "X";
            // 
            // PosY
            // 
            this.PosY.Text = "Y";
            this.PosY.Width = 58;
            // 
            // EntitySpeed
            // 
            this.EntitySpeed.Text = "Speed";
            // 
            // popupButton1
            // 
            this.popupButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("popupButton1.BackgroundImage")));
            this.popupButton1.Image = global::Olympus_the_Game.Properties.Resources.new_window_icon;
            this.popupButton1.Location = new System.Drawing.Point(143, 440);
            this.popupButton1.Name = "popupButton1";
            this.popupButton1.Size = new System.Drawing.Size(40, 40);
            this.popupButton1.TabIndex = 4;
            this.popupButton1.UseVisualStyleBackColor = true;
            // 
            // moveButton1
            // 
            this.moveButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveButton1.BackgroundImage")));
            this.moveButton1.Image = ((System.Drawing.Image)(resources.GetObject("moveButton1.Image")));
            this.moveButton1.Location = new System.Drawing.Point(190, 440);
            this.moveButton1.MouseDownLocation = new System.Drawing.Point(0, 0);
            this.moveButton1.Name = "moveButton1";
            this.moveButton1.Size = new System.Drawing.Size(40, 40);
            this.moveButton1.TabIndex = 5;
            this.moveButton1.UseVisualStyleBackColor = true;
            // 
            // InfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.moveButton1);
            this.Controls.Add(this.popupButton1);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.Name = "InfoView";
            this.Size = new System.Drawing.Size(265, 521);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader EntityName;
        private System.Windows.Forms.ColumnHeader PosX;
        private System.Windows.Forms.ColumnHeader PosY;
        private System.Windows.Forms.ColumnHeader EntitySpeed;
        private Buttons.PopupButton popupButton1;
        private Buttons.MoveButton moveButton1;

    }
}
