using Ardalis.GuardClauses;
using System;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
    public class ConsoleOrderService : IOrderService
    {
        public async Task PlaceOrder(Basket basket)
        {
            Guard.Against.Null(basket, nameof(basket));

            Console.WriteLine($"Placing order for {basket.Customer.Name}");

            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
