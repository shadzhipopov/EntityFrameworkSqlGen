using DataAccess.DynamicContext;
using DynamicContextConsoleClient.Models;
using DynamicCRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;

namespace DynamicContextConsoleClient
{
    public class Result
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Module { get; set; }
        public int Properties { get; set; }
        public string LastProperty { get; set; }

        //TO DO: consider nested projections
        public List<BP> AllProperties { get; set; }
    }

    public class BP
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
    }



    internal class Program
    {


        //we must have the result types in advance
        //recursive CTEs are still not possible with LINQ
        //https://michaelceber.medium.com/implementing-a-recursive-projection-query-in-c-and-entity-framework-core-240945122be6

        //https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression.memberinit?view=net-7.0
        //https://stackoverflow.com/questions/20424603/build-dynamic-select-using-expression-trees
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<BookShopApiContext>();
            //options.UseNpgsql("server=localhost;user id=postgres;password=1234;database=FdbaDb");
            options.UseSqlServer("server=.;database=FdbaDb;integrated security=True;Trust Server Certificate=True;");
            options.ReplaceService<IModelCacheKeyFactory, DynamicContextCacheKeyFactory>();
            var db = new BookShopApiContext(options.Options);

            var cmm = new CompareModelMigrator(db);
            cmm.AddTableTest();


            var sm = new DynamicLinqJoinMethod(db);
            //sm.TargetLinqQuery();
            sm.CreateQuery();

            


            var cc = new DynamicQueryClass();
            cc.CreateQuery(db);

            var query = from bo in db.BusinessObjects
                        select new
                        {
                            bo.Id,
                            bo.DisplayName,
                            Properties = bo.BusinessProperties.Count(),
                            LastProp = (from p in db.BusinessProperties
                                        where p.BusinessObjectId == bo.Id
                                        orderby p.OrderIndex
                                        select p.DisplayName
                                        ).FirstOrDefault()
                        };

            var filteredProperties = db.BusinessProperties.Where(c => c.OrderIndex > 10).Select(c => c.Id);

            var q2 = db.BusinessModules
                .Select(module =>
            new Result
            {
                Id = module.Id,
                Name = module.DisplayName,
                Properties = module.BusinessObjects.SelectMany(bm => bm.BusinessProperties).Count(),
                LastProperty = db.BusinessProperties
                .Where(p => p.BusinessObject.BusinessModuleId == module.Id)
                .OrderBy(c => c.OrderIndex).Select(c => c.DisplayName)
                .FirstOrDefault(),

                AllProperties = db.BusinessProperties
                .Where(p => p.BusinessObject.BusinessModuleId == module.Id && filteredProperties.Contains(p.Id))
                .Select(c => new BP()
                {
                    Id = c.Id,
                    Name = c.DisplayName,
                    Type = c.BusinessPropertyType.DataType
                }).ToList()
            });

            // Expression.Call(db.BusinessObjects.GetType(), "Select", )
            //Expression.Lambda()
            var ex = query.Expression;
            var ex2 = q2.Expression;
            var sql = query.ToQueryString();
            var sql2 = q2.ToQueryString();
            var data = q2.ToList();

            Console.WriteLine("finish");
        }
    }
}