using DynamicContextConsoleClient.Models;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DynamicContextConsoleClient
{
    public class DynamicQueryClass
    {
        private Type CreateResultType()
        {
            var resultType = DynamicClassFactory.CreateType(new List<DynamicProperty>()
            {
                new DynamicProperty("Id", typeof(Guid)),
                new DynamicProperty("DisplayName", typeof(string)),
                    new DynamicProperty("Module", typeof(string)),
                    new DynamicProperty("Properties", typeof(int)),
                    new DynamicProperty("LastProperty", typeof(string))
            });
            return resultType;
        }

        //var q2 = db.BusinessObjects.Select(bo =>
        //    new Result
        //    {
        //        Id = bo.Id,
        //        DisplayName = bo.DisplayName,
        //        Module = bo.BusinessModule.DisplayName,
        //        Properties = bo.BusinessProperties.Count(),
        //        LastProperty = db.BusinessProperties.Where(p => p.BusinessObjectId == c.Id).OrderBy(c => c.OrderIndex).Select(c => c.DisplayName).FirstOrDefault()
        //    });

        public void CreateQuery(BookShopApiContext db)
        {
            Console.WriteLine("Times in miliseconds:");
            var timer = Stopwatch.StartNew();
            var dynset = (IQueryable<BusinessObject>)db.GetType()
             .GetMethod("Set", 1, Type.EmptyTypes)
             .MakeGenericMethod(typeof(BusinessObject)).Invoke(db, null);


            //https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression.memberinit?view=net-7.0
            //https://stackoverflow.com/questions/20424603/build-dynamic-select-using-expression-trees
            var resultType = CreateResultType();

            var resultTypeCreationTime = timer.ElapsedMilliseconds;
            Console.WriteLine("Result type creation: " + resultTypeCreationTime);
            timer.Restart();

            ParameterExpression parameter = Expression.Parameter(typeof(BusinessObject), "bo");
            var enumerableCountMethod = typeof(Enumerable).GetMethods()
                .First(method => method.Name == "Count" && method.GetParameters().Length == 1)
                .MakeGenericMethod(typeof(BusinessProperty));
            var lastPropExp = getnestedexp(db);
            var enumerableCount = Expression.Call(enumerableCountMethod, Expression.Property(parameter, nameof(BusinessObject.BusinessProperties)));

            var selectExpressionBody = Expression.MemberInit(
                Expression.New(resultType),
                new List<MemberBinding>() 
                {
                    Expression.Bind(resultType.GetProperty("Id"), GetPropertyPathExpression(parameter, nameof(BusinessObject.Id))),
                    Expression.Bind(resultType.GetProperty("DisplayName"), GetPropertyPathExpression(parameter, nameof(BusinessObject.DisplayName))),
                    Expression.Bind(resultType.GetProperty("Module"), GetPropertyPathExpression(parameter, "BusinessModule.DisplayName")),
                    Expression.Bind(resultType.GetProperty("Properties"), enumerableCount),
                    Expression.Bind(resultType.GetProperty("LastProperty"), lastPropExp)
                }
            );

            var selector = Expression.Lambda(selectExpressionBody, parameter);

            Expression expression = Expression.Call(typeof(Queryable), "Select", new Type[2]
            {
                dynset.ElementType,
                selector.Body.Type
            }, dynset.Expression, Expression.Quote(selector));

            var selectExpCreationTime = timer.ElapsedMilliseconds;
            Console.WriteLine("Select expression creation: " + selectExpCreationTime);
            timer.Restart();

            var query = dynset.Provider.CreateQuery(expression);
            var queryCreationTime = timer.ElapsedMilliseconds;

            Console.WriteLine("Query creation: " + queryCreationTime);
            timer.Restart();

            var data = query.ToDynamicList();
            var queryExecutionTime = timer.ElapsedMilliseconds;
            Console.WriteLine("Query execution: " + queryExecutionTime);

            var data2 = query.ToDynamicList();
            Console.WriteLine("Second time query (same) execution: " + queryExecutionTime);
            Console.ReadLine();
        }

        public Expression GetPropertyPathExpression(Expression param, string propertyName)
        {
            if (!propertyName.Contains("."))
            {
                return Expression.Property(param, propertyName);
            }
            var index = propertyName.IndexOf(".");
            //based on navigation property data - call .SelectMany for to many properties and keep that somewhere
            var subParam = Expression.Property(param, propertyName.Substring(0, index));
            return GetPropertyPathExpression(subParam, propertyName.Substring(index + 1));
        }

        private Expression getnestedexp(BookShopApiContext db)
        {
            var dynset = (IQueryable<BusinessProperty>)db.GetType()
            .GetMethod("Set", 1, Type.EmptyTypes)
            .MakeGenericMethod(typeof(BusinessProperty)).Invoke(db, null);

            var q = dynset
                //.Where()
                .OrderBy("OrderIndex")
                .Select(c => c.DisplayName);

            var exp = q.Expression;

            var selectParameterExpression = Expression.Parameter(q.Expression.Type.GetGenericArguments().Single(), "s");

            var eltype = GetElementType(q);
            var enumerableCountMethod = typeof(Queryable).GetMethods()
                .First(method => method.Name == "FirstOrDefault" && method.GetParameters().Length == 1)
                .MakeGenericMethod(typeof(string));

            var selectFirstOrDefaultMethodExpression = Expression.Call(enumerableCountMethod, exp) ;
            var selectLambda = Expression.Lambda(selectFirstOrDefaultMethodExpression, selectParameterExpression);

            return selectFirstOrDefaultMethodExpression;


        }

        // Walk until we get to the first non object element type
        private static Type GetElementType(IQueryable source)
        {
            Expression expr = source.Expression;
            Type elementType = source.ElementType;
            while (expr.NodeType == ExpressionType.Call &&
                   elementType == typeof(object))
            {
                var call = (MethodCallExpression)expr;
                expr = call.Arguments.First();
                elementType = expr.Type.GetGenericArguments().First();
            }

            return elementType;
        }
    }

    //public void CreateType()
    //{
    //    // Add a listener for the type resolve events.
    //    AppDomain currentDomain = Thread.GetDomain();
    //    AssemblyBuilder asmBuild = this.GetType().Assembly;
    //    ModuleBuilder modBuild = asmBuild.DefineDynamicModule("ModuleOne", "NestedEnum.dll");
    //    TypeBuilder tb = new TypeBuilder(); 

    //        modBuild.DefineType("Result", TypeAttributes.Public);

    //    tb.DefineField("Field2", eb, FieldAttributes.Public);


    //}
}

