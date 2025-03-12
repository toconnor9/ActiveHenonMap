using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveHenonMap
{
    public partial class frmInput: Form
    {
        public frmInput()
        {
            InitializeComponent();
        }


        public enum enDataType
        {
            String,
            Integer,
            Double,
            Date,
            DateTime,
            Time
        }

        public string Prompt { get; set; }
        public string Title { get; set; }
        public string DefaultValue { get; set; }
        public bool IsNumeric { get; set; }
        public enDataType ResultDataType { get; set; }
        public double MinimumValue { get; set; }
        public double MaximumValue { get; set; }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (ResultDataType == enDataType.Integer)
            {
                int result_value;

                if (int.TryParse(txtAnswer.Text, out result_value) == false)
                    return;

                if (result_value < MinimumValue)
                {
                    lblErrorMsg.Text = "Value is too small.";
                    timer1.Enabled = true;
                    return;
                }

                if (result_value > MaximumValue)
                {
                    lblErrorMsg.Text = "Value is too large.";
                    timer1.Enabled = true;
                    return;
                }
            }
            if (ResultDataType == enDataType.Double)
            {
                double dblResult;

                if (double.TryParse(txtAnswer.Text, out dblResult) == false)
                    return;

                if (dblResult < MinimumValue)
                {
                    lblErrorMsg.Text = "Value is too small.";
                    timer1.Enabled = true;
                    return;
                }

                if (dblResult > MaximumValue)
                {
                    lblErrorMsg.Text = "Value is too large.";
                    timer1.Enabled = true;
                    return;
                }
            }

            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
        }

        private void frmInput_Shown(object sender, EventArgs e)
        {
            lblPrompt.Text = this.Prompt;
            this.Text = this.Title;
            txtAnswer.Text = this.DefaultValue;

            if (this.IsNumeric)
                txtAnswer.TextAlign = HorizontalAlignment.Right;
            else
                txtAnswer.TextAlign = HorizontalAlignment.Left;
        }

        public string ValueGiven()
        {
            return txtAnswer.Text;
        }
    }
}
