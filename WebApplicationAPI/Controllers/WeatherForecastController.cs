using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> lista_weathers = new List<WeatherForecast>();


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if(lista_weathers == null || !lista_weathers.Any())
            {
                lista_weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToList();
            }
        }

        [HttpGet]
        [Route("Get/WeatherForecast")]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> GetObte()
        {
            _logger.LogDebug("Reportando la lista de WeatherForecast");
            return lista_weathers;
        }

        [HttpPost]
        public IActionResult post(WeatherForecast weather)
        {
            lista_weathers.Add(weather);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id) 
        {
            lista_weathers.RemoveAt(id);
            return Ok();
        }
    }
}