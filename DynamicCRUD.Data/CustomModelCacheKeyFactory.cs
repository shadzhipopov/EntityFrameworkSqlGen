using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace DynamicCRUD.Data
{
    public class CustomModelCacheKeyFactory : IModelCacheKeyFactory
    {

        public object Create(DbContext context, bool designTime)
           => new CustomModelCacheKey(context);
    }
}
