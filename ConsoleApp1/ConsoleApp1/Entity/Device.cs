using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Device:EntityBase
    {
        public string Name { get; set; }
        public string SN { get; set; }

        List<Test> Tests { get; set; }

        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        
        public Customer Customer { get; set; }

    }
}
