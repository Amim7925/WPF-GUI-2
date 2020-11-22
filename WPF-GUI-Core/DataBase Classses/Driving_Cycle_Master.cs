using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_GUI_Core.Property_Classes;

namespace WPF_GUI_Core.DataBase_Classses
{
    public class Driving_Cycle_Master
    {
        DBConnect db = new DBConnect();

        public List<DrivingCycleDc> ListDcName()
        {
            var list = new List<DrivingCycleDc>();
            if (db.OpenConnection())
            {
                var query = "SELECT Dc_Name, Dc_Id From tbldriving_cycle_master";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);

                try
                {
                    MySqlDataReader datareader = cmd.ExecuteReader();

                    while (datareader.Read())
                    {
                        var data = new DrivingCycleDc
                        {
                            DCID = datareader["Dc_Id"].ToString(),
                            DCName = datareader["Dc_Name"].ToString()
                        };
                        list.Add(data);
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
