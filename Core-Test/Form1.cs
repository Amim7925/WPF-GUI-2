using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_GUI_Core;
using WPF_GUI_Core.Property_Classes;

namespace Core_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        ClassUser cu = new ClassUser();
        DBConnect db = new DBConnect();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            //if (cu.UserLogin("Amim", "123"))
            //    MessageBox.Show("you logged in");


        }
        private void LoadData()
        {
            dataGridView1.DataSource = cu.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                UserName = "MR.Bharath",
                PhoneNumber = "00000",
                CreatedBy = "AmimB",
                CreatedDateTime = DateTime.Now,
                Email = "Test@protonmail.com",
                Password = "123"
            };
            cu.Insert(user);
            LoadData();
        }
    }
}
