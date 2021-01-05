using EF_Test.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test.DBContext
{
    public class ProductContext : DbContext
    {
        public ProductContext():base("name=MySqlite")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new SqliteDropCreateDatabaseWhenModelChanges<ProductContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
