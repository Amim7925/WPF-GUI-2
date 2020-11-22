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
using WPF_GUI_Core.Property_Classes;

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for SimulationList.xaml
    /// </summary>
    public partial class SimulationList : UserControl
    {
        
        public SimulationList(DivingCycleSegment obj)
        {
            InitializeComponent();
            txtFileName.Text = obj.SegID;
            txtNumber.Text = obj.AddedLoad.ToString();
            txtPeriod.Text = obj.RunTime.ToString();
            txtZero.Text = obj.AddedLoad.ToString();





        }







    }
}
