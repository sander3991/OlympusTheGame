namespace Olympus_the_Game.View.Game
{
    partial class GameFinished
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
            this.berichtLabel = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.ScoreDescr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // berichtLabel
            // 
            this.berichtLabel.AutoSize = true;
            this.berichtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.berichtLabel.Location = new System.Drawing.Point(12, 32);
            this.berichtLabel.Name = "berichtLabel";
            this.berichtLabel.Size = new System.Drawing.Size(424, 24);
            this.berichtLabel.TabIndex = 0;
            this.berichtLabel.Text = "Hier komt het bericht of je het gehaald hebt of niet";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score.Location = new System.Drawing.Point(106, 249);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(70, 24);
            this.score.TabIndex = 1;
            this.score.Text = "Score: ";
            // 
            // menuButton
            // 
            this.menuButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Location = new System.Drawing.Point(133, 328);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(131, 33);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Terug naar menu";
            this.menuButton.UseVisualStyleBackColor = true;
            // 
            // ScoreDescr
            // 
            this.ScoreDescr.AutoSize = true;
            this.ScoreDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreDescr.Location = new System.Drawing.Point(106, 70);
            this.ScoreDescr.Name = "ScoreDescr";
            this.ScoreDescr.Size = new System.Drawing.Size(82, 17);
            this.ScoreDescr.TabIndex = 1;
            this.ScoreDescr.Text = "ScoreDescr";
            // 
            // GameFinished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 373);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.ScoreDescr);
            this.Controls.Add(this.score);
            this.Controls.Add(this.berichtLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameFinished";
            this.Text = "GameFinished";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label berichtLabel;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label ScoreDescr;
    }
}