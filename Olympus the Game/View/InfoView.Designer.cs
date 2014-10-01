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
            this.listView1 = new System.Windows.Forms.ListView();
            this.EntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntitySpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EntityName,
            this.PosX,
            this.PosY,
            this.EntitySpeed});
            this.listView1.Location = new System.Drawing.Point(-4, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(248, 502);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // EntityName
            // 
            this.EntityName.Text = "Naam";
            // 
            // PosX
            // 
            this.PosX.Text = "X";
            // 
            // PosY
            // 
            this.PosY.Text = "Y";
            // 
            // EntitySpeed
            // 
            this.EntitySpeed.Text = "Speed";
            // 
            // InfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "InfoView";
            this.Size = new System.Drawing.Size(240, 504);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader EntityName;
        private System.Windows.Forms.ColumnHeader PosX;
        private System.Windows.Forms.ColumnHeader PosY;
        private System.Windows.Forms.ColumnHeader EntitySpeed;

    }
}
