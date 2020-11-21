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
using WPF_GUI_Core;
using WPF_GUI_Core.Property_Classes;
using WPF_GUI_Demo.Classes;

namespace WPF_GUI_Demo.Forms
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : UserControl
    {
        public CreateUser()
        {
            InitializeComponent();
        }
        ClassUser db = new ClassUser();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Password,
                CreatedBy = SettingSoft.CurrentUser.UserName,
                PhoneNumber = txtPhoneNumber.Text,
                CreatedDateTime = DateTime.Now,
                Email = txtMail.Text,
                Role = txtRole.Text

            };
            try
            {
                db.Insert(user);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (var t in mainstackpanel.Children)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    TextBox tt = (TextBox)t;
                    Console.WriteLine(tt.Name);
                    tt.Text = string.Empty;
                }

            }

        }
    }
}
