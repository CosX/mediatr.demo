using System.Collections.Generic;
using System.Threading.Tasks;
using mediart_demo.Pizza;
using mediart_demo.Weather;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mediart_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssortedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssortedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("weather")]
        public Task<IEnumerable<WeatherForecast>> Get() => _mediator.Send(new FetchWeatherForecast());
        
        [HttpGet("pizza")]
        public async Task<IActionResult> OrderPizza()
        {
            // The default implementation of Publish loops through the notification handlers and awaits each one. This ensures each handler is run after one another.
            // See https://github.com/jbogard/MediatR/tree/master/samples/MediatR.Examples.PublishStrategies for publishing strategies.
            await _mediator.Publish(new OrderPizza
            {
                Ingredients = new []
                {
                    "Cheese",
                    "Bread",
                    "Sauce",
                    "Pepperoni"
                }
            });
            
            return Ok(); 
        }
    }
}
