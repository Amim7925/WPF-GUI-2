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
using System.Windows.Threading;
using WPF_GUI_Demo.Black_Gauge;

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = this.Resources["model"] as MainWindowModel;
            setCardValue(cardval);
        }
        CardValueClass cardval = new CardValueClass();
        Timer t = new Timer();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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

        private void setCardValue(CardValueClass value)
        {
            valueUrms1.Content = value.Urms1;
            valueUrms2.Content = value.Urms2;
            valueUrms3.Content = value.Urms3.ToString(); 
            valueUdc4.Content = value.Udc4.ToString();
            valueIdc1.Content = value.Idc1;
            valueIdc2.Content = value.Idc2;
            valueIdc3.Content  = value.Idc3; 
            valueIdc4.Content  = value.Idc4;
            valueA1.Content    = value.A1;
            valueA2.Content    = value.A2;
            valueA3.Content    = value.A3;
            valuePm.Content    = value.Pm;
            valueCHA.Content   = value.CHA;
            valueOFF.Content   = string.Empty;
            valueCHB.Content   = value.CHB;
            valuef1.Content    = value.f1;
                                

            valueS1.Content    = value.S1;
            valueS2.Content    = value.S2;
            valueS3.Content    = value.S3;
            valueS4.Content    = value.S4;
            valueOFF2.Content  = string.Empty;
            valueP1.Content    = value.P1;
            valueP2.Content    = value.P2;
            valueP3.Content    = value.P3;
            valueP4.Content    = value.P4;
            valueOFF3.Content  = string.Empty;
            valueQ1.Content    = value.Q1;
            valueQ2.Content    = value.Q2;
            valueQ3.Content    = value.Q3;
            valueUthd1.Content = value.Uthd1;
            valueUthd2.Content = value.Uthd2;
            valueUthd3.Content = value.Uthd3;
            

        }

    }
}
