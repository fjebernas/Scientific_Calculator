﻿using System;
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
            this.ActiveControl = dummyButton;
        }

        bool newEntry = false;
        bool flagFirstOperand = false;
        bool flagSecondOperand = false;

        double firstOperand;
        double secondOperand;
        double result;
        double memoryNumber = 0;

        string theOperator;

       
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
            displayTxtBox.Text = "3.141592653589793";
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
    }
}
