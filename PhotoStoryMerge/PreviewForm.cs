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
        Size originalSize;

        // maximum percentage available of screen resolution on resize
        double p = 0.85; 

        public PreviewForm(Image image)
        {
            InitializeComponent();
            pictureBox.Image = image;

            ///this is relevant for the zooming, but not resizing section
            ///<see cref="zoomInCtrlScrollUpToolStripMenuItem_Click(object, EventArgs)"/>
            ///this way, the image is loaded immediately rescaled. Using the zoom by default and then changing
            ///the image would result in it loading in a small factor than rescaling. Loading the image 
            ///first, rescaling box, then displaying it would require modifying InitializeComponent(), which
            ///is I would rather not, both for cleanliness and safety
            originalSize = new Size(image.Size.Width, image.Size.Height);
            pictureBox.Size = new Size(image.Size.Width, image.Size.Height);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
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
            if (w < W * p)
            {
                int scrollBarCorrection = 40;
                ///menustrip is not detected in scroll height for some reason
                if (pictureBox.Height /*+ menuStrip.Height*/ > H)
                    scrollBarCorrection -= 20;
                changeWidth(w + scrollBarCorrection);
            }
            else
            {
                changeWidth( Convert.ToInt16(W * p));
            }

            if (h < H * p)
            {
                changeHeight( h -30);
            }
            else
            {
                changeHeight( Convert.ToInt16(H * p));
            }
        }

        private void changeWidth(int newWidth)
        {
            if (newWidth > 250)
            {
                this.Width = newWidth;
                int scrollBarCorrection = 0;
                if (pictureBox.Height > this.Height - 42)
                    scrollBarCorrection += 17;
                
                flowLayoutPanel.Width = newWidth - scrollBarCorrection;
            }
        }
        private void changeHeight(int newHeight)
        {
            if (newHeight > 200)
            {
                this.Height = newHeight;
                flowLayoutPanel.Height = newHeight - menuStrip.Height - 42;
            }
        }

        private void PreviewForm_Resize(object sender, EventArgs e)
        {
            /*int W = Screen.PrimaryScreen.Bounds.Width;
            int w = pictureBox.Size.Width;
            int H = Screen.PrimaryScreen.Bounds.Height;
                        
            int scrollBarCorrection = 40;
            ///menustrip is not detected in scroll height for some reason
            if (pictureBox.Height > H)
                scrollBarCorrection -= 20;
            changeWidth(w + scrollBarCorrection);*/
        
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
                case (Keys.Z):
                    zoomToToolStripMenuItem_Click(sender,e);
                    break;
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
        ///TODO fix annoying thing with srollbars when zooming
        ///TODO add resize functionality
        ///TODO fix bug with background.png
        private void zoomOutCtrlScrollUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setZoomTo(.8, false);
        }

        /// <summary>
        /// Changes the current zoom level/picturebox size
        /// </summary>
        /// <param name="percentage">in decimals (e.g. 100% == 1)</param>
        /// <param name="ofOriginal">true == percantege*original size ; false== percentage of current size</param>
        private void setZoomTo(double percentage, bool ofOriginal)
        {
            if (percentage == 0 || percentage > 20)
                return;
            int w, h;
            if (ofOriginal)
            {
                w = originalSize.Width;
                h = originalSize.Height;
            }
            else
            {
                w = pictureBox.Size.Width;
                h = pictureBox.Size.Height;
            }
            int newW = Convert.ToInt32(w * percentage);
            int newH = Convert.ToInt32(h * percentage);
            int maxW = originalSize.Width * 8;
            int maxH = originalSize.Height * 8;
            int minH = 100;
            int minW = 100;
            if (percentage < 1)
            {
                if (newW > minW && newH > minH)
                {
                    ///.8 and 1.25 so that the dimensions keep the same and zoomLevel works properly
                    pictureBox.Size = new Size(newW,newH );
                }
                else
                {
                    if (newW < newH)
                    {
                        pictureBox.Size = new Size(minW, minW*newH/newW);
                    }
                    else
                    {
                        pictureBox.Size = new Size(minH * newW / newH, minH) ;
                    }
                }
            }
            else if (percentage > 1)
            {
                ///this prevents some bug when increasing the size too much and edges are added to the flowlayout
                if (newH < maxH && newW < maxW)
                {
                    pictureBox.Size = new Size(newW, newH);
                }
                else
                {
                    pictureBox.Size = new Size(maxW, maxH);
                }
            }
            else
            {
                pictureBox.Size = new Size(w, h);
            }
        }

        private void zoomInCtrlScrollUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setZoomTo(1.25, false);
        }

        private void PreviewForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (isControlPressed)
            {
                if (e.Delta > 0)
                {
                    setZoomTo(1.25, false);
                }
                ///just in case there was an other event like click or somethign unpredicted
                else if (e.Delta < 0)
                {
                    setZoomTo(.8, false);
                }
            }
        }

        private void zoomToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zoom = Prompt.ShowDialog("Set zoom to (%):", "Custom Zoom");
            setZoomTo(Double.Parse(zoom)/100, true);
        }

        private void resetZoomToActualSizeCtrlMiddleClickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setZoomTo(1, true);
        }
        private void scaleUpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void flowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                setZoomTo(1, true);
            }
        }


        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }


}
