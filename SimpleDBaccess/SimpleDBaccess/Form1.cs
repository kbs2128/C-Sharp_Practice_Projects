using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SimpleDBaccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.database1DataSet3.Student);
            // TODO: This line of code loads data into the 'database1DataSet2.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.database1DataSet2.Student);
            // TODO: This line of code loads data into the 'database1DataSet1.Project' table. You can move, or remove it, as needed.
            this.projectTableAdapter.Fill(this.database1DataSet1.Project);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = int.Parse(textBox1.Text);
            SqlConnection myconnection=new SqlConnection(SimpleDBaccess.Properties.Settings.Default.Database1ConnectionString);
            myconnection.Open();
            SqlCommand mycommand = new SqlCommand(string.Format("select * from Student where sid={0}",s), myconnection);
            SqlDataReader myreader = mycommand.ExecuteReader();
            while(myreader.Read())
            {
                dataGridView1.Rows.Add(myreader.GetInt32(0), myreader.GetString(1), myreader.GetString(2));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(SimpleDBaccess.Properties.Settings.Default.Database1ConnectionString);
            c.Open();
            SqlCommand cc = new SqlCommand(string.Format("insert into student values({0},{1},{2})", textBox2.Text, textBox3.Text, textBox4.Text), c);
            
            
        }
    }
}
