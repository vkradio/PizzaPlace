﻿namespace PizzaPlace.Shared
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Street { get; set; }

        public string? City { get; set; }
    }
}
