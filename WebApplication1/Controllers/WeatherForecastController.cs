using DataAccess.DynamicContext;
using DataAccess.EntityFramework;
using DynamicCRUD.Data;
using DynamicCRUD.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private DynamicDbContext context;
        private readonly FdbaDbContext fdbaDbContext;

        public WeatherForecastController(DynamicDbContext context, FdbaDbContext fdbaDbContext)
        {
            this.context = context;
            this.fdbaDbContext = fdbaDbContext;
        }

        public object UpdateMetadata()
        {
            return "Metadata updated!";
        }

        [HttpGet]
        public object GetPendingMigrations()
        {
            return context.Database.GetPendingMigrations();
        }


        [HttpGet]
        public object UpdateDb()
        {
            this.context.Database.Migrate();
            return "DB Updated";
        }

        [HttpGet]
        public object Get()
        {
           // context.TestSelectManyParse();
            var timer = Stopwatch.StartNew();
            var request = new RequestObject()
            {
                TableName = "Employee",
                
                SelectType = SelectType.List,
                SelectProperties = new List<string>()
                { "JobTitle", "HireDate"}

            };
            CompareMetadata();
            var data = context.GetData(request);

            var time = timer.ElapsedMilliseconds;
            timer.Restart();
            var secondQuery = context.GetData(request);
            var sqTime = timer.ElapsedMilliseconds;

            return data;
        }

        private void CompareMetadata()
        {
            var loader = this.HttpContext.RequestServices.GetService<MetadataLoader>();

            var newHolder = new MetadataHolder() { Version = "1.1" };
            var builder = new EntityTypesBuilder(newHolder, loader);
            builder.CreateEntityTypes();
            
            var options = this.HttpContext.RequestServices.GetService<DbContextOptions>();
            var dynamicContext = new DynamicDbContext(options, newHolder);

            var modelComparer = context.GetService<IMigrationsModelDiffer>();

            var prevModel = this.context.GetService<IDesignTimeModel>().Model.GetRelationalModel();
            var actialModel = dynamicContext.GetService<IDesignTimeModel>().Model.GetRelationalModel();
            var actualDiff = modelComparer.GetDifferences(prevModel,actialModel);

        }
    }
}