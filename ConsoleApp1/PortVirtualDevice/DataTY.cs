using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortVirtualDevice
{
    public class DataTY
    {
        public DateTime Time { get; set; }
        public double Y { get; set; }

        public DataTY(double y, DateTime time)
        {
            Time = time;
            Y = y;
        }
    }
}
