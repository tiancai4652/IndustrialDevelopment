using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortVirtualDevice
{
    public class DataXY
    {
        public double X { get; set; }
        public double Y { get; set; }

        public DataXY(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
