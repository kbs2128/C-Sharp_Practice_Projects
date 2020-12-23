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
    
    
    public partial class Form_1 : Form
    {

        Library_software library = new Library_software();
        

        public Form_1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            library.username = uname.Text.ToString();
            library.password = password.Text.ToString();
            if (library.checklogincredintials(library))
            {
                MessageBox.Show("Login Approved");
                this.Hide();
                Form2 f = new Form2();
                f.Visible = true;

            }

            else
            {
                MessageBox.Show("Login Denied", "Error");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Visible = true;
        }
    }
    class Library_software
    {
        private string constring = Library.Properties.Settings.Default.Database1ConnectionString;
        public string username;
        public string password;
        public string query = "select * from Login_data where username=@username and password=@password";
        
        
        public bool checklogincredintials(Library_software library)
        {
            
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            SqlCommand com = new SqlCommand(query, c);
            com.Parameters.AddWithValue("username", library.username);
            com.Parameters.AddWithValue("password", library.password);
            SqlDataReader r = com.ExecuteReader();
            if (r.Read())
                return true;
            else
                return false;

        }
        
        
    }
}
