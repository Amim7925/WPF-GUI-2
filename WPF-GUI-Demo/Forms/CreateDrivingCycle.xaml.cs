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
                listview.Items.Add(new DrivingCycle { Torque = Convert.ToDouble(txtTorque.Text), Gradiant = Convert.ToDouble(txtGradiant.Text), Rpm = Convert.ToDouble(txtRPM.Text), Load = txtLoad.Text, Time = timerpicker.Text });

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
