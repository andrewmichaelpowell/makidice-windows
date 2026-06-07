using System;
using System.Windows.Forms;

namespace makidice
{
    public partial class frmD10 : Form
    {
        public frmD10()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            if (tbDice.Text != "" && tbDifficulty.Text != "")
            {
                try
                {
                    if (int.Parse(tbDice.Text) < 100 && int.Parse(tbDifficulty.Text) < 100)
                    {
                        int dice = int.Parse(tbDice.Text);
                        int difficulty = int.Parse(tbDifficulty.Text);
                        int successes = 0;
                        int result;
                        Random Roll = new Random();
                        for (int i = 0; i < dice; i++)
                        {
                            result = Roll.Next(10) + 1;
                            if (result == 1)
                            {
                                successes = successes - 1;
                            }
                            else if (result == 10)
                            {
                                successes = successes + 2;
                            }
                            else if (result >= difficulty)
                            {
                                successes = successes + 1;
                            }
                        }
                        if (successes < -9)
                        {
                            this.lblResult.Text = successes.ToString();
                        }
                        else if (successes > -1 && successes < 10)
                        {
                            this.lblResult.Text = "  " + successes.ToString();
                        }
                        else
                        {
                            this.lblResult.Text = " " + successes.ToString();
                        }
                    }
                }
                catch (FormatException)
                {
                }
            }
        }

        private void frmD10_Load(object sender, EventArgs e)
        {
            this.tbDice.Text = "";
            this.tbDifficulty.Text = "";
            this.lblResult.Text = "";
        }
    }
}
