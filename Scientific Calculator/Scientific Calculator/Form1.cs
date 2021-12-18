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
        Color normalButtonsColor = ColorTranslator.FromHtml("#1A1919");
        Color formBackColor = ColorTranslator.FromHtml("#2B2929");

        private bool isCollapsed;
        private bool isPanel1Showing = false;
        private bool isPanel2Showing = false;

        bool newEntry = false;
        bool flagFirstOperand = false;
        bool flagSecondOperand = false;

        double firstOperand;
        double secondOperand;
        double result;
        double memoryNumber = 0;

        string theOperator;

        public sciCal()
        {
            InitializeComponent();
        }

        private void sciCal_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnEquals;
            this.BackColor = formBackColor;

            panelSlidingMenu.BackColor = formBackColor;
            List<Button> MenuButtons = new List<Button> {
            btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6, btnMenu7, btnMenu8, btnMenu9, btnMenu10, btnMenu11, btnMenu12 };

            foreach (Button x in MenuButtons)
            {
                x.BackColor = formBackColor;
            }

            panelDropDown2.BackColor = normalButtonsColor;
            btnSin.BackColor = normalButtonsColor;
            btnCos.BackColor = normalButtonsColor;
            btnTan.BackColor = normalButtonsColor;
            btnSinh.BackColor = normalButtonsColor;
            btnCosh.BackColor = normalButtonsColor;
            btnTanh.BackColor = normalButtonsColor;

            foreach (Control x in Controls)
            {
                if (x.Tag == "ColorThisFormBackColor")
                {
                    x.BackColor = formBackColor;
                }
            }
            foreach (Control x in Controls)
            {
                if (x.Tag == "normalBtn")
                {
                    x.BackColor = normalButtonsColor;
                }
            }

            this.ShowIcon = false;
        }
       
        private void btnCE_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = "0";
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
            displayTxtBox.Text = Convert.ToString(Convert.ToDouble(displayTxtBox.Text) * Convert.ToDouble(displayTxtBox.Text));
        }

        private void btnCubed_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = Convert.ToString(Convert.ToDouble(displayTxtBox.Text) * Convert.ToDouble(displayTxtBox.Text) * Convert.ToDouble(displayTxtBox.Text));
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
            displayTxtBox.Text = Convert.ToString(Math.PI);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (displayTxtBox.Text[0] != '-' && displayTxtBox.Text != "0")
            {
                displayTxtBox.Text = (displayTxtBox.Text).Insert(0, "-");
            }
            else if (displayTxtBox.Text[0] == '-' && displayTxtBox.Text != "0")
            {
                displayTxtBox.Text = displayTxtBox.Text.Substring(1);
            }
        }

        private void btnDecimalPoint_Click(object sender, EventArgs e)
        {
            if (!displayTxtBox.Text.Contains(".") || newEntry)
                if (newEntry)
                {
                    displayTxtBox.Text = "0.";
                    newEntry = false;
                }
                else
                {
                    displayTxtBox.Text = displayTxtBox.Text + ".";
                }
        }

        //Operators
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
                secondOperand = Convert.ToDouble(displayTxtBox.Text);

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

                flagFirstOperand = false;
                flagSecondOperand = false;
            }
        }

        
        // Custom Functions
        private void OperationSetter()
        {
            firstOperand = Convert.ToDouble(displayTxtBox.Text);

            flagFirstOperand = true;
            newEntry = true;
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button numBtn = (Button)sender;

            if (newEntry || displayTxtBox.Text == "0")
            {
                displayTxtBox.Text = "";
                newEntry = false;
            }

            if (flagFirstOperand)
            {
                flagSecondOperand = true;
            }

            displayTxtBox.Text += numBtn.Text;
        }

        // Dec 6 and onwards

        private void btnSin_Click(object sender, EventArgs e)
        {
            double degrees = (Convert.ToDouble(displayTxtBox.Text) * Math.PI) / 180;
            displayTxtBox.Text = Convert.ToString(Math.Sin(degrees));
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            double degrees = (Convert.ToDouble(displayTxtBox.Text) * Math.PI) / 180;
            displayTxtBox.Text = Convert.ToString(Math.Cos(degrees));
        }

        private void btnAbs_Click(object sender, EventArgs e)
        {
            double absValue = Convert.ToDouble(displayTxtBox.Text);
            absValue = Math.Abs(absValue);
            displayTxtBox.Text = Convert.ToString(absValue);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            double degrees = (Convert.ToDouble(displayTxtBox.Text) * Math.PI) / 180;
            displayTxtBox.Text = Convert.ToString(Math.Tan(degrees));
        }

        //drop down panel functions
        private void btnTrigoDropdown_Click(object sender, EventArgs e)
        {
            if (!isPanel1Showing)
            {
                panelDropDown1.Visible = true;
                isPanel1Showing = true;
            } 
            else if (isPanel1Showing)
            {
                panelDropDown1.Visible = false;
                isPanel1Showing = false;
            }
        }

        private void btnModeDropdown_Click(object sender, EventArgs e)
        {
            if (!isPanel2Showing)
            {
                panelDropDown2.Visible = true;
                isPanel2Showing = true;
            }
            else if (isPanel2Showing)
            {
                panelDropDown2.Visible = false;
                isPanel2Showing = false;
            }
        }

        private void sciCal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                btnNum_Click(btn0, e);
            }
            else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                btnNum_Click(btn1, e);
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                btnNum_Click(btn2, e);
            }
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                btnNum_Click(btn3, e);
            }
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                btnNum_Click(btn4, e);
            }
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                btnNum_Click(btn5, e);
            }
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                btnNum_Click(btn6, e);
            }
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                btnNum_Click(btn7, e);
            }
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                btnNum_Click(btn8, e);
            }
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                btnNum_Click(btn9, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnEquals.PerformClick();
            }
            else if (e.KeyCode == Keys.Add)
            {
                btnPlus.PerformClick();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                btnMinus.PerformClick();
            }
            else if (e.KeyCode == Keys.Multiply)
            {
                btnTimes.PerformClick();
            }
            else if (e.KeyCode == Keys.Divide)
            {
                btnDivide.PerformClick();
            }
            else if (e.KeyCode == Keys.Decimal)
            {
                btnDecimalPoint.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
            {
                btnBackspace.PerformClick();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerSlidingMenu.Start();
        }

        private void timerSlidingMenu_Tick(object sender, EventArgs e)
        {
            

            if (isCollapsed)
            {
                panelSlidingMenu.Width += 40;
                if(panelSlidingMenu.Size == panelSlidingMenu.MaximumSize)
                {
                    timerSlidingMenu.Stop();
                    isCollapsed = false;

                    labelCalcuMode.Visible = false;
                }
            }
            else
            {
                panelSlidingMenu.Width -= 40;
                if (panelSlidingMenu.Size == panelSlidingMenu.MinimumSize)
                {
                    timerSlidingMenu.Stop();
                    isCollapsed = true;

                    labelCalcuMode.Visible = true;
                }
            }
        }

        private void btnOneOverX_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = Convert.ToString(1 / Convert.ToDouble(displayTxtBox.Text));
        }

        private void btnRadical_Click(object sender, EventArgs e)
        {
            displayTxtBox.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(displayTxtBox.Text)));
        }
    }
}
