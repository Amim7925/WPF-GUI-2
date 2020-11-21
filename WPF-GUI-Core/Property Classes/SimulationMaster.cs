using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core.Property_Classes
{
    class SimulationMaster
    {
        public int SimulationID { get; set; }

        public int DcID { get; set; }

        public string SIMUUser { get; set; }

        public DateTime SIMUStartDateTime { get; set; }

        public DateTime SIMUStoptDateTime { get; set; }
    }
}
