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

namespace TestWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }
        List<string> list = new List<string>();
        private void FillList()
        {
            list.Add("John");
            list.Add("Jason");
            list.Add("Amim");
            list.Add("Bhrath");
            list.Add("File1");
            list.Add("File2");
            list.Add("File3");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searched = txtwSearch.Text;
            foreach (var item in list)
            {
                if (item.ToLower().Contains(searched.ToLower()))
                {
                    Menu.Items.Add(new MenuItem { ItemsSource=item });
                }



            }
            
            
        }
    }
}
