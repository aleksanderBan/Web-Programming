using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Weatherforecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("summaries")]
        public ActionResult<IEnumerable<string>> GetAllSummaries()
        {
            return Ok(Summaries);
        }

        [HttpPost]
        public ActionResult PostWeatherForecast(WeatherForecast forecast)
        {
            // Here you would typically save the forecast to your data store or perform other operations.
            // For simplicity, let's just return the posted forecast.
            return Ok(forecast);
        }

        private static List<WeatherForecast> storedForecasts = new List<WeatherForecast>();

        [HttpGet("stored")]
        public ActionResult<IEnumerable<WeatherForecast>> GetAllStoredWeatherForecasts()
        {
            return Ok(storedForecasts);
        }

    }
}