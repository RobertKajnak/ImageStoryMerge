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
    public partial class PreviewForm : Form
    {
        public PreviewForm(Image image)
        {
            InitializeComponent();
            pictureBox.Image = image;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void PreviewForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //orderToolStripMenuItem.Text = "" +(int)e.KeyChar;
            switch (e.KeyChar)
            {
                case ((char)27):
                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            int w = pictureBox.Size.Width;
            int h = pictureBox.Size.Height;
            if (w < W * .8)
            {
                this.Width = w + 20;
            }
            else
            {
                this.Width = Convert.ToInt16(w * 0.8);
            }

            if (h < H * .8)
            {
                this.Height = h + 20;
            }
            else
            {
                this.Height = Convert.ToInt16(h * .8);
            }
        }
    }
    
}
