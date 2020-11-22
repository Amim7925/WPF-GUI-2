using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        private static long tickZero = DateTime.Now.Ticks;

        public Func<double, string> X_Axis_LabelFormatter { get; set; } = d => TimeSpan.FromTicks((long)d - tickZero).TotalSeconds.ToString();

        public LineChart()
        {
            InitializeComponent();


            TempValues.Configuration = Mappers.Xy<FactoryTelemetry>().X(ft => ft.TimeStamp.Ticks).Y(ft => ft.Temp);

            RpmValues.Configuration = Mappers.Xy<FactoryTelemetry>().X(ft => ft.TimeStamp.Ticks).Y(ft => ft.Rpm);
            Rpm_cValues.Configuration = Mappers.Xy<FactoryTelemetry>().X(ft => ft.TimeStamp.Ticks).Y(ft => ft.Rpm_c);
            TorqueValues.Configuration = Mappers.Xy<FactoryTelemetry>().X(ft => ft.TimeStamp.Ticks).Y(ft => ft.Torque);



            AllCharts();
        }
        public delegate void ChartDelegate();
        

        private void AllCharts()
        {
            TorqueValues.PointGeometry = DefaultGeometries.Triangle;
            RpmValues.PointGeometry = DefaultGeometries.Circle;
            Rpm_cValues.PointGeometry = DefaultGeometries.Diamond;
            TempValues.PointGeometry = DefaultGeometries.Square;

        }
        public double AxisStep { get; set; } = TimeSpan.FromSeconds(5).Ticks;
        public double AxisUnit { get; set; } = TimeSpan.FromSeconds(1).Ticks;

        private double _axisMax = tickZero + TimeSpan.FromSeconds(30).Ticks;
        public double AxisMax { get => _axisMax; set { _axisMax = value; OnPropertyChanged(nameof(AxisMax)); } }

        private double _axisMin = tickZero;
        public double AxisMin { get => _axisMin; set { _axisMin = value; OnPropertyChanged(nameof(AxisMin)); } }

        private void AdjustAxis(long ticks)
        {
            var width = TimeSpan.FromSeconds(30).Ticks;

            AxisMin = (ticks - tickZero < width) ? tickZero : ticks - width;
            AxisMax = (ticks - tickZero < width) ? tickZero + width : ticks;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));









        public void removeData()
        {
            //SeriesCollection.RemoveAt(SeriesCollection.Count - 1);
        }
        
        public SeriesCollection SeriesCollection { get; set; }
        public ChartValues<FactoryTelemetry> ChartValues { get; set; } = new ChartValues<FactoryTelemetry>();
        public string[] Labels { get; set; }

        public void FillChart(double Torque, double Rpm, double Temp, double Rpm_c)
        {
            //var torqueValues = new ChartValues<double>();

            
            FactoryTelemetry FT = new FactoryTelemetry();
            FT.Rpm = Rpm;
            FT.Rpm_c = Rpm_c;
            FT.Temp = Temp;
            FT.Torque = Torque;

            ChartValues.Add(FT);



            
            AdjustAxis(FT.TimeStamp.Ticks);

            if (ChartValues.Count > 10)
                ChartValues.RemoveAt(0);

            
           

            DataContext = this;
        }



    }

    public class FactoryTelemetry
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public double Torque { get; set; }
        public double Rpm { get; set; }
        public double Rpm_c { get; set; }
        public double Temp { get; set; }
    }


 }

