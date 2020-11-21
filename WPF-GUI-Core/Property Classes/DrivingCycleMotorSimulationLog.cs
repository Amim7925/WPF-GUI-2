using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core.Property_Classes
{
    class DrivingCycleMotorSimulationLog
    {

        public string SimulationID { get; set; }

        public string DCID { get; set; }

        public string SegID { get; set; }

        public int SetTPS { get; set; }

        public int Rpm { get; set; }

        public double OB_Temp { get; set; }

        public TimeSpan Vehicle_Time { get; set; }


        public DateTime SimulatorDatetime { get; set; }

        public double Urms1 { get; set; }

        public double Urms2 { get; set; }

        public double Urms3 { get; set; }

        public double Udc4 { get; set; }

        public double DCModifiedDateTime { get; set; }

        public double Status { get; set; }
        public double Irms1 { set; get; }
        public double Irms2 { set; get; }
        public double Irms3 { set; get; }
        public double Idc4 { set; get; }

        public double A1 { set; get; }
        public double A2 { set; get; }
        public double A3 { set; get; }

        public double OFF1 { set; get; }
        public double OFF2 { set; get; }
        public double OFF3 { set; get; }

        public double Pm { set; get; }
        public double CHA { set; get; }
        public double CHB { set; get; }
        public double f1 { set; get; }

        public double Uthd1 { set; get; }
        public double Uthd2 { set; get; }
        public double Uthd3 { set; get; }

        public double S1 { set; get; }
        public double S2 { set; get; }
        public double S3 { set; get; }
        public double S4 { set; get; }
        public double Q1 { set; get; }
        public double Q2 { set; get; }
        public double Q3 { set; get; }
        public double P1 { set; get; }
        public double P2 { set; get; }
        public double P3 { set; get; }
        public double P4 { set; get; }


    }
}
