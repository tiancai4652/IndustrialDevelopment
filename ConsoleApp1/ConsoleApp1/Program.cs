using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IndustrialDbContext dbContext = new IndustrialDbContext())
            {
                var tests = dbContext.Tests.ToList();
            }
        }
    }
}
