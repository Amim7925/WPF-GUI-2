using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core.DataBase_Classses
{
    public class Driving_Cycle_Master
    {
        DBConnect db = new DBConnect();

        public List<string> ListDcName()
        {
            var list = new List<string>();
            if (db.OpenConnection())
            {
                var query = "SELECT Dc_Name From tbldriving_cycle_master";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);

                try
                {
                    MySqlDataReader datareader = cmd.ExecuteReader();

                    while (datareader.Read())
                    {
                        list.Add(datareader["Dc_Name"].ToString());
                    }

                    datareader.Close();

                    db.CloseConnection();

                    return list;
                }
                catch(MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
              
            }
            else
            {
                return list;
            }
        }
    }
}
