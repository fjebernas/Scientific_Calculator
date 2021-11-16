using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scientific_Calculator
{
    public partial class sciCal : Form
    {
        public sciCal()
        {
            InitializeComponent();
        }

        private void sciCal_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (displayTxtBox.Text == "0")
            ClearScreen();

            displayTxtBox.Text = displayTxtBox.Text + "1";
        }

        private void ClearScreen()
        {
            displayTxtBox.Text = "";
        }
    }
}
