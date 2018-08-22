﻿namespace PhotoStoryMerge
{
    partial class TextAndSpaceCustomizationForm
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
            this.radioButtonPreviousImage = new System.Windows.Forms.RadioButton();
            this.radioButtonNextImage = new System.Windows.Forms.RadioButton();
            this.radioButtonAverage = new System.Windows.Forms.RadioButton();
            this.radioButtonTextHeight2 = new System.Windows.Forms.RadioButton();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.widthFlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonWidthCustom = new System.Windows.Forms.RadioButton();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonTextHeight4 = new System.Windows.Forms.RadioButton();
            this.radioButtonTextHeightCustom = new System.Windows.Forms.RadioButton();
            this.heightTextMultipleTextBox = new System.Windows.Forms.TextBox();
            this.radioButtonTextHeightPixels = new System.Windows.Forms.RadioButton();
            this.heightPixelsTextBox = new System.Windows.Forms.TextBox();
            this.textEditGroupBox = new System.Windows.Forms.GroupBox();
            this.textEditRichTextBox = new System.Windows.Forms.RichTextBox();
            this.radioButtonBlank = new System.Windows.Forms.RadioButton();
            this.radioButtonAddText = new System.Windows.Forms.RadioButton();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.widthFlowLayoutPanel1.SuspendLayout();
            this.heightFlowLayoutPanel.SuspendLayout();
            this.textEditGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonPreviousImage
            // 
            this.radioButtonPreviousImage.AutoSize = true;
            this.radioButtonPreviousImage.Location = new System.Drawing.Point(3, 26);
            this.radioButtonPreviousImage.Name = "radioButtonPreviousImage";
            this.radioButtonPreviousImage.Size = new System.Drawing.Size(140, 17);
            this.radioButtonPreviousImage.TabIndex = 0;
            this.radioButtonPreviousImage.Text = "Same as previous image";
            this.radioButtonPreviousImage.UseVisualStyleBackColor = true;
            // 
            // radioButtonNextImage
            // 
            this.radioButtonNextImage.AutoSize = true;
            this.radioButtonNextImage.Checked = true;
            this.radioButtonNextImage.Location = new System.Drawing.Point(3, 3);
            this.radioButtonNextImage.Name = "radioButtonNextImage";
            this.radioButtonNextImage.Size = new System.Drawing.Size(120, 17);
            this.radioButtonNextImage.TabIndex = 1;
            this.radioButtonNextImage.TabStop = true;
            this.radioButtonNextImage.Text = "Same as next image";
            this.radioButtonNextImage.UseVisualStyleBackColor = true;
            // 
            // radioButtonAverage
            // 
            this.radioButtonAverage.AutoSize = true;
            this.radioButtonAverage.Location = new System.Drawing.Point(3, 49);
            this.radioButtonAverage.Name = "radioButtonAverage";
            this.radioButtonAverage.Size = new System.Drawing.Size(115, 17);
            this.radioButtonAverage.TabIndex = 2;
            this.radioButtonAverage.Text = "Average of the two";
            this.radioButtonAverage.UseVisualStyleBackColor = true;
            // 
            // radioButtonTextHeight2
            // 
            this.radioButtonTextHeight2.AutoSize = true;
            this.radioButtonTextHeight2.Checked = true;
            this.radioButtonTextHeight2.Location = new System.Drawing.Point(3, 3);
            this.radioButtonTextHeight2.Name = "radioButtonTextHeight2";
            this.radioButtonTextHeight2.Size = new System.Drawing.Size(91, 17);
            this.radioButtonTextHeight2.TabIndex = 3;
            this.radioButtonTextHeight2.TabStop = true;
            this.radioButtonTextHeight2.Text = "Text-height *2";
            this.radioButtonTextHeight2.UseVisualStyleBackColor = true;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(77, 29);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 4;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(270, 29);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 5;
            this.labelWidth.Text = "Width";
            // 
            // widthFlowLayoutPanel1
            // 
            this.widthFlowLayoutPanel1.Controls.Add(this.radioButtonNextImage);
            this.widthFlowLayoutPanel1.Controls.Add(this.radioButtonPreviousImage);
            this.widthFlowLayoutPanel1.Controls.Add(this.radioButtonAverage);
            this.widthFlowLayoutPanel1.Controls.Add(this.radioButtonWidthCustom);
            this.widthFlowLayoutPanel1.Controls.Add(this.widthTextBox);
            this.widthFlowLayoutPanel1.Location = new System.Drawing.Point(214, 56);
            this.widthFlowLayoutPanel1.Name = "widthFlowLayoutPanel1";
            this.widthFlowLayoutPanel1.Size = new System.Drawing.Size(158, 146);
            this.widthFlowLayoutPanel1.TabIndex = 6;
            // 
            // radioButtonWidthCustom
            // 
            this.radioButtonWidthCustom.AutoSize = true;
            this.radioButtonWidthCustom.Location = new System.Drawing.Point(3, 72);
            this.radioButtonWidthCustom.Name = "radioButtonWidthCustom";
            this.radioButtonWidthCustom.Size = new System.Drawing.Size(63, 17);
            this.radioButtonWidthCustom.TabIndex = 3;
            this.radioButtonWidthCustom.Text = "Custom:";
            this.radioButtonWidthCustom.UseVisualStyleBackColor = true;
            this.radioButtonWidthCustom.CheckedChanged += new System.EventHandler(this.radioButtonWidthCustom_CheckedChanged);
            // 
            // widthTextBox
            // 
            this.widthTextBox.Enabled = false;
            this.widthTextBox.Location = new System.Drawing.Point(3, 95);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(88, 20);
            this.widthTextBox.TabIndex = 4;
            this.widthTextBox.TextChanged += new System.EventHandler(this.widthTextBox_TextChanged);
            this.widthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthTextBox_KeyPress);
            // 
            // heightFlowLayoutPanel
            // 
            this.heightFlowLayoutPanel.Controls.Add(this.radioButtonTextHeight2);
            this.heightFlowLayoutPanel.Controls.Add(this.radioButtonTextHeight4);
            this.heightFlowLayoutPanel.Controls.Add(this.radioButtonTextHeightCustom);
            this.heightFlowLayoutPanel.Controls.Add(this.heightTextMultipleTextBox);
            this.heightFlowLayoutPanel.Controls.Add(this.radioButtonTextHeightPixels);
            this.heightFlowLayoutPanel.Controls.Add(this.heightPixelsTextBox);
            this.heightFlowLayoutPanel.Location = new System.Drawing.Point(46, 56);
            this.heightFlowLayoutPanel.Name = "heightFlowLayoutPanel";
            this.heightFlowLayoutPanel.Size = new System.Drawing.Size(165, 146);
            this.heightFlowLayoutPanel.TabIndex = 7;
            // 
            // radioButtonTextHeight4
            // 
            this.radioButtonTextHeight4.AutoSize = true;
            this.radioButtonTextHeight4.Location = new System.Drawing.Point(3, 26);
            this.radioButtonTextHeight4.Name = "radioButtonTextHeight4";
            this.radioButtonTextHeight4.Size = new System.Drawing.Size(91, 17);
            this.radioButtonTextHeight4.TabIndex = 4;
            this.radioButtonTextHeight4.Text = "Text-height *4";
            this.radioButtonTextHeight4.UseVisualStyleBackColor = true;
            // 
            // radioButtonTextHeightCustom
            // 
            this.radioButtonTextHeightCustom.AutoSize = true;
            this.radioButtonTextHeightCustom.Location = new System.Drawing.Point(3, 49);
            this.radioButtonTextHeightCustom.Name = "radioButtonTextHeightCustom";
            this.radioButtonTextHeightCustom.Size = new System.Drawing.Size(135, 17);
            this.radioButtonTextHeightCustom.TabIndex = 7;
            this.radioButtonTextHeightCustom.Text = "Custom (X* text height):";
            this.radioButtonTextHeightCustom.UseVisualStyleBackColor = true;
            this.radioButtonTextHeightCustom.CheckedChanged += new System.EventHandler(this.radioButtonCustomHeight_CheckedChanged);
            // 
            // heightTextMultipleTextBox
            // 
            this.heightTextMultipleTextBox.Enabled = false;
            this.heightTextMultipleTextBox.Location = new System.Drawing.Point(3, 72);
            this.heightTextMultipleTextBox.Name = "heightTextMultipleTextBox";
            this.heightTextMultipleTextBox.Size = new System.Drawing.Size(66, 20);
            this.heightTextMultipleTextBox.TabIndex = 6;
            this.heightTextMultipleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heightTextMultipleTextBox_KeyPress);
            // 
            // radioButtonTextHeightPixels
            // 
            this.radioButtonTextHeightPixels.AutoSize = true;
            this.radioButtonTextHeightPixels.Location = new System.Drawing.Point(3, 98);
            this.radioButtonTextHeightPixels.Name = "radioButtonTextHeightPixels";
            this.radioButtonTextHeightPixels.Size = new System.Drawing.Size(109, 17);
            this.radioButtonTextHeightPixels.TabIndex = 5;
            this.radioButtonTextHeightPixels.Text = "Custom (in pixels):";
            this.radioButtonTextHeightPixels.UseVisualStyleBackColor = true;
            this.radioButtonTextHeightPixels.CheckedChanged += new System.EventHandler(this.radioButtonTextHeightPixels_CheckedChanged);
            // 
            // heightPixelsTextBox
            // 
            this.heightPixelsTextBox.Enabled = false;
            this.heightPixelsTextBox.Location = new System.Drawing.Point(3, 121);
            this.heightPixelsTextBox.Name = "heightPixelsTextBox";
            this.heightPixelsTextBox.Size = new System.Drawing.Size(66, 20);
            this.heightPixelsTextBox.TabIndex = 8;
            this.heightPixelsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heightPixelsTextBox_KeyPress);
            // 
            // textEditGroupBox
            // 
            this.textEditGroupBox.Controls.Add(this.textEditRichTextBox);
            this.textEditGroupBox.Controls.Add(this.radioButtonBlank);
            this.textEditGroupBox.Controls.Add(this.radioButtonAddText);
            this.textEditGroupBox.Location = new System.Drawing.Point(46, 208);
            this.textEditGroupBox.Name = "textEditGroupBox";
            this.textEditGroupBox.Size = new System.Drawing.Size(326, 142);
            this.textEditGroupBox.TabIndex = 8;
            this.textEditGroupBox.TabStop = false;
            // 
            // textEditRichTextBox
            // 
            this.textEditRichTextBox.DetectUrls = false;
            this.textEditRichTextBox.Location = new System.Drawing.Point(6, 42);
            this.textEditRichTextBox.Name = "textEditRichTextBox";
            this.textEditRichTextBox.Size = new System.Drawing.Size(314, 94);
            this.textEditRichTextBox.TabIndex = 2;
            this.textEditRichTextBox.Text = "";
            // 
            // radioButtonBlank
            // 
            this.radioButtonBlank.AutoSize = true;
            this.radioButtonBlank.Location = new System.Drawing.Point(171, 19);
            this.radioButtonBlank.Name = "radioButtonBlank";
            this.radioButtonBlank.Size = new System.Drawing.Size(52, 17);
            this.radioButtonBlank.TabIndex = 1;
            this.radioButtonBlank.Text = "Blank";
            this.radioButtonBlank.UseVisualStyleBackColor = true;
            this.radioButtonBlank.CheckedChanged += new System.EventHandler(this.radioButtonBlank_CheckedChanged);
            // 
            // radioButtonAddText
            // 
            this.radioButtonAddText.AutoSize = true;
            this.radioButtonAddText.Checked = true;
            this.radioButtonAddText.Location = new System.Drawing.Point(69, 19);
            this.radioButtonAddText.Name = "radioButtonAddText";
            this.radioButtonAddText.Size = new System.Drawing.Size(64, 17);
            this.radioButtonAddText.TabIndex = 0;
            this.radioButtonAddText.TabStop = true;
            this.radioButtonAddText.Text = "Add text";
            this.radioButtonAddText.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(83, 366);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(247, 366);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TextAndSpaceCustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 537);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.textEditGroupBox);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.heightFlowLayoutPanel);
            this.Controls.Add(this.widthFlowLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "TextAndSpaceCustomizationForm";
            this.Text = "Insert text or blank";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextAndSpaceCustomizationForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextAndSpaceCustomizationForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextAndSpaceCustomizationForm_KeyUp);
            this.widthFlowLayoutPanel1.ResumeLayout(false);
            this.widthFlowLayoutPanel1.PerformLayout();
            this.heightFlowLayoutPanel.ResumeLayout(false);
            this.heightFlowLayoutPanel.PerformLayout();
            this.textEditGroupBox.ResumeLayout(false);
            this.textEditGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonPreviousImage;
        private System.Windows.Forms.RadioButton radioButtonNextImage;
        private System.Windows.Forms.RadioButton radioButtonAverage;
        private System.Windows.Forms.RadioButton radioButtonTextHeight2;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.FlowLayoutPanel widthFlowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel heightFlowLayoutPanel;
        private System.Windows.Forms.RadioButton radioButtonTextHeight4;
        private System.Windows.Forms.RadioButton radioButtonTextHeightPixels;
        private System.Windows.Forms.RadioButton radioButtonWidthCustom;
        private System.Windows.Forms.GroupBox textEditGroupBox;
        private System.Windows.Forms.RadioButton radioButtonBlank;
        private System.Windows.Forms.RadioButton radioButtonAddText;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.RadioButton radioButtonTextHeightCustom;
        private System.Windows.Forms.TextBox heightTextMultipleTextBox;
        private System.Windows.Forms.TextBox heightPixelsTextBox;
        private System.Windows.Forms.RichTextBox textEditRichTextBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
    }
}