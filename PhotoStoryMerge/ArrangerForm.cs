using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhotoStoryMerge
{
    public partial class ArrangerForm : Form
    {
        System.Windows.Forms.Control.ControlCollection pictureBoxes;
        PictureBox selectedPictureBox;
        bool isControlPressed = false;

        public ArrangerForm()
        {
            InitializeComponent();
            pictureBoxes = this.flowLayoutPanelMain.Controls;
        }


        #region Utility Classes and Functions

        private PictureBox addPictureBox(Image image)
        {

            if (labelHelp.Visible)
            {
                labelHelp.Visible = false;
                labelHelp.Enabled = false;
            }
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "pictureBox" + pictureBoxes.Count;
            if (image.Size.Height / image.Size.Width == 5 / 4)
                pictureBox.Size = new System.Drawing.Size(210, 160);
            else
                pictureBox.Size = new System.Drawing.Size(200, 160);

            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Padding = new System.Windows.Forms.Padding(5);
            pictureBox.Click += new System.EventHandler(this.pictureBox_Click);

            pictureBox.Image = image;

            pictureBoxes.Add(pictureBox);

            this.flowLayoutPanelMain.ResumeLayout(false);

            return pictureBox;
        }

        private void moveItemLeft()
        {
            if (selectedPictureBox != null)
            {
                int ind = pictureBoxes.IndexOf(selectedPictureBox);
                if (ind > 0)
                {
                    pictureBoxes.SetChildIndex(selectedPictureBox, ind - 1);
                }
            }
        }

        private void moveItemRight()
        {
            if (selectedPictureBox != null)
            {
                int ind = pictureBoxes.IndexOf(selectedPictureBox);
                if (ind < pictureBoxes.Count)
                {
                    pictureBoxes.SetChildIndex(selectedPictureBox, ind + 1);
                }
            }
        }

        private Image generateMergedImage()
        {
            int W = 0, H = 0;
            foreach (var v in pictureBoxes)
            {
                PictureBox pb = (PictureBox)v;
                H += pb.Image.Height;
                W = Math.Max(pb.Image.Width, W);
            }

            //create image
            var merged = new Bitmap(W, H);

            using (var canvas = Graphics.FromImage(merged))
            {
                ///for zooming and rotation
                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                int totalH = 0;
                foreach (var v in pictureBoxes)
                {
                    PictureBox pb = (PictureBox)v;
                    Image im = pb.Image;
                    int h = im.Height;
                    int w = im.Width == W ? 0 : (W - im.Width) / 2;

                    canvas.DrawImage(im, w, totalH);
                    totalH += h;
                }
                canvas.Save();
            }

            return merged;

        }

        #endregion

        #region Event Handlers

        #region Menu Events

        #region File

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_DoubleClick(sender, e);
        }

        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Bitmap))
            {

                addPictureBox(Clipboard.GetImage());
            }

            if (iData.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var v in Clipboard.GetFileDropList())
                {
                    try
                    {
                        addPictureBox(Image.FromFile(v));
                    }
                    catch
                    {
                        Console.WriteLine("Text does not leat do a valid image file");
                    }
                }
            }
        }

        private void clearWorkspaceCtrlDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedPictureBox = null;
            pictureBoxes.Clear();
            labelHelp.Visible = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            Application.Exit();
        }

        #endregion

        #region Order

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox == null)
            {
                moveLeftLeftArrowToolStripMenuItem.Enabled = false;
                moveRightRightArrowToolStripMenuItem.Enabled = false;
            }
            else
            {
                moveLeftLeftArrowToolStripMenuItem.Enabled = true;
                moveRightRightArrowToolStripMenuItem.Enabled = true;
            }
        }

        private void moveLeftLeftArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveItemLeft();
        }

        private void moveRightRightArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveItemRight();
        }

        private void invertOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBoxes.Count - 2; i++)
            {
                pictureBoxes.SetChildIndex(pictureBoxes[pictureBoxes.Count - 1], i);
            }
        }

        #endregion

        #region Generate

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PreviewForm(generateMergedImage()).Show();    
        }

        #endregion

        #endregion

        #region Non-Menu Mouse Click Events

        private void flowLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "All Files (*.*)|*.*|JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialog1.FileNames)
                {
                    Image image = Image.FromFile(filename);
                    addPictureBox(image);
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BackColor = SystemColors.Control;
            }
            selectedPictureBox = ((PictureBox)sender);
            selectedPictureBox.BackColor = Color.CadetBlue;
        }

        private void flowLayoutPanelMain_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BackColor = SystemColors.Control;
                selectedPictureBox = null;
            }
        }

        #endregion

        #region Keyboard Events

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //orderToolStripMenuItem.Text = "" +(int)e.KeyChar;
            switch (e.KeyChar)
            {
                case ((char)27):
                    this.Dispose();
                    this.Close();
                    Application.Exit();
                    break;
            }
        }

        private void ArrangerForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.O):
                    flowLayoutPanel1_DoubleClick(sender, e);
                    break;
                case (Keys.D):
                    clearWorkspaceCtrlDToolStripMenuItem_Click(sender, e);
                    break;
                case (Keys.I):
                    invertOrderToolStripMenuItem_Click(sender, e);
                    break;
                case (Keys.V):
                    if (isControlPressed)
                    {
                        pasteCtrlVToolStripMenuItem_Click(sender, e);
                    }
                    break;
                case (Keys.ControlKey):
                    isControlPressed = true;
                    break;
                case (Keys.Enter):
                    generateToolStripMenuItem_Click(sender, e);
                    break;
                case (Keys.Left):
                    if (selectedPictureBox != null)
                        moveItemLeft();
                    break;
                case (Keys.Right):
                    if (selectedPictureBox != null)
                        moveItemRight();
                    break;
                case (Keys.Delete):
                //intentional fallthrough
                case (Keys.Back):
                    pictureBoxes.Remove(selectedPictureBox);
                    selectedPictureBox = null;
                    if (this.pictureBoxes.Count == 0)
                    {
                        labelHelp.Visible = true;
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //orderToolStripMenuItem.Text = "" + e.KeyCode;

            switch (e.KeyCode)
            {
                case (Keys.ControlKey):
                    isControlPressed = false;
                    break;
                default: break;
            }
        }

        #endregion

        #region Other events

        private void ArrangerForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void ArrangerForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                try
                {
                    addPictureBox(Image.FromFile(file));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            flowLayoutPanelMain.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - this.menuStrip1.Height);
        }

        #endregion

        #endregion
    }
}
