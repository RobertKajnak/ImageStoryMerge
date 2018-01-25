using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoStoryMerge
{
    public partial class ArrangerForm : Form
    {
        System.Windows.Forms.Control.ControlCollection pictureBoxes;
        PictureBox selectedPictureBox;
        //bool isControlPressed = false;

        public ArrangerForm()
        {
            InitializeComponent();
            pictureBoxes = this.flowLayoutPanelMain.Controls;
        }

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

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
                /*case (Keys.Control):
                    isControlPressed = true;
                    break;*/
                case (Keys.Left):
                    if (selectedPictureBox != null)
                        moveItemLeft();
                    break;
                case (Keys.Right):
                    if (selectedPictureBox != null)
                        moveItemRight();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //orderToolStripMenuItem.Text = "" + e.KeyCode;

            switch (e.KeyCode)
            {
                /*case (Keys.Control):
                    isControlPressed = false;
                    break;*/
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
                default: break;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            Application.Exit();
        }
        
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            flowLayoutPanelMain.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height-this.menuStrip1.Height);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BackColor = SystemColors.Control;
            }
            selectedPictureBox = ((PictureBox)sender);
            selectedPictureBox.BackColor = Color.Aqua;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ((PictureBox)sender).Width = 10;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1_DoubleClick(sender, e);
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxes.Count < 2)
            {
                MessageBox.Show("Please add at least 2 images to merge", "Not enough images");
            }
            else
            {
                //new PreviewForm(pictureBoxes[0].Image).Show();
                new PreviewForm(generateMergedImage()).Show();
            }
        }
        
        private Image generateMergedImage()
        {
            int W =0, H = 0;
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
                    int w = im.Width==W?0:(W-im.Width)/2;

                    canvas.DrawImage(im, w, totalH);
                    totalH += h;
                }
                canvas.Save();
            }

            return merged;

        }

        private void moveLeftLeftArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveItemLeft();
        }

        private void moveRightRightArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveItemRight();
        }

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


    }
}
