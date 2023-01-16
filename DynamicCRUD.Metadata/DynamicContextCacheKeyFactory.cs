using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DynamicContext
{
    public class DynamicContextCacheKeyFactory : IModelCacheKeyFactory
    {
        public DynamicContextCacheKeyFactory()
        {
        }

        public object Create(DbContext context, bool designTime)
        {
            return context is DynamicDbContext dynamicContext
            ? (context.GetType(), dynamicContext.Version, designTime)
            : (object)context.GetType();
        }
    }
}
