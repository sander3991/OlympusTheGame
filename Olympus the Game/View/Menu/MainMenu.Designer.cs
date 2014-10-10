namespace Olympus_the_Game.View.Menu {
    partial class Mainmenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainmenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.settingsDialog1 = new Olympus_the_Game.View.Menu.SettingsDialog();
            this.levelEditorMenu1 = new Olympus_the_Game.View.Menu.LevelEditorMenu();
            this.mainMenuControl1 = new Olympus_the_Game.View.Menu.MainMenuControl();
            this.levelDialog1 = new Olympus_the_Game.View.Menu.LevelDialog();
            this.helpDialog1 = new Olympus_the_Game.View.Menu.HelpDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Olympus_the_Game.Properties.Resources.splashscreen3;
            this.pictureBox1.InitialImage = global::Olympus_the_Game.Properties.Resources.still1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1264, 680);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // ButtonBack
            // 
            this.ButtonBack.AccessibleDescription = "x";
            this.ButtonBack.BackColor = System.Drawing.Color.LightGray;
            this.ButtonBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonBack.BackgroundImage")));
            this.ButtonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonBack.Location = new System.Drawing.Point(1047, 620);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(205, 49);
            this.ButtonBack.TabIndex = 4;
            this.ButtonBack.Text = "Terug";
            this.ButtonBack.UseVisualStyleBackColor = false;
            this.ButtonBack.Visible = false;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // settingsDialog1
            // 
            this.settingsDialog1.Location = new System.Drawing.Point(772, 213);
            this.settingsDialog1.Name = "settingsDialog1";
            this.settingsDialog1.Size = new System.Drawing.Size(426, 110);
            this.settingsDialog1.TabIndex = 7;
            this.settingsDialog1.Visible = false;
            // 
            // levelEditorMenu1
            // 
            this.levelEditorMenu1.Location = new System.Drawing.Point(772, 37);
            this.levelEditorMenu1.Name = "levelEditorMenu1";
            this.levelEditorMenu1.Size = new System.Drawing.Size(426, 110);
            this.levelEditorMenu1.TabIndex = 5;
            // 
            // mainMenuControl1
            // 
            this.mainMenuControl1.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuControl1.ForeColor = System.Drawing.Color.Transparent;
            this.mainMenuControl1.Location = new System.Drawing.Point(12, 23);
            this.mainMenuControl1.Name = "mainMenuControl1";
            this.mainMenuControl1.Size = new System.Drawing.Size(427, 222);
            this.mainMenuControl1.TabIndex = 0;
            // 
            // levelDialog1
            // 
            this.levelDialog1.BackColor = System.Drawing.Color.Transparent;
            this.levelDialog1.Location = new System.Drawing.Point(13, 339);
            this.levelDialog1.Name = "levelDialog1";
            this.levelDialog1.Size = new System.Drawing.Size(426, 330);
            this.levelDialog1.TabIndex = 2;
            // 
            // helpDialog1
            // 
            this.helpDialog1.BackColor = System.Drawing.Color.Transparent;
            this.helpDialog1.Location = new System.Drawing.Point(316, 0);
            this.helpDialog1.Name = "helpDialog1";
            this.helpDialog1.Size = new System.Drawing.Size(632, 680);
            this.helpDialog1.TabIndex = 6;
            this.helpDialog1.Visible = false;
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.settingsDialog1);
            this.Controls.Add(this.levelEditorMenu1);
            this.Controls.Add(this.mainMenuControl1);
            this.Controls.Add(this.levelDialog1);
            this.Controls.Add(this.helpDialog1);
            this.Controls.Add(this.ButtonBack);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.MaximizeBox = false;
            this.Name = "Mainmenu";
            this.Text = "Olympus The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenuControl mainMenuControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private View.Menu.LevelDialog levelDialog1;
        public System.Windows.Forms.Button ButtonBack;
        private View.Menu.LevelEditorMenu levelEditorMenu1;
        private View.Menu.HelpDialog helpDialog1;
        private View.Menu.SettingsDialog settingsDialog1;


    }
}