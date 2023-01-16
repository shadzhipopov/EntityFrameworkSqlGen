using DataAccess.DynamicContext;
using DataAccess.EntityFramework;
using DynamicCRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
                TableName = "Person",
                
                SelectType = SelectType.List,
                SelectProperties = new List<string>()
                { "FirstName", "Title", "LastName"}

            };

            var databaseCreator = context.GetService<IRelationalDatabaseCreator>();
            var createScript = databaseCreator.GenerateCreateScript();
            var migrator = context.GetInfrastructure().GetService<IMigrator>();
            var pm = migrator.GenerateScript();
            migrator.Migrate();
            var data = context.GetData(request);

            var time = timer.ElapsedMilliseconds;
            timer.Restart();
            var secondQuery = context.GetData(request);
            var sqTime = timer.ElapsedMilliseconds;

            return data;
        }
    }
}