﻿using LiveCharts;
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

            double[] a = { 4, 6, 5, 2, 4 };
            double[] b = { 6, 7, 3, 4, 6 };
            double[] c = { 4, 2, 7, 2, 7 };
            double[] d = { 9, 3, 8, 6, 9 };
            FillChart(a, b, c,d);
            Repeater();
        }
        public delegate void ChartDelegate();
        private int Minvalue { set; get; }
        private int Maxvalue { set; get; }
        private void GetMinMax()
        {
            Minvalue = DateTime.Now.Second - 4;
            Maxvalue = DateTime.Now.Second ;
        }

        Timer timer = new Timer();


        private void Repeater()
        {
            Dispatcher.BeginInvoke(
                 System.Windows.Threading.DispatcherPriority.Normal,
                 new ChartDelegate(GetMinMax));



        }




        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }

        private void FillChart(double[] Torque, double[] Rpm, double[] Temp, double[] Rpm_c)
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
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Torque",
                    Values = torqueValues,
                    Fill= Brushes.Transparent

                },
                new LineSeries
                {
                    Title = "Rpm",
                    Values = rpmValues,
                    PointGeometry = null,
                    Fill= Brushes.Transparent
                },
                new LineSeries
                {
                    Title = "Temp",
                    Values = tempValues,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15,
                    Fill= Brushes.Transparent
                },
                 new LineSeries
                {
                    Title = "Rpm_c",
                    Values = rpm_cValues,
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 15,
                    Fill= Brushes.Transparent
                },

            };

            Labels = new[] { "12:00", "12:01", "12:02", "12:03", "12:04", "12:05", "12:06", "12:07", "12:08", "12:09", "12:10" };

            DataContext = this;
        }



    }
}

