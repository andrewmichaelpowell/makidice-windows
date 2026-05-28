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

        int Side = 1;
        int Reset = 1;
        string LeftValue = "";
        string RightValue = "";

        private void QuickRoll(int DiceType)
        {
            Random Roll = new Random();
            int Result = Roll.Next(DiceType) + 1;
            this.lblResult.Text = Result.ToString();

        }

        private void btn1d4_Click(object sender, EventArgs e)
        {
            QuickRoll(4);
        }

        private void btn1d6_Click(object sender, EventArgs e)
        {
            QuickRoll(6);
        }

        private void btn1d8_Click(object sender, EventArgs e)
        {
            QuickRoll(8);
        }

        private void btn1d10_Click(object sender, EventArgs e)
        {
            QuickRoll(10);
        }

        private void btn1d12_Click(object sender, EventArgs e)
        {
            QuickRoll(12);
        }

        private void btn1d20_Click(object sender, EventArgs e)
        {
            QuickRoll(20);
        }

        private void btn1d100_Click(object sender, EventArgs e)
        {
            QuickRoll(100);
        }

        private void SetRight(int ButtonValue)
        {
            if (RightValue == "")
            {
                RightValue = RightValue + ButtonValue.ToString();
                lblResult.Text = LeftValue + "d" + RightValue;
            }
            else if (int.Parse(RightValue) < 1000)
            {
                RightValue = RightValue + ButtonValue.ToString();
                lblResult.Text = LeftValue + "d" + RightValue;
            }
        }

        private void SetLeft(int ButtonValue)
        {
            if (Reset == 1)
            {
                LeftValue = "";
                RightValue = "";
                Reset = 0;
            }
            if (LeftValue == "")
            {
                LeftValue = LeftValue + ButtonValue.ToString();
                lblResult.Text = LeftValue;
            }
            else if (int.Parse(LeftValue) < 1000)
            {
                LeftValue = LeftValue + ButtonValue.ToString();
                lblResult.Text = LeftValue;
            }
        }

        private void AddValueToSide(int ButtonValue)
        {
            if (Side == 1)
            {
                SetLeft(ButtonValue);
            }
            if (Side == 2)
            {
                SetRight(ButtonValue);
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (Side == 1 && Reset == 0)
            {
                Side = 2;
                lblResult.Text = LeftValue + "d";
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (LeftValue != "" && RightValue != "")
            {
                int LeftValueInt = int.Parse(LeftValue);
                int RightValueInt = int.Parse(RightValue);
                int Result = 0;
                Random RollValue = new Random();
                for (int i = 0; i < LeftValueInt; i++)
                {
                    Result = Result + RollValue.Next(RightValueInt) + 1;
                }
                this.lblResult.Text = Result.ToString();
                Side = 1;
                Reset = 1;

            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AddValueToSide(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddValueToSide(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddValueToSide(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddValueToSide(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddValueToSide(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddValueToSide(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddValueToSide(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddValueToSide(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddValueToSide(9);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (Side == 1)
            {
                if (LeftValue != "" && Reset == 0)
                {
                    AddValueToSide(0);
                }
            }
            if (Side == 2)
            {
                if (RightValue != "" && Reset == 0)
                {
                    AddValueToSide(0);
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
            Side = 1;
            LeftValue = "";
            RightValue = "";
            this.lblResult.Text = "";
        }
    }
}
