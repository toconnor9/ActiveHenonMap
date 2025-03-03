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
    public partial class frmPopUp : Form
    {
        public string TextToShow { get; set; }
        public string TitleOfBox { get; set; }


        public frmPopUp()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmPopUp_Shown(object sender, EventArgs e)
        {
            txtBox.Text = TextToShow;
            this.Text = TitleOfBox;
        }
    }
}
