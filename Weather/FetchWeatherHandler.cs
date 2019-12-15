using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace mediart_demo.Weather
{
    public class FetchWeatherForecastHandler : IRequestHandler<FetchWeatherForecast, IEnumerable<WeatherForecast>>
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<FetchWeatherForecastHandler> _logger;

        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public FetchWeatherForecastHandler(IMemoryCache cache, ILogger<FetchWeatherForecastHandler> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public Task<IEnumerable<WeatherForecast>> Handle(FetchWeatherForecast request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _cache.GetOrCreate("random", entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromMinutes(1);
                    _logger.LogInformation("initializing new random weather");
                    var rng = new Random();
                    var val = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    });
                    return val;
                }));
        }
    }
}