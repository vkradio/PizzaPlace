using System;

namespace PizzaPlace.Shared
{
    public enum Spiciness
    {
        None,
        Spicy,
        Hot
    }

    public class Pizza
    {
        public Pizza(int id, string? name, decimal price, Spiciness spiciness) =>
            (Id, Name, Price, Spiciness) =
            (id, name ?? throw new ArgumentNullException(nameof(name), "A pizza needs a name!"), price, spiciness);

        public int Id { get; }

        public string Name { get; }

        public decimal Price { get; }

        public Spiciness Spiciness { get; }
    }
}
