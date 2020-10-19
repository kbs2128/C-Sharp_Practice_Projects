using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
        };
        Label firstclicked = null;
        Label secondclicked = null;
        private void AssigniconsToSquares()
        {
            foreach(Control ctrl in tableLayoutPanel1.Controls)
            {
                Label cell = ctrl as Label;
                if(cell!=null)
                {
                    int randomnuber = random.Next(icons.Count);
                    cell.Text = icons[randomnuber];
                    cell.ForeColor = cell.BackColor;
                    icons.RemoveAt(randomnuber);
                }
                

            }
        }
        public Form1()
        {
            InitializeComponent();
            AssigniconsToSquares();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            if (timer1.Enabled == true)
                return;
            if (secondclicked != null)
                return;
            Label clickedlabel = sender as Label;
            if (clickedlabel!=null)
            {
                if (clickedlabel.ForeColor == Color.Black)
                    return;
                if(firstclicked==null)
                {
                    firstclicked = clickedlabel;
                    firstclicked.ForeColor = Color.Black;
                    return;
                }
                secondclicked = clickedlabel;
                secondclicked.ForeColor = Color.Black;
                checkforwinner();
                if(firstclicked.Text==secondclicked.Text)
                {
                    firstclicked = null;
                    secondclicked = null;
                    return;
                }
                timer1.Start();

                
            }
            
        }
        private void checkforwinner()
        {
            foreach(Control ctrl in tableLayoutPanel1.Controls)
            {
                Label cell = ctrl as Label;
                if(cell!=null)
                {
                    if (cell.ForeColor != Color.Black)
                        return;
                }
            }
            MessageBox.Show("You have won the Game", "Congratulations");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstclicked.ForeColor = firstclicked.BackColor;
            secondclicked.ForeColor = secondclicked.BackColor;
            firstclicked = null;
            secondclicked = null;
        }
    }
}
