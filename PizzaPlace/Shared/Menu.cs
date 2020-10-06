using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PizzaPlace.Shared
{
    public class Menu
    {
        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "For educational simplicity")]
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public Pizza GetPizza(int id) => Pizzas.SingleOrDefault(pizza => pizza.Id == id);
    }
}
