using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1, addend2;
        int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            startthequiz();
            startbutton.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if(checktheanswers())
                {
                    timer1.Stop();
                    MessageBox.Show("Congrats You have done it correctly");
                    startbutton.Enabled = true;
                }
            }
            else
            {
               
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                if (checktheanswers())
                {
                    timer1.Stop();
                    MessageBox.Show("Congrats You have done it correctly");
                }
                else
                {
                    sum.Value = addend1 + addend2;
                    MessageBox.Show("Sorry you haven't done it!!");
                }
                startbutton.Enabled = true;
            }
        }

        public void startthequiz()
        {
            addend1 = randomizer.Next(50);
            addend2 = randomizer.Next(50);
            plusleftlabel.Text = addend1.ToString();
            plusrightlabel.Text = addend2.ToString();
            sum.Value = 0;
            timeLeft = 20;
            timeLabel.Text = "20 seconds";
            timer1.Start();

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if(answerbox!=null)
            {
                int length = answerbox.Value.ToString().Length;
                answerbox.Select(0, length);
            }
        }

        public bool checktheanswers()
        {
            if (sum.Value == addend1 + addend2)
                return true;
            else
                return false;

        }
    }
}
