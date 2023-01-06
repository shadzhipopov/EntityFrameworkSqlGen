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

        //public static IQueryable GenericSelect( IQueryable queryable, 
        //    ParameterExpression parentParam,
        //    string linkedEntityName)
        //{
        //    var propExpression = Expression.Property(parentParam, linkedEntityName);
        //    var listType = propExpression.Type.GetGenericArguments()[0];

        //    var selectCall =
        //        Expression.Call(
        //            typeof(Enumerable),
        //            nameof(Enumerable.Select),
        //            new[] { listType },
        //            propExpression
        //        );

        //    var lambda = Expression.Lambda(selectCall, parentParam);

        //    return queryable.Select(lambda);
        //}

        public void CreateQuery()
        {

            var bmParam = Expression.Parameter(typeof(BusinessModule), "bm");
            var bmQueryable = db.BusinessModules.AsQueryable();

            var symbols = new[] { bmParam };

            Expression body = new ExpressionParser(symbols,
                "bm.BusinessObjects.SelectMany(c => c.BusinessProperties).Select(c=>c.OrderIndex)", null, null).Parse(null, false);

          

          
            var enumerableMethods = typeof(Enumerable).GetMethods().ToList();
            var averageMethod = typeof(Enumerable).GetMethods()
               .FirstOrDefault(method => method.Name == "Average");


            Expression<Func<BusinessModule, IEnumerable<BusinessProperty>>> obs = (bo) => 
            bo.BusinessObjects.SelectMany(c=>c.BusinessProperties);

            //DynamicExpressionParser.ParseLambda(typeof(IEnumerable<BusinessProperty>), 
            //    "bo.BusinessObjects.SelectMany(c => c.BusinessProperties)", )


            var enumerableCount = Expression.Call(averageMethod, body);
            //return enumerableCount;

            //var newQ = boexp.SelectMany("BusinessObjectsId", bmParam);
            //var propQ = newQ.SelectMany("BusinessProperties");
            //var final = newQ.Select("OrderIndex");

            //var finalParam = Expression.Parameter(typeof(BusinessProperty), "c");
            //var propEp = Expression.Property(finalParam, "OrderIndex");
            //var lambda = Expression.Lambda(propEp, finalParam);


            //var selectExp = Expression.Call(typeof(Queryable), "Select", new Type[2]
            //{
            //    propQ.ElementType,
            //    lambda.Body.Type
            //}, propQ.Expression, Expression.Quote(lambda));
        }

        public IQueryable SelectMany(IQueryable source, string selector, params object[] values)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            // Parse the lambda
            LambdaExpression lambda =
                System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(source.ElementType, null, selector, values);

            // Fix lambda by recreating to be of correct Func<> type in case 
            // the expression parsed to something other than IEnumerable<T>.
            // For instance, a expression evaluating to List<T> would result 
            // in a lambda of type Func<T, List<T>> when we need one of type
            // an Func<T, IEnumerable<T> in order to call SelectMany().
            Type inputType = source.Expression.Type.GetGenericArguments()[0];
            Type resultType = lambda.Body.Type.GetGenericArguments()[0];
            Type enumerableType = typeof(IEnumerable<>).MakeGenericType(resultType);
            Type delegateType = typeof(Func<,>).MakeGenericType(inputType, enumerableType);
            lambda = Expression.Lambda(delegateType, lambda.Body, lambda.Parameters);

            // Create the new query
            return source.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable), "SelectMany",
                    new Type[] { source.ElementType, resultType },
                    source.Expression, Expression.Quote(lambda)));
        }

        //public Expression EnumerableSelectMany(IEnumerable<DynamicEntity> source, string selector, params object[] values)
        //{
        //    if (source == null)
        //        throw new ArgumentNullException("source");
        //    if (selector == null)
        //        throw new ArgumentNullException("selector");

        //          var selectCall =
        //        Expression.Call(
        //            typeof(Enumerable),
        //            nameof(Enumerable.SelectMany),
        //            new[] { typeof(IEnumerable<BusinessObject>) },
        //            propExpression
        //        );
        //        Expression.Call(
        //            typeof(IEnumerable), "SelectMany",
        //            new Type[] { source.ElementType, resultType },
        //            source.Expression, Expression.Quote(lambda)));
        //}
    }
}
