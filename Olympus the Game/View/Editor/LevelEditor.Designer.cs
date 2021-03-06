﻿using Olympus_the_Game.Model;
using Olympus_the_Game.View.Game;

namespace Olympus_the_Game.View.Editor
{
    partial class LevelEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditor));
            PlayField playField1 = new PlayField();
            this.Menubar = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opslaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitySourcePanelList1 = new Olympus_the_Game.View.Editor.EntitySourcePanelList();
            this.speelveldEditor1 = new Olympus_the_Game.View.Editor.SpeelveldEditor();
            this.entityEditor1 = new Olympus_the_Game.View.Editor.EntityEditor();
            this.gamePanelEditor = new GamePanel();
            this.Menubar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menubar
            // 
            this.Menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem});
            this.Menubar.Location = new System.Drawing.Point(0, 0);
            this.Menubar.Name = "Menubar";
            this.Menubar.Size = new System.Drawing.Size(1232, 24);
            this.Menubar.TabIndex = 24;
            this.Menubar.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.opslaanToolStripMenuItem,
            this.toolStripMenuItem2,
            this.afsluitenToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.Inladen_Click);
            // 
            // opslaanToolStripMenuItem
            // 
            this.opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            this.opslaanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.opslaanToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.opslaanToolStripMenuItem.Text = "Opslaan";
            this.opslaanToolStripMenuItem.Click += new System.EventHandler(this.Opslaan_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.Afsluiten_Click);
            // 
            // entitySourcePanelList1
            // 
            this.entitySourcePanelList1.AllowDrop = true;
            this.entitySourcePanelList1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.entitySourcePanelList1.AutoScroll = true;
            this.entitySourcePanelList1.BackColor = System.Drawing.Color.Transparent;
            this.entitySourcePanelList1.Location = new System.Drawing.Point(800, 99);
            this.entitySourcePanelList1.Name = "entitySourcePanelList1";
            this.entitySourcePanelList1.Size = new System.Drawing.Size(400, 500);
            this.entitySourcePanelList1.TabIndex = 25;
            // 
            // speelveldEditor1
            // 
            this.speelveldEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speelveldEditor1.EnteredSize = new System.Drawing.Size(0, 0);
            this.speelveldEditor1.Location = new System.Drawing.Point(12, 629);
            this.speelveldEditor1.Name = "speelveldEditor1";
            this.speelveldEditor1.Playfield = null;
            this.speelveldEditor1.Size = new System.Drawing.Size(368, 182);
            this.speelveldEditor1.TabIndex = 19;
            this.speelveldEditor1.ApplyClick += new System.Action(this.ApplyPlayfieldChanges);
            // 
            // entityEditor1
            // 
            this.entityEditor1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.entityEditor1.Location = new System.Drawing.Point(400, 566);
            this.entityEditor1.Name = "entityEditor1";
            this.entityEditor1.Size = new System.Drawing.Size(517, 223);
            this.entityEditor1.TabIndex = 18;
            // 
            // gamePanelEditor
            // 
            this.gamePanelEditor.AllowDrop = true;
            this.gamePanelEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanelEditor.BackgroundImage")));
            this.gamePanelEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gamePanelEditor.Location = new System.Drawing.Point(12, 36);
            this.gamePanelEditor.Name = "gamePanelEditor";
            playField1.Height = 500;
            playField1.Name = "Map_1";
            playField1.Width = 1000;
            this.gamePanelEditor.Playfield = playField1;
            this.gamePanelEditor.Size = new System.Drawing.Size(904, 452);
            this.gamePanelEditor.TabIndex = 16;
            this.gamePanelEditor.DragDrop += new System.Windows.Forms.DragEventHandler(this.drag_drop);
            this.gamePanelEditor.DragEnter += new System.Windows.Forms.DragEventHandler(this.EntityDragEnter);
            this.gamePanelEditor.DoubleClick += new System.EventHandler(this.Mouse_DoubleClick);
            this.gamePanelEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlaatsEntity);
            this.gamePanelEditor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Clicked);
            this.gamePanelEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Start_InPanel_Drag);
            this.gamePanelEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InPanel_Mouse_Move);
            this.gamePanelEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stop_InPanel_Drag);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Olympus_the_Game.Properties.Resources.dirt;
            this.ClientSize = new System.Drawing.Size(1232, 823);
            this.Controls.Add(this.entitySourcePanelList1);
            this.Controls.Add(this.speelveldEditor1);
            this.Controls.Add(this.entityEditor1);
            this.Controls.Add(this.gamePanelEditor);
            this.Controls.Add(this.Menubar);
            this.MainMenuStrip = this.Menubar;
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.drag_drop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EntityDragEnter);
            this.Menubar.ResumeLayout(false);
            this.Menubar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GamePanel gamePanelEditor;
        private EntityEditor entityEditor1;
        private SpeelveldEditor speelveldEditor1;
        private System.Windows.Forms.MenuStrip Menubar;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opslaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private EntitySourcePanelList entitySourcePanelList1;

    }
}