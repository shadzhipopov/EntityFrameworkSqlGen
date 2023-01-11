using DataAccess.Entities;
using DynamicCRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DynamicDbContext context;
        private readonly FdbaDbContext fdbaDbContext;

        public WeatherForecastController(DynamicDbContext context, FdbaDbContext fdbaDbContext)
        {
            this.context = context;
            this.fdbaDbContext = fdbaDbContext;
        }

        [HttpGet]
        public object Get()
        {
            context.TestSelectManyParse();
            var timer = Stopwatch.StartNew();
            var request = new RequestObject()
            {
                TableName = "Person",
                
                SelectType = SelectType.List,
                SelectProperties = new List<string>()
                { "FirstName", "Title", "LastName", "BusinessEntity.ModifiedDate"}

            };
            context.Database.EnsureCreated();
            context.Database.Migrate();
            var data = context.GetData(request);

            var time = timer.ElapsedMilliseconds;
            timer.Restart();
            var secondQuery = context.GetData(request);
            var sqTime = timer.ElapsedMilliseconds;

            return data;
        }
    }
}