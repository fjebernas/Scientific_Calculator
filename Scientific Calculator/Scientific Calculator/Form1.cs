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

        bool doPlus = false;
        bool doOperator = false;
        bool newEntry = false;
        int firstOperand;
        int secondOperand;
        int result;

        /* --------------------Button Functions-------------------- */
        private void btn1_Click(object sender, EventArgs e)
        {
            NumberPressed("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            NumberPressed("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            NumberPressed("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            NumberPressed("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            NumberPressed("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            NumberPressed("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            NumberPressed("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            NumberPressed("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            NumberPressed("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            NumberPressed("0");
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = "0";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (displayTxtBox.Text.Length > 1)
            {
                displayTxtBox.Text = displayTxtBox.Text.Substring(0, displayTxtBox.Text.Length - 1);
            } else if (displayTxtBox.Text.Length == 1)
            {
                displayTxtBox.Text = "0";
            }
        }

        private void btnSquared_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = Convert.ToString(Convert.ToInt32(displayTxtBox.Text) * Convert.ToInt32(displayTxtBox.Text));
        }

        private void btnCubed_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = Convert.ToString(Convert.ToInt32(displayTxtBox.Text) * Convert.ToInt32(displayTxtBox.Text) * Convert.ToInt32(displayTxtBox.Text));
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = "3.141592653589793";
        }
        /* --------------------Button Functions-------------------- */

        private void NumberPressed(string num)
        {
            if (newEntry)
            {
                displayTxtBox.Text = "0";
                newEntry = false;
            }

            if (displayTxtBox.Text == "0")
            {
                displayTxtBox.Text = "";
            }

            displayTxtBox.Text += num;

            if (doOperator)
            {
                secondOperand = Convert.ToInt32(displayTxtBox.Text);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            firstOperand = Convert.ToInt32(displayTxtBox.Text);
            newEntry = true;
            doOperator = true;
            doPlus = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            
            if (doPlus)
            {
                result = firstOperand + secondOperand;
                displayTxtBox.Text = Convert.ToString(result);
            }

        }
    }
}
