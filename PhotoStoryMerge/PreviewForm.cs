using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoStoryMerge
{
    public partial class PreviewForm : Form
    {
        bool isControlPressed = false;

        public PreviewForm(Image image)
        {
            InitializeComponent();
            pictureBox.Image = image;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Portable network graphics format|*.png|Joint Photographic Experts Group format|*.jpg|Bitmap Image fomrat|*bmp|Images|*.png;*.bmp;*.jpg";
                ImageFormat format = ImageFormat.Png;
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pictureBox.Image.Save(sfd.FileName, format);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            int W = Screen.PrimaryScreen.Bounds.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
            int w = pictureBox.Size.Width;
            int h = pictureBox.Size.Height;
            double p = 0.85; // maximum percentage available
            if (w < W * p)
            {
                 changeWidth(w + 20);
            }
            else
            {
                changeWidth( Convert.ToInt16(W * p));
            }

            if (h < H * p)
            {
                changeHeight( h + 20);
            }
            else
            {
                changeHeight( Convert.ToInt16(H * p));
            }
        }

        private void changeWidth(int newWidth)
        {
            this.Width = newWidth;
            flowLayoutPanel.Width = newWidth-17;
        }
        private void changeHeight(int newHeight)
        {
            this.Height = newHeight;
            flowLayoutPanel.Height = newHeight - menuStrip.Height-42;
        }

        private void PreviewForm_Resize(object sender, EventArgs e)
        {
            changeHeight(this.Height);
            changeWidth(this.Width);
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

        private void PreviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.S):
                case (Keys.Enter):
                    if (isControlPressed)
                        saveToolStripMenuItem_Click(sender, e);
                    break;
                case (Keys.ControlKey):
                    isControlPressed = true;
                    break;
            }
        }

        private void PreviewForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.ControlKey):
                    isControlPressed = false;
                    break;
            }
        }
    }
    
}
