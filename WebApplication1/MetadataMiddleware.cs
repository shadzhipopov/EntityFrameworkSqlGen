using DataAccess.DynamicContext;
using DataAccess.EntityFramework;
using DynamicCRUD.Metadata;

namespace DynamicCRUD.Api
{
    public class MetadataMiddleware<TContext> where TContext : DynamicDbContext
    {
        private readonly RequestDelegate _next;

        public MetadataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            FdbaDbContext fdbaDbContext,
            MetadataHolder metadataHolder,
            TContext dbContext)
        {   
            
            bool shouldCreateTyes = false;
            if (metadataHolder.Version != dbContext.Version || (metadataHolder.Entities == null || metadataHolder.Entities.Count == 0))
            {
                shouldCreateTyes = true;
            }
            if (shouldCreateTyes)
            {
                EntityTypesBuilder typesBuilder = new EntityTypesBuilder(metadataHolder, fdbaDbContext);
                typesBuilder.CreateEntityTypes();
            }

            dbContext.Version  = metadataHolder.Version;

            await _next.Invoke(context);
        }
    }

    public static class DynamicContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseDynamicContext<TContext>(this WebApplication builder) where TContext : DynamicDbContext
        {
            return builder.UseMiddleware<MetadataMiddleware<TContext>>();
        }
    }
}
