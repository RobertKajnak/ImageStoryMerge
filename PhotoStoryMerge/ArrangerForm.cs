using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        private void openOpenFileDialog()
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
                    Image image = ImageFromFile(filename);
                    addPictureBox(image);
                }
            }
        }

        private void pasteItem()
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
                        addPictureBox(ImageFromFile(v));
                    }
                    catch
                    {
                        Console.WriteLine("Text does not lead do a valid image file");
                    }
                }
            }
        }

        private void addBlankSpace(int width, int height)
        {

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

        private void removePictureBox()
        {
            if (selectedPictureBox != null)
            {
                pictureBoxes.Remove(selectedPictureBox);
                selectedPictureBox.Image.Dispose();
                selectedPictureBox.Dispose();
                selectedPictureBox = null;
                if (this.pictureBoxes.Count == 0)
                {
                    labelHelp.Visible = true;
                }
            }
            else
            {
                if (pictureBoxes.Count > 0)
                {
                    selectPictureBox((PictureBox)pictureBoxes[0]);
                }
            }
        }

        private void clearWorkspace()
        {
            selectedPictureBox = null;
            pictureBoxes.Clear();
            System.GC.Collect();
            labelHelp.Visible = true;
        }

        private void selectPictureBox(PictureBox pb)
        {
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BackColor = SystemColors.Control;
            }
            selectedPictureBox = (pb);
            selectedPictureBox.BackColor = Color.CadetBlue;
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
            else
            {
                if (pictureBoxes.Count > 0)
                {
                    selectPictureBox((PictureBox)pictureBoxes[pictureBoxes.Count - 1]);
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
            else
            {
                if (pictureBoxes.Count > 0)
                {
                    selectPictureBox((PictureBox)pictureBoxes[0]);
                }
            }
        }

        private void invertOrder()
        {
            for (int i = 0; i < pictureBoxes.Count - 2; i++)
            {
                pictureBoxes.SetChildIndex(pictureBoxes[pictureBoxes.Count - 1], i);
            }
        }

        private void generateTextImage()
        {
            TextAndSpaceCustomizationForm textCustomizer = new TextAndSpaceCustomizationForm();
            if (textCustomizer.ShowDialog() != DialogResult.Cancel)
            {
                Bitmap generatedText = textCustomizer.GetTextImage();
                addPictureBox(generatedText);
            }

        }

        private void sendGeneratedImage()
        {
            if (pictureBoxes.Count < 1)
            {
                MessageBox.Show("Please add at least one images to merge", "Not enough images");
            }
            else
            {
                new PreviewForm(generateMergedImage()).Show();
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
                canvas.CompositingQuality = CompositingQuality.HighQuality;
                canvas.SmoothingMode = SmoothingMode.HighQuality;
                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                int totalH = 0;
                foreach (var v in pictureBoxes)
                {
                    PictureBox pb = (PictureBox)v;
                    Image im = pb.Image;
                    int h = im.Height;
                    int w = im.Width == W ? 0 : (W - im.Width) / 2;

                    ///appearantly for 1 pixel == 1 pixel to be true, 96DPI is necessary... 
                    if (ignoreDPIToolStripMenuItem.Checked)
                    {
                        Rectangle rect = new Rectangle(w, totalH, im.Width, im.Height);
                        canvas.DrawImage(im, rect , 0, 0, im.Width, im.Height, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        canvas.DrawImage(im, w, totalH);
                    }                  
                    
                    totalH += h;
                }
                canvas.Save();
            }

            return merged;

        }
         
        private Image ImageFromFile(string path)
        {
            Image image = null;
            if (lockLoadFilesToolStripMenuItem.Checked)
            {
                image = Image.FromFile(path);
            }
            else
            {
                image = LoadImage(path);
            }
            return image;
        }

        /// <summary>
        /// Loads the bitmap from file, copies it, than releases the file resource
        /// </summary>
        /// <param name="path">Path to the image file</param>
        /// <returns></returns>
        static Bitmap LoadImage(string path)
        {
            Bitmap img = null;

            using (Bitmap b = new Bitmap(path))
            {
                img = new Bitmap(b.Width, b.Height, b.PixelFormat);
                img.SetResolution(b.HorizontalResolution, b.VerticalResolution);
                //img.Palette = b.Palette; -- clears the image. Maybe not loaded properly? Oh, well
                img.Tag = b.Tag;
                                
                using (Graphics g = Graphics.FromImage(img))
                {
                    g.DrawImage(b, 0,0);
                    g.Flush();
                }
            }

            return img;
        }

        /// <summary>
        /// Creates a copy of the image, but uses the new DPI values
        /// </summary>
        /// <param name="image">The old Image</param>
        /// <param name="xDPI">The new horizontal DPI</param>
        /// <param name="yDPI">The new vertical DPI</param>
        /// <returns>The new image</returns>
        public static Bitmap ChangeDPI(Image image, float xDPI, float yDPI)
        {
            var destRect = new Rectangle(0, 0, image.Width, image.Height);
            var destImage = new Bitmap(image.Width, image.Height);
            destImage.SetResolution(xDPI, yDPI);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            destImage.SetResolution(xDPI, yDPI);

            return destImage;
        }

        #endregion

        #region Event Handlers

        #region Menu Events

        #region File

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOpenFileDialog();
        }

        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteItem();
        }

        private void clearWorkspaceCtrlDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearWorkspace();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            Application.Exit();
        }

        #endregion

        #region Insert

        private void blankSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateTextImage();
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
            invertOrder();
        }

        #endregion

        #region Generate

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendGeneratedImage();
        }

        #endregion

        #region Help
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = "Quick and easy way of creating a compilation/story from distinct images.\n"+
                "Offers the possibility to rescale the image after generation, should it be necessary.\n"+
                "\n\n"+
                "The Ignore DPI feature (on by default) only consideres the resolution of the images on compositing.\n"+
                "Disabling it will scale the images based on DPI, 1:1 pixel ratio being at 96DPI (value comes from Visual Studio or Microsoft or sthg).\n"+
                "For example: putting a 182 DPI image with 800*600 pixels will result in an image with 400*300 pixels.\n"+
                "\n\n"+
                "\"Lock-Load Files\" locks the added files to the application so they can't be modified externally.\n"+
                "Might fix some issues with some wierder file configurations, but is usually not necessary. "+
                "Only has effect on files added after changing the option (i.e. does not reload files already inside the application)\n"+
                "\n\n"+
                "To report any bugs of issues visit the repo: \n"+
                "https://github.com/RobertKajnak/ImageStoryMerge";
            String caption = "Help/About";
            MessageBox.Show(text, caption);
        }
        #endregion

        #endregion

        #region Non-Menu Mouse Click Events

        private void flowLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            openOpenFileDialog();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            selectPictureBox((PictureBox)sender);
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
                    openOpenFileDialog();
                    break;
                case (Keys.D):
                    clearWorkspace();
                    break;
                case (Keys.I):
                    invertOrder();
                    break;
                case (Keys.T):
                    generateTextImage();
                    break;
                case (Keys.V):
                    if (isControlPressed)
                    {
                        pasteItem();
                    }
                    break;
                case (Keys.ControlKey):
                    isControlPressed = true;
                    break;
                case (Keys.Enter):
                    sendGeneratedImage();
                    break;
                case (Keys.Left):
                    moveItemLeft();
                    break;
                case (Keys.Right):
                    moveItemRight();
                    break;
                case (Keys.Delete):
                //intentional fallthrough
                case (Keys.Back):
                    removePictureBox();
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
                    addPictureBox(ImageFromFile(file));
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
