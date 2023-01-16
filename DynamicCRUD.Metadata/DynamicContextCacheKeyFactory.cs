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
            if(context is DynamicDbContext dynamicContext)
            {
                return (context.GetType(), dynamicContext.Version, designTime);
            }
            else
            {
                return (context.GetType());
            }
        }
    }
}
