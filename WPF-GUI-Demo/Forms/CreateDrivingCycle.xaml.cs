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
                listview.Items.Add(new DrivingCycle { AddedLoad = Convert.ToInt32(txtAddedload.Text), Gradiant = Convert.ToInt32(txtGradiant.Text), Rpm = Convert.ToInt32(txtRPM.Text), Load = Convert.ToInt32(txtLoad.Text), Time = timerpicker.SelectedTime.Value.TimeOfDay });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }











            Clear();
        }

        private void Clear()
        {
            
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
