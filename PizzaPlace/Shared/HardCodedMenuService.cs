using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
    public class HardCodedMenuService : IMenuService
    {
        public Task<Menu> GetMenu() => Task.FromResult(
            new Menu
            {
                Pizzas = new List<Pizza>
                {
                    new Pizza(1, "Pepperoni", 8.99m, Spiciness.Spicy),
                    new Pizza(2, "Margarita", 7.99m, Spiciness.None),
                    new Pizza(3, "Diabolo", 9.99m, Spiciness.Hot)
                }
            }
        );
    }
}
