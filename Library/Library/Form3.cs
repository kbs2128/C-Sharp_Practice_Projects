using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Form3 : Form
    {
        Library_software3 library3 = new Library_software3();
        public Form3()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            library3.username = username.Text.ToString();
            if (password.Text.ToString().Equals(c_password.Text.ToString()))
            {
                library3.password = password.Text.ToString();
                library3.Id = student_id.Text.ToString();
                try
                {
                    if (library3.Registration_of_new_user(library3))
                    {
                        MessageBox.Show("Registration Successfull", "Acknowledgement");
                    }
                    else
                        MessageBox.Show("Registration Denied");
                }
                catch(SqlException e1)
                {
                    MessageBox.Show(e1.Message,"Error");
                    MessageBox.Show("The ID You entered is not in the Student Database"+"\n"+"So Registration Denied","Acknowledgement",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                

            }
            else
                MessageBox.Show("Make sure that both d fields i.e password and confirm_password are same");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_1 f1 = new Form_1();
            f1.Visible = true;
        }
    }
    class Library_software3
    {
        private string constring = Library.Properties.Settings.Default.Database1ConnectionString;
        public string username;
        public string password;
        public string Id;
        public string insertquery = "insert into Login_data values(@username,@password,@student_id)";
        public bool Registration_of_new_user(Library_software3 library3)
        {
            int rows;
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            SqlCommand com = new SqlCommand(insertquery, c);
            com.Parameters.AddWithValue("username", library3.username);
            com.Parameters.AddWithValue("password", library3.password);
            com.Parameters.AddWithValue("student_id", library3.Id);
            rows = com.ExecuteNonQuery();
            c.Close();
            if (rows > 0)
                return true;
            else
                return false;
            

        }
    }
}
