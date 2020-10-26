using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PizzaPlace.Shared
{
    public class Basket
    {
        public Customer Customer { get; set; } = new Customer();

        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Setter is required by System.Text.Json")]
        public List<int> Orders { get; set; } = new List<int>();

        public bool HasPaid { get; set; }

        public void Add(int pizzaId) => Orders.Add(pizzaId);

        public void RemoveAt(int pos) => Orders.RemoveAt(pos);
    }
}
