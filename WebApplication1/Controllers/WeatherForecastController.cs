using DynamicCRUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
            var request = new RequestObject()
            {
                TableName = "Book",
                SelectType = SelectType.List,
                SelectProperties = new List<string>()
                { "Id", "Title", "Category.Title as CatTitle"}

            };
            context.Database.EnsureCreated();
            var data = context.GetData(request);

            return data;
        }
    }
}