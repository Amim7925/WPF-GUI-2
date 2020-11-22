using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_GUI_Core.Property_Classes;

namespace WPF_GUI_Core.DataBase_Classses
{
    public class Tcp_Connection
    {
        DBConnect db = new DBConnect();

        public void Inset(TcpConnection argo)
        {
            if (db.OpenConnection())
            {
                var query = "INSERT INTO `tcp_connection`( `Ip`, `PortNumber`) VALUES (@argo.Ip,@argo.PortNumber)";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@argo.Ip", argo.Ip);
                cmd.Parameters.AddWithValue("@argo.PortNumber", argo.PortNumber);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch(Exception em)
                {
                    throw new Exception(em.Message);
                }

                db.CloseConnection();
            }
        }
    }
}
