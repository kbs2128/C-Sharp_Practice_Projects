using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_IO_DEMO_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                listBox1.Items.Clear();
                string filename = openFileDialog1.FileName;
                FileInfo finfo = new FileInfo(filename);
                listBox1.Items.Add("Full Name :"+finfo.FullName);
                listBox1.Items.Add("Parentname :"+finfo.Directory);
                listBox1.Items.Add("Creation Time : "+finfo.CreationTime);
                listBox1.Items.Add("File Size : "+finfo.Length / 1024);
                listBox1.Items.Add("Read Only :"+finfo.IsReadOnly);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(string diskdrive in Directory.GetLogicalDrives())
            {
                listBox1.Items.Add(diskdrive);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
            string selecteditem = listBox1.SelectedItem.ToString();
            if(listBox1.SelectedItem.ToString()== @"C:\")
            {
                listBox1.Items.Clear();
                foreach(string directory in Directory.GetDirectories(@"C:\"))
                {
                    listBox1.Items.Add(directory);
                }
            }
            else if(listBox1.SelectedItem.ToString() == @"D:\")
            {
                listBox1.Items.Clear();
                foreach (string directory in Directory.GetDirectories(@"D:\"))
                {
                    listBox1.Items.Add(directory);
                }
            }
            else
            {
                if(selecteditem!=null)
                {
                    listBox1.Items.Clear();
                    DirectoryInfo dinfo = new DirectoryInfo(selecteditem);
                    foreach(DirectoryInfo dirinfo in dinfo.GetDirectories())
                    {
                        listBox1.Items.Add(dinfo.Name);
                    }
                    foreach (FileInfo file in dinfo.GetFiles())
                    {
                        listBox1.Items.Add(file.Name);
                    }

                }
            }
        }
    }
}
