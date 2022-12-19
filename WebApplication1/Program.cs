using DynamicCRUD.Api;
using DynamicCRUD.Data;
using DynamicCRUD.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DynamicDbContext>((options) =>
            {
                options.UseSqlServer("Data Source=.; Initial Catalog=BookShopDb;Integrated Security=true; Trust Server Certificate=True");
                options.ReplaceService<IModelCacheKeyFactory, CustomModelCacheKeyFactory>();
            });
            builder.Services.AddSingleton<MetadataHolder>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseDynamicContext<DynamicDbContext>();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}