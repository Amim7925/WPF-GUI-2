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
using WPF_GUI_Core.DataBase_Classses;
using WPF_GUI_Core.Property_Classes;

namespace WPF_GUI_Demo.Forms
{
    /// <summary>
    /// Interaction logic for TCPConnection.xaml
    /// </summary>
    public partial class TCPConnection : UserControl
    {
        public TCPConnection()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tcp_Connection con = new Tcp_Connection();
            try
            {
                con.Inset(new TcpConnection
                {
                    Ip = txtIp.Text,
                    PortNumber = txtPortNumber.Text
                });
                MessageBox.Show("New Connection Successfully Added");
                foreach (var t in stackpanelMain.Children)
                {
                    if (t.GetType() == typeof(TextBox))
                    {
                        TextBox tt = (TextBox)t;
                        Console.WriteLine(tt.Name);
                        tt.Text = string.Empty;
                    }

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
