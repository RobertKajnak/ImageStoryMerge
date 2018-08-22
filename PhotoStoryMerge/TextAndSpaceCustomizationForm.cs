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

        double heightPixelsCurrent = 0;
        

        public TextAndSpaceCustomizationForm()
        {
            InitializeComponent();
            textEditRichTextBox.Focus();
            this.ActiveControl = textEditRichTextBox;
        }

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


    }
}
