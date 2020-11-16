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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

        }

        private void BtnGoDown_Click(object sender, RoutedEventArgs e)
        {
            BtnGoDown.Visibility = Visibility.Hidden;
            BtnGoTop.Visibility = Visibility.Visible;
        }

        private void BtnGoTop_Click(object sender, RoutedEventArgs e)
        {
            BtnGoTop.Visibility = Visibility.Hidden;
            BtnGoDown.Visibility = Visibility.Visible;
        }
       
    }
}
