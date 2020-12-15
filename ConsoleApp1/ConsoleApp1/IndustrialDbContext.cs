using Entities.Entity;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IndustrialDbContext: DbContext
    {
        public IndustrialDbContext():base("name=Sqlite")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<IndustrialDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
