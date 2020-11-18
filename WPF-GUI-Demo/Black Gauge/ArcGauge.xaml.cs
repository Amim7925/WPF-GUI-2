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
using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;

namespace WPF_GUI_Demo.Black_Gauge
{
    /// <summary>
    /// Interaction logic for ArcGauge.xaml
    /// </summary>
    public partial class ArcGauge : UserControl
    {
        public static readonly DependencyProperty GaugeTitleProperty = DependencyProperty.Register("GaugeTitle", typeof(string), typeof(ArcGauge), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty GaugeUnitProperty = DependencyProperty.Register("GaugeUnit", typeof(string), typeof(ArcGauge), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty MaxProperty = DependencyProperty.Register("Max", typeof(double), typeof(ArcGauge), new PropertyMetadata(100.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty MinProperty = DependencyProperty.Register("Min", typeof(double), typeof(ArcGauge), new PropertyMetadata(0.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(ArcGauge), new PropertyMetadata(0.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty SettingValueProperty = DependencyProperty.Register("SettingValue", typeof(double), typeof(ArcGauge), new PropertyMetadata(0.0, new PropertyChangedCallback(Rerender)));
        public static readonly DependencyProperty GaugeColorProperty = DependencyProperty.Register("GaugeColor", typeof(Brush), typeof(ArcGauge), new PropertyMetadata(Brushes.Gray));
        public static readonly DependencyProperty SettingGaugeColorProperty = DependencyProperty.Register("SettingGaugeColor", typeof(Brush), typeof(ArcGauge), new PropertyMetadata(Brushes.Red));

        public string GaugeTitle
        {
            get { return (string)GetValue(GaugeTitleProperty); }
            set { SetValue(GaugeTitleProperty, value); }
        }

        public string GaugeUnit
        {
            get { return (string)GetValue(GaugeUnitProperty); }
            set { SetValue(GaugeUnitProperty, value); }
        }

        public double Max
        {
            get { return (double)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public double Min
        {
            get { return (double)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public double SettingValue
        {
            get { return (double)GetValue(SettingValueProperty); }
            set { SetValue(SettingValueProperty, value); }
        }

        public Brush GaugeColor
        {
            get { return (Brush)GetValue(GaugeColorProperty); }
            set { SetValue(GaugeColorProperty, value); }
        }

        public Brush SettingGaugeColor
        {
            get { return (Brush)GetValue(SettingGaugeColorProperty); }
            set { SetValue(SettingGaugeColorProperty, value); }
        }

        private static void Rerender(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ArcGauge gauge = d as ArcGauge;
            gauge.RenderGauge();
        }

        readonly double FULLRANGE_ANGLE = 270;
        readonly double START_ANGLE_OFFSET = 90.0;

        public ArcGauge()
        {
            InitializeComponent();

            RenderGauge();
        }

        private void RenderGauge()
        {
            Point point;

            #region

            if (Value >= Max)
            {
                point = new Point(320, 160);
                arcGauge.IsLargeArc = true;
            }
            else if (Value <= Min)
            {
                point = new Point(160, 320);
                arcGauge.IsLargeArc = false;
            }
            else
            {
                double angle = FULLRANGE_ANGLE / (Max - Min) * (Value - Min);
                double rad = (Math.PI / 180.0) * (angle + START_ANGLE_OFFSET);
                double x = 160 * Math.Cos(rad) + 160;
                double y = 160 * Math.Sin(rad) + 160;

                point = new Point(x, y);
                arcGauge.IsLargeArc = angle > 180.0;
            }

            arcGauge.Point = point;

            #endregion

            #region Setting Gauge

            if (SettingValue >= Max)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.Angle = -90;
                ptSetup.RenderTransform = rotate;
            }
            else if (SettingValue <= Min)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.Angle = 0;
                ptSetup.RenderTransform = rotate;
            }
            else
            {
                double angle = FULLRANGE_ANGLE / (Max - Min) * (SettingValue - Min);
                if (angle <= 180)
                {
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = angle;
                    ptSetup.RenderTransform = rotate;
                }
                else
                {
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = -360 + angle;
                    ptSetup.RenderTransform = rotate;
                }
            }

            #endregion





        }
        #region Structures
        /// <summary>
        /// Message Status structure used to show CAN Messages
        /// in a ListView
        /// </summary>
        private class MessageStatus
        {

            private TPCANMsgFD m_Msg;
            private TPCANTimestampFD m_TimeStamp;
            private TPCANTimestampFD m_oldTimeStamp;
            private int m_iIndex;
            private int m_Count;
            private bool m_bShowPeriod;
            private bool m_bWasChanged;

            public MessageStatus(TPCANMsgFD canMsg, TPCANTimestampFD canTimestamp, int listIndex)
            {
                m_Msg = canMsg;
                m_TimeStamp = canTimestamp;
                m_oldTimeStamp = canTimestamp;
                m_iIndex = listIndex;
                m_Count = 1;
                m_bShowPeriod = true;
                m_bWasChanged = false;
            }

            public void Update(TPCANMsgFD canMsg, TPCANTimestampFD canTimestamp)
            {
                m_Msg = canMsg;
                m_oldTimeStamp = m_TimeStamp;
                m_TimeStamp = canTimestamp;
                m_bWasChanged = true;
                m_Count += 1;
            }

            public TPCANMsgFD CANMsg
            {
                get { return m_Msg; }
            }

            public TPCANTimestampFD Timestamp
            {
                get { return m_TimeStamp; }
            }

            public int Position
            {
                get { return m_iIndex; }
            }

            public string TypeString
            {
                get { return GetMsgTypeString(); }
            }

            public string IdString
            {
                get { return GetIdString(); }
            }

            public string DataString
            {
                get { return GetDataString(); }
            }

            public int Count
            {
                get { return m_Count; }
            }

            public bool ShowingPeriod
            {
                get { return m_bShowPeriod; }
                set
                {
                    if (m_bShowPeriod ^ value)
                    {
                        m_bShowPeriod = value;
                        m_bWasChanged = true;
                    }
                }
            }

            public bool MarkedAsUpdated
            {
                get { return m_bWasChanged; }
                set { m_bWasChanged = value; }
            }

            public string TimeString
            {
                get { return GetTimeString(); }
            }

            private string GetTimeString()
            {
                double fTime;

                fTime = (m_TimeStamp / 1000.0);
                if (m_bShowPeriod)
                    fTime -= (m_oldTimeStamp / 1000.0);
                return fTime.ToString("F1");
            }

            private string GetDataString()
            {
                string strTemp;

                strTemp = "";

                //  if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                //      return "Remote Request";
                //  else
                //      for (int i = 0; i < Form1.GetLengthFromDLC(m_Msg.DLC, (m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == 0); i++)
                //          strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

                return strTemp;
            }

            private string GetIdString()
            {
                // We format the ID of the message and show it
                //
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    return string.Format("{0:X8}h", m_Msg.ID);
                else
                    return string.Format("{0:X3}h", m_Msg.ID);
            }

            private string GetMsgTypeString()
            {
                string strTemp;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_STATUS) == TPCANMessageType.PCAN_MESSAGE_STATUS)
                    return "STATUS";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ERRFRAME) == TPCANMessageType.PCAN_MESSAGE_ERRFRAME)
                    return "ERROR";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    strTemp = "EXT";
                else
                    strTemp = "STD";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    strTemp += "/RTR";
                else
                    if ((int)m_Msg.MSGTYPE > (int)TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                {
                    strTemp += " [ ";
                    if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_FD) == TPCANMessageType.PCAN_MESSAGE_FD)
                        strTemp += " FD";
                    if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_BRS) == TPCANMessageType.PCAN_MESSAGE_BRS)
                        strTemp += " BRS";
                    if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_ESI) == TPCANMessageType.PCAN_MESSAGE_ESI)
                        strTemp += " ESI";
                    strTemp += " ]";
                }

                return strTemp;
            }

        }
    }


    #endregion
}
