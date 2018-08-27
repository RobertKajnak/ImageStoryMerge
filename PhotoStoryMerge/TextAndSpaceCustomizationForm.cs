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
            return GenerateBMPWithText(widthPixelsCurrent, heightPixelsCurrent, buttonBackgroundColor.BackColor,
                textEditRichTextBox.Text, textEditRichTextBox.Font, buttonForegroundColor.BackColor);
        }
        #endregion

        #region Logic
        private void FilterNonDigits(object sender, KeyPressEventArgs e, bool allowDecimal = true)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.' && allowDecimal))
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
            FilterNonDigits(sender, e, allowDecimal:false);
        }
        #endregion

        private void heightTextMultipleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterNonDigits(sender, e);
        }

        private void widthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FilterNonDigits(sender, e, allowDecimal:false);
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


        /// <summary>
        /// This is intended as a sure-fire method for text changed, 
        /// in case the contents of the text field are changed through non-keypress methods
        /// 
        /// </summary>
        /*class ValidNumber
        {
            int valueInt;
            double valueDouble;
            bool allowNegative = false;
            bool allowZero = false;
            bool allowDecimal = false;

            public ValidNumber(bool allowNegative = false, bool allowZero = false, bool allowDecimal = false)
            {
                this.allowDecimal = allowDecimal;
                this.allowZero = allowZero;
                this.allowNegative = allowNegative;
            }

            private (string, int) verifyInt(string text)
            {
                
            }

            private string verifyDouble(string text)
            {

            }
        }*/

        /*private string ValidateText(string textField, string oldValue, ref double validatedValue,
         bool allowNegative = false, bool allowZero = false)
        {

        }*/
        /*private string ValidateText(ref string textField, string oldValue,ref double validatedValue, 
                 bool allowNegative = false, bool allowZero = false)
        {
            try
            {
                validatedValue = int.Parse(textField);
                if (!allowNegative && validatedValue < 0)
                    throw new ArgumentOutOfRangeException("Value less than 0 not allowed");
                if (!allowZero && validatedValue == 0)
                    throw new ArgumentOutOfRangeException("Value == 0 not allowed");
                oldValue = textField;
            }
            catch
            {
                MessageBox.Show("Only positive integer values are allowed", "Invalid text detected in width field");
                textField = widthTextBoxPreviousText;
            }
            return textField;
        }

        (string, int) widthTextBoxPreviousText = "";*/
        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            //widthTextBox.Text = ValidateText(ref widthTextBox.Text, widthTextBoxPreviousText, ref widthPixelsCurrent);

            
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
                textBoxScalingFactor.Text = "1.0";
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

        private void buttonBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(); 
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonBackgroundColor.BackColor = colorDialog.Color;
            }
        }

        private void buttonForegroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonForegroundColor.BackColor = colorDialog.Color;
            }
        }
    }
}
