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

        bool newEntry = false;
        bool flagFirstOperand = false;
        bool flagSecondOperand = false;

        double firstOperand;
        double secondOperand;
        double result;
        double memoryNumber = 0;

        string theOperator;

        /* --------------------Button Functions(below)-------------------- */

        /* ---- NUMBERS(below) ---- */
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
        /* ---- NUMBERS(above) ---- */

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

        private void btnMS_Click(object sender, EventArgs e)
        {
            memoryNumber = Convert.ToDouble(displayTxtBox.Text);
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = Convert.ToString(memoryNumber);
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memoryNumber = 0;
        }

        private void btnMadd_Click(object sender, EventArgs e)
        {
            memoryNumber += Convert.ToDouble(displayTxtBox.Text);
        }

        private void btnMsub_Click(object sender, EventArgs e)
        {
            memoryNumber -= Convert.ToDouble(displayTxtBox.Text);
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = "3.141592653589793";
        }

        /* ---- OPERATORS(below) ---- */
        private void btnPlus_Click(object sender, EventArgs e)
        {
            OperationSetter();
            theOperator = "+";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            OperationSetter();
            theOperator = "-";
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            OperationSetter();
            theOperator = "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            OperationSetter();
            theOperator = "/";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (flagFirstOperand && flagSecondOperand)
            {
                secondOperand = Convert.ToInt32(displayTxtBox.Text);

                if (flagFirstOperand && flagSecondOperand)
                {
                    switch (theOperator)
                    {
                        case "+":
                            result = firstOperand + secondOperand;
                            displayTxtBox.Text = Convert.ToString(result);
                            break;

                        case "-":
                            result = firstOperand - secondOperand;
                            displayTxtBox.Text = Convert.ToString(result);
                            break;

                        case "*":
                            result = firstOperand * secondOperand;
                            displayTxtBox.Text = Convert.ToString(result);
                            break;

                        case "/":
                            result = firstOperand / secondOperand;
                            displayTxtBox.Text = Convert.ToString(result);
                            break;

                        default:
                            displayTxtBox.Text = displayTxtBox.Text;
                            break;
                    }

                    flagSecondOperand = false;
                }
            }
        }
        /* ---- OPERATORS(above) ---- */

        /* --------------------Button Functions(above)-------------------- */

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

            if (flagFirstOperand)
            {
                flagSecondOperand = true;
            }

            displayTxtBox.Text += num;
        }

        private void OperationSetter()
        {
            firstOperand = Convert.ToInt32(displayTxtBox.Text);

            flagFirstOperand = true;
            newEntry = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = "0";
            firstOperand = 0;
            secondOperand = 0;

            flagFirstOperand = false;
            flagSecondOperand = false;
            newEntry = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show(" Quit Calculator?       ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }
    }
}
