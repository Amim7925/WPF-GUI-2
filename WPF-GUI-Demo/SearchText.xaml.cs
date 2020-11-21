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

namespace WPF_GUI_Demo
{
    /// <summary>
    /// Interaction logic for SearchText.xaml
    /// </summary>
    public partial class SearchText : UserControl
    {
        public SearchText()
        {
            InitializeComponent();
            FillList();
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

        }
    }
}
