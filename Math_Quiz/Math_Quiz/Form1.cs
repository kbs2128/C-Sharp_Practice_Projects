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
        int subend1, subend2;
        int mend1, mend2;
        int divend1, divend2;
        int timeLeft;
        
        
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.White;
            quit.Visible = false;
            startthequiz();
            startbutton.Enabled = false;

        }

        private void Answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox != null)
            {
                int length = answerbox.Value.ToString().Length;
                answerbox.Select(0, length);
            }
        }


        private void sum_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox != null)
            {
                int length = answerbox.Value.ToString().Length;
                answerbox.Select(0, length);
            }
        }

        private void difference_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox != null)
            {
                int length = answerbox.Value.ToString().Length;
                answerbox.Select(0, length);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 15)
                {
                    quit.Visible = true;
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
               
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                checktheanswers();
                answers();
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
            subend1 = randomizer.Next(10, 20);
            subend2 = randomizer.Next(10);
            minusleftlabel.Text = subend1.ToString();
            minusrightlabel.Text = subend2.ToString();
            difference.Value = 0;
            mend1 = randomizer.Next(1,10);
            mend2 = randomizer.Next(1,5);
            xleftlabel.Text = mend1.ToString();
            xrightlabel.Text = mend2.ToString();
            product.Value = 0;
            checking();
            division.Value = 0;
            timeLeft = 20;
            timeLabel.Text = "20 seconds";
            timer1.Start();

        }

        private void quit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            checktheanswers();
            answers();
            startbutton.Enabled = true;
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

        private void checktheanswers()
        {
            if (sum.Value == addend1 + addend2)
            {
                if (difference.Value == subend1 - subend2)
                {
                   if(product.Value==mend1*mend2)
                   {
                        if (division.Value == divend1 / divend2)
                        {
                            MessageBox.Show("Done Correctly=4\nErrors=0", "Acknowledgement");
                        }
                        else
                            MessageBox.Show("Done Correctly=3\nErrors=1", "Acknowledgement");
                   }
                   else
                        MessageBox.Show("Done Correctly=2\nErrors=2", "Acknowledgement");
                }
                else
                    MessageBox.Show("Done Correctly=1\nErrors=3", "Acknowledgement");
            }
            else
                MessageBox.Show("Done Correctly=0\nErrors=4", "Acknowledgement");

        }
        private void answers()
        {
            sum.Value = addend1 + addend2;
            difference.Value = subend1 - subend2;
            product.Value = mend1 * mend2;
            division.Value = divend1 / divend2;
        }
        private void checking()
        {
            divend1 = randomizer.Next(10, 20);
            divend2 = randomizer.Next(1,10);
            if (divend1 % divend2 == 0)
            {
                divideleftlabel.Text = divend1.ToString();
                dividerightlabel.Text = divend2.ToString();
            }
            else
                checking();
        }
    }
}
