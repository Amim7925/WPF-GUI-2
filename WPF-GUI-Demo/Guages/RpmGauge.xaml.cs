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
    /// Interaction logic for RpmGauge.xaml
    /// </summary>
    public partial class RpmGauge : UserControl
    {
        public RpmGauge()
        {
            InitializeComponent();
        }
        private long _value;
        public long Value
        {
            get => _value;
            set
            {
                if ((value >= 0) && (value <= 6000))
                {
                    _value = value;
                    Rpm.Value = _value / 60;
                    txtValue.Text = _value.ToString() ;
                }
            }
        }
        public void SetMinValue()
        {
            Value = 0;

        }
        public void SetMaxValue()
        {
            Value = 6000;

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {



        }

       



    }
}
