using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_GUI_Core.DataBase_Classses;
using WPF_GUI_Core.Property_Classes;
using WPF_GUI_Demo.Classes;

namespace WPF_GUI_Demo.Forms
{
    /// <summary>
    /// Interaction logic for CreateDrivingCycle.xaml
    /// </summary>
    public partial class CreateDrivingCycle : UserControl
    {
        public CreateDrivingCycle()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listview.Items.Add(new DrivingCycleSegment
                {
                    SegID = txtSegmentName.Text.ToUpper(),
                    AddedLoad = Convert.ToInt32(txtAddedLoad.Text),
                    DcId = txtDcId.Text.ToUpper(),
                    Defaultload = Convert.ToInt32(txtLoad.Text),
                    GetRpm = Convert.ToInt32(txtRpm.Text),
                    Gradient = Convert.ToInt32(txtGradiant.Text),
                    RunTime = DateTime.Parse(timerpicker.Text)
                });

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (var t in stpTextboxes1.Children)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    TextBox tt = (TextBox)t;
                    Console.WriteLine(tt.Name);
                    tt.Text = string.Empty;
                }

            }
            timerpicker.Text = string.Empty;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(listview.Items.Count == 0)
            {
                MessageBox.Show("You need to add 1 item first !");
                return;
            }
               
            Driving_Cycle_Segments dcs = new Driving_Cycle_Segments();
            try
            {
                foreach (var item in listview.Items)
                {
                    dcs.Insert((DrivingCycleSegment)item);
                }
                MessageBox.Show("Segments Successfuly added");
                listview.Items.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (var t in stpTextboxes1.Children)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    TextBox tt = (TextBox)t;
                    Console.WriteLine(tt.Name);
                    tt.Text = string.Empty;
                }

            }
            timerpicker.Text = string.Empty;
        }
    }
}
