using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_GUI_Demo
{
   
    /// <summary>
    /// Interaction logic for LineChart.xaml
    /// </summary>
    public partial class LineChart : UserControl
    {
        public LineChart()
        {
            InitializeComponent();
            AllCharts();
        }
        public delegate void ChartDelegate();
        private int Minvalue { set; get; }
        private int Maxvalue { set; get; }
        public void SetMinMax()
        {
            Minvalue = DateTime.Now.Second ;
            Maxvalue = DateTime.Now.Second + 6;
        }

        private void AllCharts()
        {
            TorqueValues.PointGeometry = DefaultGeometries.Triangle;
            RpmValues.PointGeometry = DefaultGeometries.Circle;
            Rpm_cValues.PointGeometry = DefaultGeometries.Diamond;
            TempValues.PointGeometry = DefaultGeometries.Square;

        }
                
        

        

      
        
       

       
        public void removeData()
        {
            //SeriesCollection.RemoveAt(SeriesCollection.Count - 1);
        }
        
        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }

        public void FillChart(double[] Torque, double[] Rpm, double[] Temp, double[] Rpm_c)
        {
            var torqueValues = new ChartValues<double>();
            foreach (var item in Torque)
            {
                torqueValues.Add(item);
            }
            var rpmValues = new ChartValues<double>();
            foreach (var item in Rpm)
            {
                rpmValues.Add(item);
            }
            var tempValues = new ChartValues<double>();
            foreach (var item in Temp)
            {
                tempValues.Add(item);
            }
            var rpm_cValues = new ChartValues<double>();
            foreach (var item in Rpm_c)
            {
                rpm_cValues.Add(item);
            }
            TorqueValues.Values = torqueValues;
            TempValues.Values = tempValues;
            Rpm_cValues.Values = rpm_cValues;
            RpmValues.Values = rpmValues;

            Labels = new[] { "12:00", "12:01", "12:02", "12:03", "12:04", "12:05", "12:06", "12:07", "12:08", "12:09", "12:10" };

            DataContext = this;
        }



    }
}

