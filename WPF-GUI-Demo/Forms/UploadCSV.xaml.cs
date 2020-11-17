using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace WPF_GUI_Demo.Forms
{
    /// <summary>
    /// Interaction logic for UploadCSV.xaml
    /// </summary>
    public partial class UploadCSV : UserControl
    {
        public UploadCSV()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =  "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
            }
            if (path == string.Empty)
                MessageBox.Show("your path is not valid");
            DataTable dt = new DataTable();
            using (XLWorkbook workbook = new XLWorkbook(path))
            {
                bool _isFirstRow = true;
                var rows = workbook.Worksheet(1).RowsUsed();
                foreach (var row in rows)
                {
                    if (_isFirstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());

                        }
                        _isFirstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i++] = cell.Value.ToString();
                        }
                    }
                }
                //test datagrid to make sure data is being displayed as it should
                datagrid_CsvFile.ItemsSource = dt.DefaultView;
            }
        }
    }
}
