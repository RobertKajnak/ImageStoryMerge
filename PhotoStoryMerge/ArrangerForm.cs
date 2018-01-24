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
        List<PictureBox> pictureBoxes;
        PictureBox selectedPictureBox;

        public ArrangerForm()
        {
            InitializeComponent();
            pictureBoxes = new List<PictureBox>();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPG Image Files|*.jpg|PNG Image Files|*.png|TIFF Image Files|*.tiff|Icon|*.ico|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                addPictureBox(image);
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

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //orderToolStripMenuItem.Text = "" + e.KeyCode;

            switch (e.KeyCode)
            {
                case (Keys.Delete):
                    //intentional fallthrough
                case (Keys.Back):
                    pictureBoxes.Remove(selectedPictureBox);
                    flowLayoutPanelMain.Controls.Remove(selectedPictureBox);
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

            flowLayoutPanelMain.Controls.Add(pictureBox);
            pictureBoxes.Add(pictureBox);
            
            this.flowLayoutPanelMain.ResumeLayout(false);

            return pictureBox;
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
                new PreviewForm(pictureBoxes[0].Image).Show();
            }
        }
    }
}
