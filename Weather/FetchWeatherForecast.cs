using System.Collections.Generic;
using MediatR;

namespace mediart_demo.Weather
{
    public class FetchWeatherForecast : IRequest<IEnumerable<WeatherForecast>>{ }
}