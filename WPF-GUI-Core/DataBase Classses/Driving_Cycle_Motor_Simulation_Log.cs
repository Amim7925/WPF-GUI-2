using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_GUI_Core.Property_Classes;

namespace WPF_GUI_Core.DataBase_Classses
{
    public class Driving_Cycle_Motor_Simulation_Log
    {
        DBConnect db = new DBConnect();
        
        public void Insert(DrivingCycleMotorSimulationLog argo)
        {
            if (db.OpenConnection())
            {
                var query = "INSERT INTO `driving_cycle_motor_simulation_log`" +
               "(`Simulation_Id`, `Dc_Id`, `Seg_Id`, `Set_Tps`, `Rpm`, `OB_Temp`, `Vehicle_Time`, `Simulator_DateTime`, `Urms1`, `Urms2`, `Urms3`, `Udc4`, `Irms1`," +
               " `Irms2`, `Irms3`, `Idc4`, `A1`, `A2`, `A3`, `OFF1`, `pm`, `CH A`, `CH B`, `f1`, `S1`, `S2`, `S3`, `S4`, `OFF2`, `P1`, `P2`, `P3`, `P4`, `OFF3`, `Q1`, " +
               "`Q2`, `Q3`, `Uthd1`, `Uthd2`, `Uthd3`) VALUES (@argo.SimulationID,@argo.DCID,@argo.SegID,@argo.SetTPS,@argo.Rpm,@OB_Temp,@argo.Vehicle_Time,@argo.SimulatorDatetime," +
               "@argo.Urms1,@argo.Urms2," +
               "@argo.Urms3,@argo.Udc4,@argo.Irms1,@argo.Irms2,@argo.Irms3,@argo.Idc4,@argo.A1,@argo.A2,@argo.A3,@argo.OFF1,@argo.Rpm,@argo.CHA,@argo.CHB," +
               "@argo.f1,@argo.S1,@argo.S2,@argo.S3,@argo.S4,@argo.OFF2,@argo.P1,@argo.P2,@argo.P3,@argo.P4,@argo.OFF3,@argo.Q1,@argo.Q2," +
               "@argo.Q3,@argo.Uthd1,@argo.Uthd2,@argo.Uthd3)";

                MySqlCommand cmd = new MySqlCommand(query, db.conn);

                cmd.Parameters.AddWithValue("@argo.A1", argo.A1); cmd.Parameters.AddWithValue("@argo.A2", argo.A2); cmd.Parameters.AddWithValue("@argo.A3", argo.A3); cmd.Parameters.AddWithValue("@argo.CHA", argo.CHA);
                cmd.Parameters.AddWithValue("@argo.CHB", argo.CHB); cmd.Parameters.AddWithValue("@argo.DCID", argo.DCID); cmd.Parameters.AddWithValue("@argo.DCModifiedDateTime", argo.DCModifiedDateTime); cmd.Parameters.AddWithValue("@argo.f1", argo.f1);
                cmd.Parameters.AddWithValue("@argo.Idc4", argo.Idc4); cmd.Parameters.AddWithValue("@argo.Irms1", argo.Irms1); cmd.Parameters.AddWithValue("@argo.Irms2", argo.Irms2); cmd.Parameters.AddWithValue("@argo.Irms3", argo.Irms3);
                cmd.Parameters.AddWithValue("@OB_Temp", argo.OB_Temp); cmd.Parameters.AddWithValue("@argo.OFF1", argo.OFF1); cmd.Parameters.AddWithValue("@argo.OFF2", argo.OFF2); cmd.Parameters.AddWithValue("@argo.OFF3", argo.OFF3);
                cmd.Parameters.AddWithValue("@argo.P1", argo.P1); cmd.Parameters.AddWithValue("@argo.P2", argo.P2); cmd.Parameters.AddWithValue("@argo.P3", argo.P3); cmd.Parameters.AddWithValue("@argo.P4", argo.P4);
                cmd.Parameters.AddWithValue("@argo.Pm", argo.Pm); cmd.Parameters.AddWithValue("@argo.Q1", argo.Q1); cmd.Parameters.AddWithValue("@argo.Q2", argo.Q2); cmd.Parameters.AddWithValue("@argo.Q3", argo.Q3);
                cmd.Parameters.AddWithValue("@argo.Rpm", argo.Rpm); cmd.Parameters.AddWithValue("@argo.S1", argo.S1); cmd.Parameters.AddWithValue("@argo.S2", argo.S2); cmd.Parameters.AddWithValue("@argo.S3", argo.S3);
                cmd.Parameters.AddWithValue("@argo.S4", argo.S4); cmd.Parameters.AddWithValue("@argo.SegID", argo.SegID); cmd.Parameters.AddWithValue("@argo.SetTPS", argo.SetTPS); cmd.Parameters.AddWithValue("@argo.SimulationID", argo.SimulationID);
                cmd.Parameters.AddWithValue("@argo.SimulatorDatetime", argo.SimulatorDatetime); cmd.Parameters.AddWithValue("@argo.Status", argo.Status); cmd.Parameters.AddWithValue("@argo.Udc4", argo.Udc4); cmd.Parameters.AddWithValue("@argo.Urms1", argo.Urms1);
                cmd.Parameters.AddWithValue("@argo.Urms2", argo.Urms2); cmd.Parameters.AddWithValue("@argo.Urms3", argo.Urms3); cmd.Parameters.AddWithValue("@argo.Uthd1", argo.Uthd1); cmd.Parameters.AddWithValue("@argo.Uthd2", argo.Uthd2);
                cmd.Parameters.AddWithValue("@argo.Uthd3", argo.Uthd3); cmd.Parameters.AddWithValue("@argo.Vehicle_Time", argo.Vehicle_Time);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                db.CloseConnection();
            }
           
        }

    }
    
}
