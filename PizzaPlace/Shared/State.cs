using System.Linq;

namespace PizzaPlace.Shared
{
    public class State
    {
        public Menu Menu { get; set; } = new Menu();

        public Basket Basket { get; set; } = new Basket();

        public AppUI UI { get; set; } = new AppUI();

        public decimal TotalPrice => Basket.Orders.Sum(id => Menu.GetPizza(id).Price);
    }
}
