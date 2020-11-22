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
          
            foreach (var item in dcs.ListSegments("dc2").GroupBy(x=>x.SegID))
            {
                MessageBox.Show(item.Key);
            }
        }
        private void LoadData()
        {
            dataGridView1.DataSource = cu.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Driving_Cycle_Motor_Simulation_Log dcms = new Driving_Cycle_Motor_Simulation_Log();
            try
            {
                dcms.Insert(new DrivingCycleMotorSimulationLog
                {
                    A1 = 12,
                    Uthd3 = 12,
                    Uthd2 = 12,
                    Uthd1 = 12,
                    Urms3 = 12,
                    Urms2 = 12,
                    Urms1 = 12,
                    Udc4 = 12,
                    Status = 12,
                    S4 = 12,
                    S3 = 12,
                    A2 = 12,
                    A3 = 12,
                    CHA = 12,
                    CHB = 12,
                    Idc4 = 12,
                    DCModifiedDateTime = 12,
                    f1 = 12,
                    Irms1 = 12,
                    Irms2 = 12,
                    Irms3 = 12,
                    OB_Temp = 12,
                    OFF1 = 12,
                    OFF2 = 12,
                    OFF3 = 12,
                    P1 = 12,
                    P2 = 12,
                    P3 = 12,
                    P4 = 12,
                    Pm = 12,
                    Q1 = 12,
                    Q2 = 12,
                    Q3 = 12,
                    Rpm = 12,
                    S1 = 12,
                    S2 = 12,
                    SetTPS = 12,
                    SimulatorDatetime = DateTime.Now,
                    Vehicle_Time = TimeSpan.Parse("12:00:00"),
                    SimulationID = "SIM1",
                    DCID = "DC1",
                    SegID = "SEG1",
                });
                MessageBox.Show("successfully added");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
     
        }
    }
}
