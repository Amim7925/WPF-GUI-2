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

        public List<DivingCycleSegment> ListSegments(string DCName)
        {
            List<DivingCycleSegment> list = new List<DivingCycleSegment>();
            if (db.OpenConnection())
            {
                var query = "SELECT driving_cycle_segments.Seg_Id,driving_cycle_segments.Get_Rpm,driving_cycle_segments.Gradient,driving_cycle_segments.Default_Load,driving_cycle_segments.Added_Load,driving_cycle_segments.Run_Time FROM driving_cycle_segments INNER JOIN tbldriving_cycle_master ON tbldriving_cycle_master.Dc_Name=@DCName";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);

                cmd.Parameters.AddWithValue("DCName", DCName);

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
