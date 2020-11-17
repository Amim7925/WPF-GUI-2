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
    /// Interaction logic for TorqueGauge.xaml
    /// </summary>
    public partial class TorqueGauge : UserControl
    {
        public TorqueGauge()
        {
            InitializeComponent();
        }
        private long _value;
        public long Value
        {
            get => _value;
            set
            {
                if ((value >= 0) && (value <= 3000))
                {
                    _value = value;
                    Torq.Value = _value / 30 ;
                    txtValue.Text = _value.ToString();
                }
            }
        }
        public void SetMinValue()
        {
            Value = 0;

        }
        public void SetMaxValue()
        {
            Value = 3000;

        }
    }
}
