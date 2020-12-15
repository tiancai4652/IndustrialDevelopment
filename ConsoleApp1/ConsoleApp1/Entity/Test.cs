using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Test:EntityBase
    {
        public string Name { get; set; }
        public DateTime TestTime { get; set; }
        public ICollection<Data> Datas { get; set; }
        public Device Device { get; set; }
    }
}
