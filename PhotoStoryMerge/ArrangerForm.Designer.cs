﻿namespace PhotoStoryMerge
{
    partial class ArrangerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArrangerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearWorkspaceCtrlDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveLeftLeftArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveRightRightArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreDPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockLoadFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.labelHelp = new System.Windows.Forms.Label();
            this.insertStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blankSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBetweenImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textOverlayedOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.insertStripMenuItem,
            this.orderToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ArrangerForm_DragDrop);
            this.menuStrip1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ArrangerForm_DragEnter);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.pasteCtrlVToolStripMenuItem,
            this.clearWorkspaceCtrlDToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openToolStripMenuItem.Text = "Open (Ctrl + O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pasteCtrlVToolStripMenuItem
            // 
            this.pasteCtrlVToolStripMenuItem.Name = "pasteCtrlVToolStripMenuItem";
            this.pasteCtrlVToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.pasteCtrlVToolStripMenuItem.Text = "Paste (Ctrl+V)";
            this.pasteCtrlVToolStripMenuItem.Click += new System.EventHandler(this.pasteCtrlVToolStripMenuItem_Click);
            // 
            // clearWorkspaceCtrlDToolStripMenuItem
            // 
            this.clearWorkspaceCtrlDToolStripMenuItem.Name = "clearWorkspaceCtrlDToolStripMenuItem";
            this.clearWorkspaceCtrlDToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.clearWorkspaceCtrlDToolStripMenuItem.Text = "Clear Workspace (Ctrl+D)";
            this.clearWorkspaceCtrlDToolStripMenuItem.Click += new System.EventHandler(this.clearWorkspaceCtrlDToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.closeToolStripMenuItem.Text = "Close (Escape)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveLeftLeftArrowToolStripMenuItem,
            this.moveRightRightArrowToolStripMenuItem,
            this.invertOrderToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.orderToolStripMenuItem.Text = "Order";
            this.orderToolStripMenuItem.Click += new System.EventHandler(this.orderToolStripMenuItem_Click);
            // 
            // moveLeftLeftArrowToolStripMenuItem
            // 
            this.moveLeftLeftArrowToolStripMenuItem.Enabled = false;
            this.moveLeftLeftArrowToolStripMenuItem.Name = "moveLeftLeftArrowToolStripMenuItem";
            this.moveLeftLeftArrowToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.moveLeftLeftArrowToolStripMenuItem.Text = "Move Left (Left Arrow)";
            this.moveLeftLeftArrowToolStripMenuItem.Click += new System.EventHandler(this.moveLeftLeftArrowToolStripMenuItem_Click);
            // 
            // moveRightRightArrowToolStripMenuItem
            // 
            this.moveRightRightArrowToolStripMenuItem.Enabled = false;
            this.moveRightRightArrowToolStripMenuItem.Name = "moveRightRightArrowToolStripMenuItem";
            this.moveRightRightArrowToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.moveRightRightArrowToolStripMenuItem.Text = "Move Right (Right Arrow)";
            this.moveRightRightArrowToolStripMenuItem.Click += new System.EventHandler(this.moveRightRightArrowToolStripMenuItem_Click);
            // 
            // invertOrderToolStripMenuItem
            // 
            this.invertOrderToolStripMenuItem.Name = "invertOrderToolStripMenuItem";
            this.invertOrderToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.invertOrderToolStripMenuItem.Text = "Invert Order (i)";
            this.invertOrderToolStripMenuItem.Click += new System.EventHandler(this.invertOrderToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoreDPIToolStripMenuItem,
            this.lockLoadFilesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // ignoreDPIToolStripMenuItem
            // 
            this.ignoreDPIToolStripMenuItem.Checked = true;
            this.ignoreDPIToolStripMenuItem.CheckOnClick = true;
            this.ignoreDPIToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreDPIToolStripMenuItem.Name = "ignoreDPIToolStripMenuItem";
            this.ignoreDPIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ignoreDPIToolStripMenuItem.Text = "IgnoreDPI";
            // 
            // lockLoadFilesToolStripMenuItem
            // 
            this.lockLoadFilesToolStripMenuItem.CheckOnClick = true;
            this.lockLoadFilesToolStripMenuItem.Name = "lockLoadFilesToolStripMenuItem";
            this.lockLoadFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lockLoadFilesToolStripMenuItem.Text = "Lock-Load Files";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.generateToolStripMenuItem.Text = "Generate!";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.helpToolStripMenuItem.Text = "Help/About";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AllowDrop = true;
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(684, 414);
            this.flowLayoutPanelMain.TabIndex = 1;
            this.flowLayoutPanelMain.Click += new System.EventHandler(this.flowLayoutPanelMain_Click);
            this.flowLayoutPanelMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.ArrangerForm_DragDrop);
            this.flowLayoutPanelMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.ArrangerForm_DragEnter);
            this.flowLayoutPanelMain.DoubleClick += new System.EventHandler(this.flowLayoutPanel1_DoubleClick);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Enabled = false;
            this.labelHelp.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelp.Location = new System.Drawing.Point(85, 86);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(478, 273);
            this.labelHelp.TabIndex = 1;
            this.labelHelp.Text = resources.GetString("labelHelp.Text");
            // 
            // insertStripMenuItem
            // 
            this.insertStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankSpaceToolStripMenuItem,
            this.textBetweenImagesToolStripMenuItem,
            this.textOverlayedOnToolStripMenuItem});
            this.insertStripMenuItem.Name = "insertStripMenuItem";
            this.insertStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertStripMenuItem.Text = "Insert";
            // 
            // blankSpaceToolStripMenuItem
            // 
            this.blankSpaceToolStripMenuItem.Name = "blankSpaceToolStripMenuItem";
            this.blankSpaceToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.blankSpaceToolStripMenuItem.Text = "Blank Space";
            this.blankSpaceToolStripMenuItem.Click += new System.EventHandler(this.blankSpaceToolStripMenuItem_Click);
            // 
            // textBetweenImagesToolStripMenuItem
            // 
            this.textBetweenImagesToolStripMenuItem.Name = "textBetweenImagesToolStripMenuItem";
            this.textBetweenImagesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.textBetweenImagesToolStripMenuItem.Text = "Text Between Images";
            // 
            // textOverlayedOnToolStripMenuItem
            // 
            this.textOverlayedOnToolStripMenuItem.Name = "textOverlayedOnToolStripMenuItem";
            this.textOverlayedOnToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.textOverlayedOnToolStripMenuItem.Text = "Text Overlayed On";
            // 
            // ArrangerForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = global::PhotoStoryMerge.Properties.Resources.PhotoStoryMerge;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ArrangerForm";
            this.Text = "Create a Picture Story";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ArrangerForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ArrangerForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArrangerForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertOrderToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.ToolStripMenuItem moveLeftLeftArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveRightRightArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteCtrlVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearWorkspaceCtrlDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreDPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockLoadFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blankSpaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textBetweenImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textOverlayedOnToolStripMenuItem;
    }
}

