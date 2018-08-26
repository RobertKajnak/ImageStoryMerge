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
    public partial class TextAndSpaceCustomizationForm : Form
    {
        bool isShiftPressed = false;

        int heightPixelsCurrent = 0;
        int widthPixelsCurrent = 0;
        double textScaleFactor = 20;
        Color backColorCurrent = Color.Black;
        Color foreColorCurrent = Color.White;

        public TextAndSpaceCustomizationForm()
        {
            InitializeComponent();
            textEditRichTextBox.Focus();
            RotateButton(buttonFontSelect,RotateFlipType.Rotate90FlipNone);
            this.ActiveControl = textEditRichTextBox;

            heightPixelsCurrent = (int) (textEditRichTextBox.Font.Size * textScaleFactor);
            widthPixelsCurrent = (int) (textEditRichTextBox.Font.Size * textScaleFactor);

            

        }

        #region Special
        public void RotateButton(Button button, RotateFlipType rotation)
        {
            Bitmap img = GenerateBMPWithText(button.Height, button.Width, button.BackColor, button.Text, button.Font,button.ForeColor);

            img.RotateFlip(rotation);
            button.Text = "";
            button.BackgroundImage = img;
        }

        private Bitmap GenerateBMPWithText(int width,int height,Color background,string text,Font font, Color foreColor)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
            Bitmap img = new Bitmap(width, height);
            Graphics G = Graphics.FromImage(img);

            G.Clear(background);

            SolidBrush brush_text = new SolidBrush(foreColor);
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            G.DrawString(text, font, brush_text, new Rectangle(0, 0, img.Width, img.Height), format);
            brush_text.Dispose();

            return img;
        }

        public Bitmap GetTextImage()
        {
            return GenerateBMPWithText(widthPixelsCurrent, heightPixelsCurrent,
                backColorCurrent, textEditRichTextBox.Text, textEditRichTextBox.Font, foreColorCurrent);
        }
        #endregion

        #region Logic
        private void FilterNonDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void returnSuccess()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Events
        private void heightPixelsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterNonDigits(sender, e);
        }
        #endregion

        private void heightTextMultipleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterNonDigits(sender, e);
        }

        private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterNonDigits(sender, e);
        }

        private void textBoxScalingFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterNonDigits(sender, e);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            returnSuccess();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        #region Keyboard Events

        private void TextAndSpaceCustomizationForm_KeyPress(object sender, KeyPressEventArgs e)
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
        

        private void TextAndSpaceCustomizationForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Enter):
                    if (isShiftPressed)
                        returnSuccess();
                    break;
                case (Keys.ShiftKey):
                    isShiftPressed = true;
                    break;
            }
        }

        private void TextAndSpaceCustomizationForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.ShiftKey):
                    isShiftPressed= false;
                    break;
            }
        }


        #endregion


        private void radioButtonCustomHeight_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                heightTextMultipleTextBox.Enabled = true;
            }
            else
            {
                heightTextMultipleTextBox.Enabled = false;
            }
            groupRadioHeight_CheckedChanged(sender, e);
        }

        private void radioButtonTextHeightPixels_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                heightPixelsTextBox.Enabled = true;
            }
            else
            {
                heightPixelsTextBox.Enabled = false;
            }

            groupRadioHeight_CheckedChanged(sender, e);
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupRadioHeight_CheckedChanged(object sender, EventArgs e)
        {
            heightPixelsTextBox.Text = heightPixelsCurrent.ToString();
            heightTextMultipleTextBox.Text = (heightPixelsCurrent / (double)textEditRichTextBox.Font.Size).ToString();

        }

        private void groupRadioWeight_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonWidthCustom_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                widthTextBox.Enabled = true;
            }
            else
            {
                widthTextBox.Enabled = false;
            }

            groupRadioWeight_CheckedChanged(sender, e);
        }

        private void radioButtonBlank_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                textEditRichTextBox.Enabled = false;
            }
            else
            {
                textEditRichTextBox.Enabled = true;
            }
        }

        private void buttonFontSelect_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                textEditRichTextBox.Font = fontDlg.Font;
            }
        }

        private void checkBoxTextScale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTextScale.CheckState == CheckState.Checked)
            {
                textBoxScalingFactor.Enabled = true;
            }
            else
            {
                textBoxScalingFactor.Enabled = false;
            }
        }

        private void radioButtonTextHeight2_CheckedChanged(object sender, EventArgs e)
        {
            groupRadioHeight_CheckedChanged(sender, e);
        }

        private void radioButtonTextHeight4_CheckedChanged(object sender, EventArgs e)
        {
            groupRadioHeight_CheckedChanged(sender, e);
        }

        private void heightTextMultipleTextBox_TextChanged(object sender, EventArgs e)
        {
            //heightPixelsCurrent = 
        }

        private void heightPixelsTextBox_TextChanged(object sender, EventArgs e)
        { 
            //heightPixelsCurrent = 
        }

        private void textBoxScalingFactor_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
