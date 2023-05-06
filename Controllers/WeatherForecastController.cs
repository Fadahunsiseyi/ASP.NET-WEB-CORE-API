using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private NameService NameService {get; set;}


    public WeatherForecastController(ILogger<WeatherForecastController> logger, NameService nameService)
    {
        _logger = logger;
        NameService = nameService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        throw new InvalidNameException();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    [HttpPost(Name = "PostWeatherForecast")]
    public async Task<IActionResult> Post() 
    {
        return Ok("Weather forecast has been sent");
    }

    [HttpPut(Name = "PutWeatherForecast")]
    public async Task<IActionResult> Put(WeatherForecast weatherForecast) 
    {
        return Ok("Weather forecast has been updated");
    }

    [HttpDelete(Name = "DeleteWeatherForecast")]
    public async Task<IActionResult> Delete(int id) 
    {
        return Ok("Weather forecast has been deleted");
    }
}
