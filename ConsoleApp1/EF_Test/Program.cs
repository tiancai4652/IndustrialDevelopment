using EF_Test.DBContext;
using EF_Test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProductContext())
            {
                //查
                var list = db.Categories.ToList();
                // 增 
                var food = new Category { CategoryId = "FOOD", Name = "Foods" };
                db.Categories.Add(food);
                int recordsAffected = db.SaveChanges();
                Console.WriteLine("Saved {0} entities to the database, press any key to exit.", recordsAffected);
                Console.ReadKey();
            }
        }
    }
}
