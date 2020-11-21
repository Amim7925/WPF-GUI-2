using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core.Property_Classes
{
    class SimulationMaster
    {
        public string SimulationID { get; set; }

        public string DcID { get; set; }

        public string SIMUUser { get; set; }

        public DateTime SIMUStartDateTime { get; set; }

        public DateTime SIMUStoptDateTime { get; set; }
    }
}
