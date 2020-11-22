using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_GUI_Core.Property_Classes
{
    public class DivingCycleSegment
    {

        public string SegID { get; set; }

        public int GetRpm { get; set; }

        public int Gradient { get; set; }

        public int Defaultload { get; set; }

        public int AddedLoad { get; set; }

        public DateTime RunTime { get; set; }

    }
}
