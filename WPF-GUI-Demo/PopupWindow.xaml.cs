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
using System.Windows.Shapes;
using WPF_GUI_Demo.Forms;

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        int argo;
        public PopupWindow(int arg)
        {
            argo = arg;
            InitializeComponent();
            //ShowUC();

            switch (argo)
            {
                case 1:
                    gridShow.Children.Add(UCCanbus);
                    break;
                case 2:
                    gridShow.Children.Add(UCDrivingCycle);
                    break;
                case 3:
                    gridShow.Children.Add(UCUser);
                    break;
                case 4:
                    gridShow.Children.Add(UCTCPConnection);
                    break;
                case 5:
                    gridShow.Children.Add(UCUploadCSV);
                    break;
                case 6:
                    gridShow.Children.Add(UCAboutUs);
                    break;

            }
        }
       
        CanbusConnection UCCanbus = new CanbusConnection();
        CreateDrivingCycle UCDrivingCycle = new CreateDrivingCycle();
        CreateUser UCUser = new CreateUser();
        TCPConnection UCTCPConnection = new TCPConnection();
        UploadCSV UCUploadCSV = new UploadCSV();
        AboutUs UCAboutUs = new AboutUs();
        private void ShowUC()
        {
            
        }

        private void btnpower_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gridTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
