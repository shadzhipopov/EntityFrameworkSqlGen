using DynamicCRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DynamicDbContext context;

        public WeatherForecastController(DynamicDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public object Get()
        {
            var timer = Stopwatch.StartNew();
            var request = new RequestObject()
            {
                TableName = "Person",
                
                SelectType = SelectType.List,
                SelectProperties = new List<string>()
                { "FirstName", "Title", "LastName"}

            };
            context.Database.EnsureCreated();
            var data = context.GetData(request);

            var time = timer.ElapsedMilliseconds;
            timer.Restart();
            var secondQuery = context.GetData(request);
            var sqTime = timer.ElapsedMilliseconds;

            return data;
        }
    }
}