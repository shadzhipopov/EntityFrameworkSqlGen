using DynamicCRUD.Data;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System.Linq.Dynamic.Core;

namespace DynamicContextConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlServer("Data Source=BookShopDb; Initial Catalog=MetaEntities;Integrated Security=true");
            options.ReplaceService<IModelCacheKeyFactory, CustomModelCacheKeyFactory>();
            DynamicDbContext context = new DynamicDbContext(options.Options);
            GetCodelessEntity(new RequestObject() 
            {
                TableName = "Book",
                SelectType = SelectType.List,
                SelectProperties = new List<string>()
                { "Id", "Title"}

            }, context);


        }

        public class RequestObject
        {
            public string TableName { get; set; }
            public List<string> SelectProperties { get; set; }
            public SelectType SelectType { get; set; }
        }

        public enum SelectType
        {
            Single,
            List
        }

        public static async void GetCodelessEntity(RequestObject requestObject, DynamicDbContext _dynamicDbContext)
        {
            var metadataEntityName = requestObject.TableName;
            var metadata = new MetadataEntity();  //Find and get your type from json 
            
            object response = null;
            var metadataQuerySet = (IQueryable<DynamicEntity>)_dynamicDbContext.GetType().GetMethod("Set").MakeGenericMethod(metadata.EntityType).Invoke(_dynamicDbContext, null);
// var filters = requestObject["Filters"].ToList();

            string selects = "*";

            if (requestObject.SelectProperties != null)
            {
                selects = string.Join(',', requestObject.SelectProperties.ToList());
            }

            //var i = 0;
            //foreach (var filter in filters)
            //{
            //    var filterValue = requestObject["FilterValues"].ElementAt(i).ToString();
            //    i++;
            //    metadataQuerySet = metadataQuerySet.Where(filter.ToString(), filterValue);
            //}

            if (requestObject.SelectType == SelectType.List)
            {
                if (selects == "*")
                    response = await metadataQuerySet.ToDynamicListAsync();
                else
                    response = await metadataQuerySet.Select($"new ({selects})").ToDynamicListAsync();
            }

            if (requestObject.SelectType == SelectType.Single)
                if (selects == "*")
                {
                    response = await metadataQuerySet.FirstOrDefaultAsync();
                }
                else
                {
                    response = await metadataQuerySet.Select($"new ({selects})").FirstOrDefault();
                }


        }
    }
}