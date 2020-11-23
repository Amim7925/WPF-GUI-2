using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Demo.Classes
{
    public class DrivingCycle
    {
        public string SegId { get; set; }
        public string DcID { get; set; }
        //public double Torque { get; set; }
        public int Rpm { get; set; }
        public int Gradiant { get; set; }
        public int Load { get; set; }
        public int AddedLoad { get; set; }
        public TimeSpan Time { get; set; }
    }
}
