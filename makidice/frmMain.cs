using System;
using System.Windows.Forms;

namespace makidice
{
    public partial class frmMain : Form
    {
        frmAbout AboutBox = new frmAbout();
        frmD10 D10 = new frmD10();

        public frmMain()
        {
            InitializeComponent();
        }

        int editSide = 1;
        int resetInput = 1;
        string leftValue = "";
        string rightValue = "";

        private void quickRoll(int diceType)
        {
            Random roll = new Random();
            int resultValue = roll.Next(diceType) + 1;
            this.lblResult.Text = resultValue.ToString();

        }

        private void btn1d4_Click(object sender, EventArgs e)
        {
            quickRoll(4);
        }

        private void btn1d6_Click(object sender, EventArgs e)
        {
            quickRoll(6);
        }

        private void btn1d8_Click(object sender, EventArgs e)
        {
            quickRoll(8);
        }

        private void btn1d10_Click(object sender, EventArgs e)
        {
            quickRoll(10);
        }

        private void btn1d12_Click(object sender, EventArgs e)
        {
            quickRoll(12);
        }

        private void btn1d20_Click(object sender, EventArgs e)
        {
            quickRoll(20);
        }

        private void btn1d100_Click(object sender, EventArgs e)
        {
            quickRoll(100);
        }

        private void setRight(int buttonValue)
        {
            if (rightValue == "")
            {
                rightValue = rightValue + buttonValue.ToString();
                lblResult.Text = leftValue + "d" + rightValue;
            }
            else if (int.Parse(rightValue) < 1000)
            {
                rightValue = rightValue + buttonValue.ToString();
                lblResult.Text = leftValue + "d" + rightValue;
            }
        }

        private void setLeft(int buttonValue)
        {
            if (resetInput == 1)
            {
                leftValue = "";
                rightValue = "";
                resetInput = 0;
            }
            if (leftValue == "")
            {
                leftValue = leftValue + buttonValue.ToString();
                lblResult.Text = leftValue;
            }
            else if (int.Parse(leftValue) < 1000)
            {
                leftValue = leftValue + buttonValue.ToString();
                lblResult.Text = leftValue;
            }
        }

        private void appendDigit(int buttonValue)
        {
            if (editSide == 1)
            {
                setLeft(buttonValue);
            }
            if (editSide == 2)
            {
                setRight(buttonValue);
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (editSide == 1 && resetInput == 0)
            {
                editSide = 2;
                lblResult.Text = leftValue + "d";
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (leftValue != "" && rightValue != "")
            {
                int leftValueInt = int.Parse(leftValue);
                int rightValueInt = int.Parse(rightValue);
                int resultValue = 0;
                Random roll = new Random();
                for (int i = 0; i < leftValueInt; i++)
                {
                    resultValue = resultValue + roll.Next(rightValueInt) + 1;
                }
                this.lblResult.Text = resultValue.ToString();
                editSide = 1;
                resetInput = 1;

            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            appendDigit(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            appendDigit(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            appendDigit(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            appendDigit(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            appendDigit(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            appendDigit(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            appendDigit(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            appendDigit(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            appendDigit(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (editSide == 1)
            {
                if (leftValue != "" && resetInput == 0)
                {
                    appendDigit(0);
                }
            }
            if (editSide == 2)
            {
                if (rightValue != "" && resetInput == 0)
                {
                    appendDigit(0);
                }
            }

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox.ShowDialog();
        }

        private void btnD10_Click(object sender, EventArgs e)
        {
            D10.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editSide = 1;
            leftValue = "";
            rightValue = "";
            this.lblResult.Text = "";
        }
    }
}
