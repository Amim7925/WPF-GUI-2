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
                var query = "SELECT driving_cycle_segments.* FROM driving_cycle_segments INNER JOIN tbldriving_cycle_master ON driving_cycle_segments.Dc_Id=@DcId GROUP BY Seg_Id";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);

                cmd.Parameters.AddWithValue("DcId", DcId);

                try
                {
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
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception em)
                {
                    throw new Exception(em.Message);
                }
                db.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        public void Insert(DivingCycleSegment argo)
        {
            if (db.OpenConnection())
            {
                if (IsDuplicate(argo.DcId, argo.SegID))
                    throw new Exception("This SegId already exist in this table please enter a different value");

                var query = "INSERT INTO `driving_cycle_segments`(`Seg_Id`, `Dc_Id`, `Get_Rpm`, `Gradient`, `Default_Load`, `Added_Load`, `Run_Time`) VALUES (@argo.SegID,@argo.DcId,@argo.GetRpm,@argo.Gradient,@argo.Defaultload,@argo.AddedLoad,@argo.RunTime)";

                var cmd = new MySqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@argo.SegID", argo.SegID.ToUpper()); cmd.Parameters.AddWithValue("@argo.Defaultload", argo.Defaultload);
                cmd.Parameters.AddWithValue("@argo.DcId", argo.DcId.ToUpper()); cmd.Parameters.AddWithValue("@argo.GetRpm", argo.GetRpm);
                cmd.Parameters.AddWithValue("@argo.Gradient", argo.Gradient); cmd.Parameters.AddWithValue("@argo.RunTime", argo.RunTime);
                cmd.Parameters.AddWithValue("@argo.AddedLoad", argo.AddedLoad);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception em)
                {
                    throw new Exception(em.Message);
                }

                db.CloseConnection();
            }

        }

        private bool IsDuplicate(string dcId, string Seg_Id)
        {

            var list = new List<string>();
            var query = "SELECT Seg_Id FROM driving_cycle_segments WHERE Dc_Id = @dcId";

            MySqlCommand cmd = new MySqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@dcId", dcId);
            try
            {
                MySqlDataReader datareader = cmd.ExecuteReader();
                while (datareader.Read())
                {
                    var data = datareader["Seg_Id"].ToString();
                    list.Add(data);
                }
                datareader.Close();
                if (list.Contains(Seg_Id))
                {

                    return true;

                }
                else
                {

                    return false;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception em)
            {
                throw new Exception(em.Message);
            }



        }
    }
}
