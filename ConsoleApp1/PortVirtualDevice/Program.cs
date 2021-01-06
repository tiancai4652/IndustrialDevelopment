using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortVirtualDevice
{
    class Program
    {
        static void Main(string[] args)
        {
            Device device = new Device("COM6");
            device.Load();
        }
    }
}
