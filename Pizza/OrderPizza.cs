using System.Collections.Generic;
using MediatR;

namespace mediart_demo.Pizza
{
    public class OrderPizza : INotification
    {
        public IEnumerable<string> Ingredients { get; set; }
    }
}