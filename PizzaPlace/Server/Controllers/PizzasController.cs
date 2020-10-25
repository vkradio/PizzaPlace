using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Shared;

namespace PizzaPlace.Server.Controllers
{
    [ApiController]
    public class PizzasController : ControllerBase
    {
        readonly PizzaPlaceDbContext db;

        public PizzasController(PizzaPlaceDbContext db) => this.db = db;

        [HttpGet("pizzas")]
        public IQueryable<Pizza> GetPizzas() => db.Pizzas;

        [HttpPost("pizzas")]
        [SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "No danger")]
        public IActionResult InsertPizza([FromBody] Pizza pizza)
        {
            Guard.Against.Null(pizza, nameof(pizza));

            db.Pizzas.Add(pizza);
            db.SaveChanges();

            return Created($"pizzas/{pizza.Id}", pizza);
        }
    }
}
