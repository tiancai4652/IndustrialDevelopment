using EF_CodeFirst.DBContext;
using EF_CodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite.EF6;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EF_CodeFirst.DBContext.MyDbContext;

namespace EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ptah = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sampledb.db");
            //var connection = SQLiteProviderFactory.Instance.CreateConnection();
            //connection.ConnectionString = $"Data Source={ptah}";

            //using (var context = new PersonDbContext())
            using (var context = new MyDbContext())
            {
                //#region 预热：针对数据表较多的情况下建议执行下述操作

                //var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                //var mappingColection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                //mappingColection.GenerateViews(new List<EdmSchemaError>());

                //#endregion

                #region 插入数据

                Console.WriteLine("插入数据：");
                context.People.Add(new Model.People { FirstName = "hippie", LastName = "zhou" });
                context.SaveChanges();

                #endregion

                #region 查找数据

                Console.WriteLine("查找数据：");
                foreach (var people in context.People)
                {
                    Console.WriteLine($"{people.Id} - {people.FirstName} - {people.LastName}");
                }

                #endregion

                #region 更改数据

                Console.WriteLine("更改数据：");
                People person = context.People.Where(p => p.Id == 1)?.FirstOrDefault();
                person.LastName = "Puth";
                context.SaveChanges();

                #endregion

                #region 删除数据

                Console.WriteLine("删除数据：");
                People person2 = context.People.Where(p => p.Id == 1)?.FirstOrDefault();
                context.People.Remove(person2);
                context.SaveChanges();

                #endregion

                Console.ReadKey();
            }
        }
    }
}
