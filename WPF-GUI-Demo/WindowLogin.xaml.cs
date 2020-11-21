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
using WPF_GUI_Core;
using WPF_GUI_Demo.Classes;

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }
        ClassUser Cu = new ClassUser();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var login = Cu.UserLogin(txtusername.Text, txtpassword.Password);
                if(login !=null && login.UserName != string.Empty)
                {
                    SettingSoft.CurrentUser = login;
                    new MainWindow().Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnpower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
