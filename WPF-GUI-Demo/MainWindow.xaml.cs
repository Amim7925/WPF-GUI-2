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
using System.Windows.Threading;
using WPF_GUI_Core.DataBase_Classses;
using WPF_GUI_Core.Property_Classes;
using WPF_GUI_Demo.Black_Gauge;
using WPF_GUI_Demo.Classes;

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            FillList();
            worker.DoWork += worker_DoWork;
            //worker.ProgressChanged += worker_Progresschanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.ProgressChanged += worker_Progresschanged;


            worker.RunWorkerAsync();
        }

        CardValueClass cr = new CardValueClass();
        private void BtnGoleft_Click(object sender, RoutedEventArgs e)
        {
            BtnGoleft.Visibility = Visibility.Hidden;
            BtnGoright.Visibility = Visibility.Visible;
        }

        private void BtnGoright_Click(object sender, RoutedEventArgs e)
        {
            BtnGoright.Visibility = Visibility.Hidden;
            BtnGoleft.Visibility = Visibility.Visible;
        }

        private void btnpower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Hidden;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Hidden;
        }

        private void btnTCPConnection_Click(object sender, RoutedEventArgs e)
        {
            new PopupWindow(4).ShowDialog();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            new PopupWindow(3).ShowDialog();
        }

        private void btnCanbusConnection_Click(object sender, RoutedEventArgs e)
        {
            new PopupWindow(1).ShowDialog();
        }

        private void btnUploadCSVFile_Click(object sender, RoutedEventArgs e)
        {
            new PopupWindow(5).ShowDialog();
        }

        private void btnDrivingCycle_Click(object sender, RoutedEventArgs e)
        {
            new PopupWindow(2).ShowDialog();
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            new PopupWindow(6).ShowDialog();

            
        }
        private void MainItemsGrid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TiltleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState ==  System.Windows.WindowState.Maximized)
            {
                
                this.WindowState = System.Windows.WindowState.Normal;
               
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;

            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new WindowLogin().Show();
            this.Close();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (tgbGuages.IsChecked == true)
            {
                scrollBarValues.Visibility = Visibility.Visible;
                scrollBarGuages.Visibility = Visibility.Hidden;
                lblGuages.Text = "Values :";
            }
            if(tgbGuages.IsChecked == false)
            {
                scrollBarValues.Visibility = Visibility.Hidden;
                scrollBarGuages.Visibility = Visibility.Visible;
                lblGuages.Text = "Gauges :";
            }
        }

        private void FillGauges(Gauges obj)
        {
            Rpm1.Value = obj.RpmGauge1;
            Rpm2.Value = obj.RpmGuage2;
            Temp1.Value = obj.TempGauge1;
            Temp2.Value = obj.TempGuage2;
            Torque1.Value = obj.TorqueGauge1;
            Torque2.Value = obj.TorqueGauge2;
            BlackRpm.Value = obj.BGRpm;
            BlackTemp.Value = obj.BGTemp;
            BlackTorue.Value = obj.BGTorque;
        }

        private void fillValueCards(CardValueClass cardsvalue)
        {
            valueUrms1.Content = cardsvalue.Urms1;
            valueUrms2.Content = cardsvalue.Urms2;
            valueUrms3.Content = cardsvalue.Urms3;
            valueUdc4.Content = cardsvalue.Udc4;
            valueIdc1.Content = cardsvalue.Irms1;
            valueIdc2.Content = cardsvalue.Irms2;
            valueIdc3.Content = cardsvalue.Irms3;
            valueIdc4.Content = cardsvalue.Idc4;
            valueA1.Content = cardsvalue.A1;
            valueA2.Content = cardsvalue.A2;
            valueA3.Content = cardsvalue.A3;
            valuePm.Content = cardsvalue.Pm;
            valueCHA.Content = cardsvalue.CHA;
            valueCHB.Content = cardsvalue.CHB;
            valuef1.Content = cardsvalue.f1;
            valueS1.Content = cardsvalue.S1;
            valueS2.Content = cardsvalue.S2;
            valueS3.Content = cardsvalue.S3;
            valueS4.Content = cardsvalue.S4;
            valueQ1.Content = cardsvalue.Q1;
            valueQ2.Content = cardsvalue.Q2;
            valueQ3.Content = cardsvalue.Q3;
            valueP1.Content = cardsvalue.P1;
            valueP2.Content = cardsvalue.P2;
            valueP3.Content = cardsvalue.P3;
            valueP4.Content = cardsvalue.P4;
            valueUthd1.Content = cardsvalue.Uthd1;
            valueUthd2.Content = cardsvalue.Uthd2;
            valueUthd3.Content = cardsvalue.Uthd3;
            
            
            
            
        }

        private void btnStartSimulation_Click(object sender, RoutedEventArgs e)
        {

            
        }
       

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //int a = 0;
            //while (a<30000)
            //{
            //    a++;
            //    Thread.Sleep(300);
            //    worker.ReportProgress(a);
            //}
            ////double[] a = { 9, 1, 5, 0, 8 };
            //double[] b = { 9, 1, 5, 0, 8 };
            //double[] c = { 9, 1, 5, 0, 8 };
            //double[] d = { 9, 1, 5, 0, 8 };
            //LineChart.FillChart(a, b, c, d);
            //int counter = 0;
            //while (true)
            //{
            //    counter++;
            //    Thread.Sleep(300);
            //    worker.ReportProgress(counter);
            //}
        }

        private void worker_Progresschanged(object sender, ProgressChangedEventArgs e)
        {
             //e.UserState;
            //aa();
            

        }
        private void worker_RunWorkerCompleted(object sender,
                                           RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            atest();
                  

        }
        private void atest()
        {
            LineChart.SetMinMax();
            
            double[] a = { 0, 2, 5, 7, 3 };
            double[] b = { 1, 6, 3, 4, 5 };
            double[] c = { 2, 9, 7, 7, 7 };
            double[] d = { 7, 2, 9, 9, 0 };
            LineChart.FillChart(a, b, c, d);
            Gauges values = new Gauges
            {
                BGRpm = 3100,
                BGTemp = 150,
                BGTorque = 1600,
                RpmGauge1 = 3150,
                RpmGuage2 = 3200,
                TempGauge1 = 155,
                TempGuage2 = 160,
                TorqueGauge1 = 1650,
                TorqueGauge2 = 1700
            };
            FillGauges(values);
            fillValueCards(cr);
        }

        private void btest()
        {
            //LineChart.removeData();
            //LineChart.SetMinMax();

            double[] a = { 9, 1, 5, 0, 8 };
            double[] b = { 9, 1, 5, 0, 8 };
            double[] c = { 9, 1, 5, 0, 8 };
            double[] d = { 9, 1, 5, 0, 8 };
            LineChart.FillChart(a, b, c, d);
            Gauges values = new Gauges
            {
                BGRpm = 1100,
                BGTemp = 50,
                BGTorque = 160,
                RpmGauge1 = 350,
                RpmGuage2 = 5200,
                TempGauge1 = 255,
                TempGuage2 = 16,
                TorqueGauge1 = 50,
                TorqueGauge2 = 1700
            };
            FillGauges(values);
            fillValueCards(cr);
        }


        public void AddListViewItems(List<DivingCycleSegment> theList)
        {
            foreach(var item in theList)
            {
                //theList.Where(i=>i.I == )



                RightListview.Items.Add(new SimulationList(item));



            }





        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var data = list;

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list
            resultStack.Children.Clear();

            // Add the result
            foreach (var obj in data)
            {
                if (obj.ToLower().StartsWith(query.ToLower()))
                {
                    // The word starts with this... Autocomplete must work
                    addItem(obj);
                    found = true;
                }
            }

            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }
        Driving_Cycle_Master dr = new Driving_Cycle_Master();
        List<string> list = new List<string>();
        /// <summary>
        /// A test list for the auto complete textbox
        /// </summary>
        private void FillList()
        {
            list = dr.ListDcName();
            
        }
        private void addItem(string text)
        {
            TextBlock block = new TextBlock();

            // Add the text
            block.Text = text;

            // A little style...
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events
            block.MouseLeftButtonUp += (sender, e) =>
            {
                ACBorder.Visibility = Visibility.Collapsed;
            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.SkyBlue;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };
            block.MouseLeftButtonDown += (sender, e) =>
            {
                txtSearch.Text = (sender as TextBlock).Text;
            };
            // Add to the panel
            resultStack.Children.Add(block);
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddListViewItems(  new Driving_Cycle_Segments().ListSegments(txtSearch.Text));






        }

        
    }
}
