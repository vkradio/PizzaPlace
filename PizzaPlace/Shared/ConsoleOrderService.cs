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
            Console.WriteLine($"number of pizzas: {basket.Orders.Count}");
            foreach (var pizza in basket.Orders)
            {
                Console.WriteLine($"- ordered: id = {pizza}");
            }

            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
