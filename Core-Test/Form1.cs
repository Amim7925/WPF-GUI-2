﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_GUI_Core;
using WPF_GUI_Core.DataBase_Classses;
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
        Driving_Cycle_Master dcm = new Driving_Cycle_Master();
        Driving_Cycle_Segments dcs = new Driving_Cycle_Segments();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in dcs.ListSegments("DCNAME1"))
            {
                MessageBox.Show(item.SegID);
            }
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
