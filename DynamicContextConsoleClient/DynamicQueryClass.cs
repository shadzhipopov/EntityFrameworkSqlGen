using DynamicContextConsoleClient.Models;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
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
        //        Properties = bo.BusinessProperties.Count(),
        //        LastProperty = db.BusinessProperties.Where(p => p.BusinessObjectId == c.Id).OrderBy(c => c.OrderIndex).Select(c => c.DisplayName).FirstOrDefault()
        //    });

        public void CreateQuery(BookShopApiContext db)
        {

            var dynset = (IQueryable<BusinessObject>)db.GetType()
         .GetMethod("Set", 1, Type.EmptyTypes)
         .MakeGenericMethod(typeof(BusinessObject)).Invoke(db, null);

            //var metadataQuerySet = db.BusinessObjects.AsQueryable();

            //https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression.memberinit?view=net-7.0
            //https://stackoverflow.com/questions/20424603/build-dynamic-select-using-expression-trees
            var resultType = CreateResultType();
            ParameterExpression parameter = Expression.Parameter(typeof(BusinessObject), "bo");
            var enumerableCountMethod = typeof(Enumerable).GetMethods()
.First(method => method.Name == "Count" && method.GetParameters().Length == 1)
.MakeGenericMethod(typeof(BusinessProperty));
            var count2 = Expression.Call(enumerableCountMethod, Expression.Property(parameter, nameof(BusinessObject.BusinessProperties)));

            var selectExpressionBody = Expression.MemberInit(
                Expression.New(resultType),
                new List<MemberBinding>() {
                    Expression.Bind(resultType.GetProperty("Id"), GetPropertyPathExpression(parameter, nameof(BusinessObject.Id))),
                    Expression.Bind(resultType.GetProperty("DisplayName"), GetPropertyPathExpression(parameter, nameof(BusinessObject.DisplayName))),
                    Expression.Bind(resultType.GetProperty("Module"), GetPropertyPathExpression(parameter, "BusinessModule.DisplayName")),
                    Expression.Bind(resultType.GetProperty("Properties"), count2)
                }
            );

            var selector = Expression.Lambda(selectExpressionBody, parameter);

            Expression expression = Expression.Call(typeof(Queryable), "Select", new Type[2]
            {
                dynset.ElementType,
                selector.Body.Type
            }, dynset.Expression, Expression.Quote(selector));

            var query = dynset.Provider.CreateQuery(expression);
            var data = query.ToDynamicList();

        }

        public Expression GetPropertyPathExpression(Expression param, string propertyName)
        {
            if (!propertyName.Contains("."))
            {
                return Expression.Property(param, propertyName);
            }
            var index = propertyName.IndexOf(".");
            var subParam = Expression.Property(param, propertyName.Substring(0, index));
            return GetPropertyPathExpression(subParam, propertyName.Substring(index + 1));
        }

        private void CQ()
        {
            var context = new BookShopApiContext();

            var businessModules = context.Set<BusinessModule>();
            var businessProperties = context.Set<BusinessProperty>();

            var dataview = businessModules.AsQueryable();

            var dynamicFields = new Dictionary<string, Type>();
            dynamicFields.Add("FirstName", typeof(string));
            dynamicFields.Add("LastName", typeof(string));
            dynamicFields.Add("LastTransaction", typeof(DateTime?));

            Type dynamicType = CreateResultType();

            ParameterExpression sourceItem = Expression.Parameter(dataview.ElementType, "x");

            // Is this right? if if so how do I bind it to the dynamic field????
            //Expression<Func<Person, DateTime>> lastTransactionSelect = a => transactions.Where(t => t.AuthorizedPersonId == a.Id && t.TransactionDateTime.HasValue).Max(t => t.TransactionDateTime.Value);

            var bindings = new List<MemberBinding>();
            bindings.Add(Expression.Bind(dynamicType.GetField("FirstName"), Expression.Property(sourceItem, dataview.ElementType.GetProperty("FirstName"))));
            bindings.Add(Expression.Bind(dynamicType.GetField("LastName"), Expression.Property(sourceItem, dataview.ElementType.GetProperty("LastName"))));
            // bindings.Add(Expression.Bind(dynamicType.GetField("LastTransaction"), ??? ));

            Expression selector = Expression.Lambda(Expression.MemberInit(Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)), bindings), sourceItem);

            var query = dataview.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    "Select",
                    new Type[] { dataview.ElementType, dynamicType },
                Expression.Constant(dataview), selector)).ToDynamicList();

            // Can't bind directly to the query since it's a DBQuery object
            //gReport.DataSource = ???;

            //gReport.DataBind();
        }

        //        private void somemethod()
        //        {
        //            ParameterExpression transactionParameter = Expression.Parameter(typeof(FinancialTransaction), "t");
        //            MemberExpression authorizedPersonIdProperty = Expression.Property(transactionParameter, "AuthorizedPersonId");
        //            MemberExpression transactionDateTime = Expression.Property(transactionParameter, "TransactionDateTime");

        //            MethodInfo whereMethod = GetWhereMethod();
        //            MethodInfo maxMethod = GetMaxMethod();

        //            var personIdCompare = new Expression[] {
        //    Expression.Constant(transactions),
        //    Expression.Lambda<Func<FinancialTransaction, bool>>( Expression.Equal(authorizedPersonIdProperty, Expression.Convert(idProperty, typeof(int?))), new ParameterExpression[] { transactionParameter } )
        //};
        //            var transactionDate = Expression.Lambda<Func<FinancialTransaction, DateTime?>>(transactionDateTime, new ParameterExpression[] { transactionParameter });
        //            var lastTransactionDate = Expression.Call(null, maxMethod, new Expression[] { Expression.Call(null, whereMethod, personIdCompare), transactionDate });


        //            bindings.Add(Expression.Bind(dynamicType.GetField("LastTransaction"), lastTransactionDate));



        //        }

        //private MethodInfo GetWhereMethod()
        //{
        //    Func<FinancialTransaction, bool> fake = element => default(bool);
        //    Expression<Func<IEnumerable<FinancialTransaction>, IEnumerable<FinancialTransaction>>> lamda = list => list.Where(fake);
        //    return (lamda.Body as MethodCallExpression).Method;
        //}

        //private MethodInfo GetMaxMethod()
        //{
        //    Func<FinancialTransaction, DateTime?> fake = element => default(DateTime?);
        //    Expression<Func<IEnumerable<FinancialTransaction>, DateTime?>> lamda = list => list.Max(fake);
        //    return (lamda.Body as MethodCallExpression).Method;
        //}
    }
}
