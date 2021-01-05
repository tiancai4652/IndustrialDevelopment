using EF_CodeFirst.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.DBContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<People> People { get; set; }

        /// <summary>
        /// 从配置文件读取链接字符串
        /// </summary>
        public MyDbContext() :
            base("name = sampledb")
        {
            ConfigurationFunc();
        }

        /// <summary>
        /// 代码指定数据库连接
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="contextOwnsConnection"></param>
        public MyDbContext(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {
            ConfigurationFunc();
        }



        private void ConfigurationFunc()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var initializer = new SqliteDropCreateDatabaseWhenModelChanges<MyDbContext>(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}
