using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for StopWatch.xaml
    /// </summary>
    public partial class StopWatch : UserControl
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public StopWatch()
        {

            InitializeComponent();
            StartTimer();
        }





        public void StartTimer()
        {

            dispatcherTimer.Start();


            txtMiliSec.Text = DateTime.MinValue.ToString();


            txtSec.Text = TimeSpan.TicksPerMillisecond.ToString();


        }








    }








}

