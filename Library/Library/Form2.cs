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
    public partial class Form2 : Form
    {
        Library_Software2 library2 = new Library_Software2();
        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = library2.Displaydetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            library2.book_name = searchbar.Text;
            dataGridView1.DataSource = library2.search_by_name(library2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            library2.book_Id = searchbar.Text.ToString();
            dataGridView1.DataSource = library2.search_by_Id(library2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            library2.book_Id = id.Text;
            library2.book_name = name.Text;
            library2.student_id = s_id.Text;
            library2.book_author = author.Text;
            try
            {
                if (library2.Add_books(library2))
                {
                    MessageBox.Show("Book added Succesfully", "Acknowledgement");
                    dataGridView1.DataSource = library2.Displaydetails();
                }
                else
                    MessageBox.Show("Something went wrong");

            }
            catch(SqlException e1)
            {
                MessageBox.Show(e1.Message, "Error");
                MessageBox.Show("The Student_ID is not reflecting in our Student Database" + "\n" + "So,Book can't be added","Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_1 f2 = new Form_1();
            f2.Visible = true;
            
        }
    }
    class Library_Software2
    {
        public string book_Id;
        public string book_name;
        public string book_author;
        public string student_id;
        private string constring = Library.Properties.Settings.Default.Database1ConnectionString;
        public string query2 = "select * from Book";
        public string query3 = "select * from Book where Name=@book_name";
        public string query4 = "select * from Book where Book_Id=@book_Id";
        public string query5 = "insert into Book(Book_id,Name,Id,Author) values(@book_id,@book_name,@student_id,@book_author)";
        public DataTable Displaydetails()
        {
            var datatable = new DataTable();
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            SqlCommand com = new SqlCommand(query2, c);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(datatable);
            return datatable;
        }
        public DataTable search_by_name(Library_Software2 library2)
        {
            var datatable = new DataTable();
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            SqlCommand com = new SqlCommand(query3, c);
            com.Parameters.AddWithValue("book_name", library2.book_name);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(datatable);
            return datatable;
        }
        public DataTable search_by_Id(Library_Software2 library2)
        {
            var datatable = new DataTable();
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            SqlCommand com = new SqlCommand(query4, c);
            com.Parameters.AddWithValue("book_Id", library2.book_Id);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(datatable);
            return datatable;
        }
        public bool Add_books(Library_Software2 library2)
        {
            int rows;
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            SqlCommand com = new SqlCommand(query5, c);
            com.Parameters.AddWithValue("book_id", library2.book_Id);
            com.Parameters.AddWithValue("book_name", library2.book_name);
            com.Parameters.AddWithValue("student_id", library2.student_id);
            com.Parameters.AddWithValue("book_author", library2.book_author);
            rows = com.ExecuteNonQuery();
            c.Close();
            if (rows > 0)
                return true;
            else
                return false;


        }
    }
}
