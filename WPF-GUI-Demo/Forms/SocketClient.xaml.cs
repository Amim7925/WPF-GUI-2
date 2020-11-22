using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
    /// Interaction logic for SocketClient.xaml
    /// </summary>
    public partial class SocketClient : UserControl
    {
        private IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        /// <summary>
        ///完整终端地址   //  Full terminal address
        /// </summary>
        private IPEndPoint serverFullAddr;
        /// <summary>
        /// 连接套接字   //  Connect socket
        /// </summary>
        private Socket sock;
       

        public SocketClient()
        {
            InitializeComponent();

        }

      

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            serverFullAddr = new IPEndPoint(serverIP, int.Parse(txtPort.Text));
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //lbxMessage.Invoke(new SetTextCallback(SetText), "Successful start time:" + DateTime.Now, 1);
            //指定本地主机地址和端口号  //  Specify the local host address and port number
            sock.Connect(serverFullAddr);
            byte[] byteSend = System.Text.Encoding.Default.GetBytes(":AOUT:ITEM?");
            byte[] message = new byte[1024];
            string mess = "";
            int bytes = 0;
            try
            {
                //发送数据  //  send data
                sock.Send(byteSend);
                //接收数据  //  Receive data

                bytes = sock.Receive(message);

                mess = mess + Encoding.Default.GetString(message, 0, bytes);//编码（当接收的字节大于1024的时候 这应该是循环接收，测试就没有那样写了）//  Encoding (when the received byte is greater than 1024, it should be received in a loop, the test is not written like that)

                if (mess.StartsWith("AOUT:ITEM"))  // && mess.Length ==  53
                {






                }
                else
                {
                    //lbxMessage.Invoke(new SetTextCallback(SetText), "Incorrect Format Received", 1);
                    //mess = "Data received： " + mess + " From：" + " " + " Current time is：" + DateTime.Now; //Data processing
                    //newSocket.Send(Encoding.Default.GetBytes(mess));//Send data to the client

                }


            }
            catch (Exception ex)
            {
                txtError.Text = "An error occurred, please contact the administrator" + ex;  //  
            }
            sock.Close();
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtInformation.Text = string.Empty;
        }

        private void BtnTestConnection_Click(object sender, RoutedEventArgs e)
        {
            serverIP = IPAddress.Parse(txtServerIP.Text);
            try
            {
                //设置IP和端口  //  Set IP and port
                serverFullAddr = new IPEndPoint(serverIP, int.Parse(txtPort.Text));
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //指定本地主机地址和端口号  //  Specify the local host address and port number
                sock.Connect(serverFullAddr);
                BtnTestConnection.IsEnabled = false;
                txtError.Text = "The connection to the server is successful. . . .";  //  The connection to the server is successful. . . .
                BtnDisconnect.IsEnabled = true;
                sock.Close();

            }
            catch (Exception ee)
            {
                txtError.Text = "Connection failure. . . Please double check whether the server " + ee;  //  Connection failure. . . Please double check whether the server is turned on
            }
        }

        private void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            sock.Close();
            BtnTestConnection.IsEnabled = true;
        }
    }
}
