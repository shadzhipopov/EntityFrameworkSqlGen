
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
    internal class Program
    {
        //we must have the result types in advance
        //recursive CTEs are still not possible with LINQ
        //https://michaelceber.medium.com/implementing-a-recursive-projection-query-in-c-and-entity-framework-core-240945122be6
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<BookShopApiContext>();
            //options.UseNpgsql("server=localhost;user id=postgres;password=1234;database=FdbaDb");
            options.UseSqlServer("server=.;database=FdbaDb;integrated security=True;Trust Server Certificate=True;");
            options.ReplaceService<IModelCacheKeyFactory, CustomModelCacheKeyFactory>();
            var db = new BookShopApiContext(options.Options);

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



            // Expression.Call(db.BusinessObjects.GetType(), "Select", )
            //Expression.Lambda()
            var ex = query.Expression;
            var sql = query.ToQueryString();
            var data = query.ToList();
            var resultType = DynamicClassFactory.CreateType(new List<DynamicProperty>()
            {
                new DynamicProperty("Id", typeof(Guid)),
                new DynamicProperty("DisplayName", typeof(string)),
                    new DynamicProperty("Module", typeof(string)),
                    new DynamicProperty("Properties", typeof(int)),
                    new DynamicProperty("LastProperty", typeof(string))
            });
        //https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression.memberinit?view=net-7.0
        //https://stackoverflow.com/questions/20424603/build-dynamic-select-using-expression-trees

            //var testExpr= Expression.MemberInit(
            //    db.BusinessObjects,
            //    new List<MemberBinding>() {
            //        Expression.Bind(resultType.GetProperty("Id"), Expression.Constant(Guid.NewGuid())),
                    
            //    }
            //);

            //var test = Expression.Lambda<Func<object>>(testExpr).Compile()();

            Console.WriteLine("Hello, World!");
            //DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            //options.UseSqlServer("Data Source=BookShopDb; Initial Catalog=MetaEntities;Integrated Security=true");
            //options.ReplaceService<IModelCacheKeyFactory, CustomModelCacheKeyFactory>();
            //DynamicDbContext context = new DynamicDbContext(options.Options);
            //var data = context.GetData(new RequestObject() 
            //{
            //    TableName = "Book",
            //    SelectType = SelectType.List,
            //    SelectProperties = new List<string>()
            //    { "Id", "Title"}

            //});


        }

        static void CreateSelectExpression()
        {
        }
    }
}