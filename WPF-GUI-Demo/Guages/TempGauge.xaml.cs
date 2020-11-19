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

namespace WPF_GUI_Demo.Guages
{
    /// <summary>
    /// Interaction logic for TempGauge.xaml
    /// </summary>
    public partial class TempGauge : UserControl
    {
        public TempGauge()
        {
            InitializeComponent();
        }
        private long _value;
        public long Value
        {
            get => _value;
            set
            {
                if ((value >= 0) && (value <= 200))
                {
                    _value = value;
                    Temp.Value = _value;
                    //txtValue.Text = _value.ToString();
                }
            }
        }
    }
}
