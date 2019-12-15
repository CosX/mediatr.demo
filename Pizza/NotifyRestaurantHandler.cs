using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace mediart_demo.Pizza
{
    public class NotifyRestaurantHandler : INotificationHandler<OrderPizza>
    {
        private readonly ILogger<NotifyRestaurantHandler> _logger;

        public NotifyRestaurantHandler(ILogger<NotifyRestaurantHandler> logger)
        {
            _logger = logger;
        }
        
        public async Task Handle(OrderPizza notification, CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            _logger.LogInformation($"Restaurant got order at {DateTime.Now}. Will make pizza with {string.Join(", ", notification.Ingredients)}");
        }
    }
}