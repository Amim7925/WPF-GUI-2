using LiveCharts;
using LiveCharts.Wpf;
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

            FillLineChart();
        
        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
        private void FillLineChart()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Torque",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 },
                    Fill= Brushes.Transparent
                    
                },
                new LineSeries
                {
                    Title = "Rpm",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null,
                    Fill= Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Temp",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15,
                    Fill= Brushes.Transparent
                },
               
            };

            Labels = new[] { "12:00", "12:01", "12:02", "12:03", "12:04" , "12:05", "12:06", "12:07", "12:08", "12:09", "12:010" };
           

            //modifying the series collection will animate and update the chart
           

            //modifying any series values will also animate and update the chart


            DataContext = this;
        }

       

    }
}

