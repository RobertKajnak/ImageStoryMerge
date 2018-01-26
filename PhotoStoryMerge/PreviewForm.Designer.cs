namespace PhotoStoryMerge
{
    partial class PreviewForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleDownBy25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToCurrentZoomLevellevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutCtrlScrollUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInCtrlScrollUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(409, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem,
            this.scaleDownBy25ToolStripMenuItem,
            this.scaleToCurrentZoomLevellevelToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.sToolStripMenuItem.Text = "Scale Up by 25%";
            // 
            // scaleDownBy25ToolStripMenuItem
            // 
            this.scaleDownBy25ToolStripMenuItem.Name = "scaleDownBy25ToolStripMenuItem";
            this.scaleDownBy25ToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.scaleDownBy25ToolStripMenuItem.Text = "Scale Down by 25%";
            // 
            // scaleToCurrentZoomLevellevelToolStripMenuItem
            // 
            this.scaleToCurrentZoomLevellevelToolStripMenuItem.Name = "scaleToCurrentZoomLevellevelToolStripMenuItem";
            this.scaleToCurrentZoomLevellevelToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.scaleToCurrentZoomLevellevelToolStripMenuItem.Text = "Scale to current zoom level (<level>)";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomOutCtrlScrollUpToolStripMenuItem,
            this.zoomInCtrlScrollUpToolStripMenuItem,
            this.zoomToToolStripMenuItem,
            this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zoomOutCtrlScrollUpToolStripMenuItem
            // 
            this.zoomOutCtrlScrollUpToolStripMenuItem.Name = "zoomOutCtrlScrollUpToolStripMenuItem";
            this.zoomOutCtrlScrollUpToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.zoomOutCtrlScrollUpToolStripMenuItem.Text = "Zoom Out (Ctrl+Scroll Down)";
            this.zoomOutCtrlScrollUpToolStripMenuItem.Click += new System.EventHandler(this.zoomOutCtrlScrollUpToolStripMenuItem_Click);
            // 
            // zoomInCtrlScrollUpToolStripMenuItem
            // 
            this.zoomInCtrlScrollUpToolStripMenuItem.Name = "zoomInCtrlScrollUpToolStripMenuItem";
            this.zoomInCtrlScrollUpToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.zoomInCtrlScrollUpToolStripMenuItem.Text = "Zoom In (Ctrl + Scroll Up)";
            this.zoomInCtrlScrollUpToolStripMenuItem.Click += new System.EventHandler(this.zoomInCtrlScrollUpToolStripMenuItem_Click);
            // 
            // zoomToToolStripMenuItem
            // 
            this.zoomToToolStripMenuItem.Name = "zoomToToolStripMenuItem";
            this.zoomToToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.zoomToToolStripMenuItem.Text = "Zoom To ... (Z)";
            this.zoomToToolStripMenuItem.Click += new System.EventHandler(this.zoomToToolStripMenuItem_Click);
            // 
            // resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem
            // 
            this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem.Name = "resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem";
            this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem.Text = "Reset Zoom To Actual Size (Middle Click)";
            this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox.Size = new System.Drawing.Size(284, 234);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel_MouseClick);
            this.pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PreviewForm_MouseWheel);
            this.pictureBox.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.pictureBox);
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(409, 277);
            this.flowLayoutPanel.TabIndex = 2;
            this.flowLayoutPanel.WrapContents = false;
            this.flowLayoutPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel_MouseClick);
            this.flowLayoutPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PreviewForm_MouseWheel);
            // 
            // PreviewForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(409, 306);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PreviewForm";
            this.Text = "Preview";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PreviewForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PreviewForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PreviewForm_KeyUp);
            this.Resize += new System.EventHandler(this.PreviewForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutCtrlScrollUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInCtrlScrollUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleDownBy25ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToCurrentZoomLevellevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem;
    }
}