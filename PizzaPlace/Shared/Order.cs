using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PizzaPlace.Shared
{
    public class Order
    {
        public int Id { get; set; }

        public Customer Customer { get; set; } = default!;

        public int CustomerId { get; set; }


        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Needed (?) by EF Core")]
        public List<PizzaOrder> PizzaOrders { get; set; } = default!;

        public decimal TotalPrice { get; set; }
    }
}
