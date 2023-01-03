
using DynamicContextConsoleClient.Models;
using DynamicCRUD.Data;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection.Emit;

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
            options.ReplaceService<IModelCacheKeyFactory, CustomModelCacheKeyFactory>();
            var db = new BookShopApiContext(options.Options);

            var cc = new DynamicQueryClass();
            //cc.CreateQuery(db);

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

            var filteredProperties = new List<int> { 1, 2, 3 };

            var q2 = db.BusinessModules
                .Select(module =>
            new Result
            {
                Id = module.Id,
                Name  = module.DisplayName,
                Properties = module.BusinessObjects.SelectMany(bm=>bm.BusinessProperties).Count(),
                LastProperty = db.BusinessProperties
                .Where(p => p.BusinessObject.BusinessModuleId == module.Id)
                .OrderBy(c => c.OrderIndex).Select(c => c.DisplayName)
                .FirstOrDefault(),
                
                AllProperties = db.BusinessProperties
                .Where(p => p.BusinessObject.BusinessModuleId == module.Id && filteredProperties.Contains(p.OrderIndex))
                .Select(c=>new BP() { 
                    Id=c.Id,
                    Name=c.DisplayName,
                    Type=c.BusinessPropertyType.DataType
                }).ToList()
            });

            // Expression.Call(db.BusinessObjects.GetType(), "Select", )
            //Expression.Lambda()
            var ex = query.Expression;
            var ex2 = q2.Expression;
            var sql = query.ToQueryString();
            var sql2 = q2.ToQueryString();
            var data = q2.ToList();

            Console.WriteLine( "finish");
        }
    }
}