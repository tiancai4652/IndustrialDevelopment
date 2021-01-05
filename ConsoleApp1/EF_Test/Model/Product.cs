using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
