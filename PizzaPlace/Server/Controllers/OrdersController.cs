using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Shared;

namespace PizzaPlace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly PizzaPlaceDbContext db;

        public OrdersController(PizzaPlaceDbContext db) => this.db = db;

        [HttpPost("/orders")]
        public IActionResult CreateOrder([FromBody] Basket basket)
        {
            Guard.Against.Null(basket, nameof(basket));

            var customer = basket.Customer;
            var order = new Order();
            customer.Order = order;

            order.PizzaOrders = basket
                .Orders
                .Select(pizzaId => new PizzaOrder
                {
                    Pizza = db.Pizzas.Single(pizza => pizza.Id == pizzaId),
                    Order = order
                })
                .ToList();
            order.TotalPrice = order.PizzaOrders.Sum(po => po.Pizza.Price);

            db.Customers.Add(customer);
            db.SaveChanges();

            return Ok();
        }
    }
}
