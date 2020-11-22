using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_GUI_Core.Property_Classes;

namespace WPF_GUI_Core.DataBase_Classses
{

    public class Driving_Cycle_Segments
    {
        DBConnect db = new DBConnect();

        public List<DivingCycleSegment> ListSegments(string DcId)
        {
            List<DivingCycleSegment> list = new List<DivingCycleSegment>();
            if (db.OpenConnection())
            {
                var query = "SELECT driving_cycle_segments.* FROM driving_cycle_segments INNER JOIN tbldriving_cycle_master ON driving_cycle_segments.Dc_Id=@DcId";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);

                cmd.Parameters.AddWithValue("DcId", DcId);

                //try
                //{
                    MySqlDataReader datareader = cmd.ExecuteReader();

                    while (datareader.Read())
                    {
                        var data = new DivingCycleSegment
                        {
                            SegID = datareader["Seg_Id"].ToString(),
                            AddedLoad = (int)(datareader["Added_Load"]),
                            Defaultload = (int)(datareader["Default_Load"]),
                            Gradient = (int)(datareader["Gradient"]),
                            GetRpm = (int)(datareader["Get_Rpm"]),
                            RunTime = Convert.ToDateTime(datareader["Run_Time"]),
                        };
                        list.Add(data);
                    }
                    datareader.Close();
                //}
                //catch (MySqlException ex)
                //{
                //    throw new Exception(ex.Message);
                //}
                //catch (Exception em)
                //{
                //    throw new Exception(em.Message);
                //}
                db.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
