using DynamicContextConsoleClient.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Collections;
using DynamicCRUD.Metadata;
using System.Reflection.Metadata;
using System.Linq.Dynamic.Core.Parser;

namespace DynamicContextConsoleClient
{
    public class SelectManySample
    {
        private readonly BookShopApiContext db;

        public SelectManySample(BookShopApiContext db)
        {
            this.db = db;
        }

        public void TargetLinqQuery()
        {
            var aggQuery = db.BusinessModules.Select(bm => new
            {
                bm.Id,
                Objects = bm.BusinessObjects.Count(),
                AverageOrderIndex =
                
                 bm.BusinessObjects
                 .SelectMany(c => c.BusinessProperties)
                 .Select(c => c.OrderIndex)
                 .Average(),

            });

            var aggsql = aggQuery.ToQueryString();
        }

        private static IQueryable WrapInSelect(

     IQueryable current, string methodName, Type[] selectFromToTypes,
     Expression selectLambda)
        {
            Expression expression = Expression.Call(
                typeof(Queryable), methodName,
                selectFromToTypes,
                current.Expression,
                selectLambda);
            return current.Provider.CreateQuery(expression);
        }

        private static IQueryable WrapInSelectMany(IQueryable inner,
     Type inputType,
      string navigationProperty)
        {

            ParameterExpression p = Expression.Parameter(inputType, "c");
            var prop = Expression.Property(p, navigationProperty);
            var lambda = Expression.Lambda(prop, p);
            Type resultType = lambda.Body.Type.GetGenericArguments()[0];
            Type enumerableType = typeof(IEnumerable<>).MakeGenericType(resultType);
            Type delegateType = typeof(Func<,>).MakeGenericType(inputType, enumerableType);
            var selectManyLambda = Expression.Lambda(delegateType, lambda.Body, lambda.Parameters);


            Expression expression = Expression.Call(
            typeof(Queryable),
                "SelectMany",
                new Type[2] {
                    inner.ElementType,
                    resultType
                },
                inner.Expression,
                Expression.Quote(selectManyLambda));

            return inner.Provider.CreateQuery(expression);
        }

        public void CreateQuery()
        {

            var bmParam = Expression.Parameter(typeof(BusinessModule), "bm");
            var bmQueryable = db.BusinessModules.AsQueryable();


          
            var enumerableMethods = typeof(Enumerable).GetMethods().ToList();
            var averageMethod = typeof(Enumerable).GetMethods()
               .FirstOrDefault(method => method.Name == "Average");


            Expression<Func<BusinessModule, IEnumerable<BusinessProperty>>> obs = (bo) => 
            bo.BusinessObjects.SelectMany(c=>c.BusinessProperties);

        }
    }
}
