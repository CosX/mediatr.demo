using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace mediart_demo.Pizza
{
    public class WarnAboutNinjaTurtlesHandler : INotificationHandler<OrderPizza>
    {
        private readonly ILogger<WarnAboutNinjaTurtlesHandler> _logger;

        public WarnAboutNinjaTurtlesHandler(ILogger<WarnAboutNinjaTurtlesHandler> logger)
        {
            _logger = logger;
        }
        
        public Task Handle(OrderPizza notification, CancellationToken cancellationToken)
        {
            if (notification.Ingredients.Contains("Pepperoni"))
                _logger.LogCritical("Oh crap! Michelangelo smells the PEPPERONI! RUN!");
            return Task.CompletedTask;
        }
    }
}