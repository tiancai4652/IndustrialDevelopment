using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class Data:EntityBase
    {
        [ForeignKey("Test")]
        public string TestID { get; set; }
        public Test Test { get; set; }

        public string X { get; set; }
        public string Y { get; set; }
    }
}
