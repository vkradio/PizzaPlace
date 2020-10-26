using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Server
{
    public class PizzaPlaceDbContext : DbContext
    {
        public PizzaPlaceDbContext(DbContextOptions<PizzaPlaceDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guard.Against.Null(modelBuilder, nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);

            var pizzaEntity = modelBuilder.Entity<Pizza>();
            pizzaEntity.HasKey(pizza => pizza.Id);
            pizzaEntity.Property(pizza => pizza.Price).HasColumnType("money");

            var customerEntity = modelBuilder.Entity<Customer>();
            customerEntity.HasKey(customer => customer.Id);
            customerEntity
                .HasOne(customer => customer.Order)
                .WithOne(order => order!.Customer)
                .HasForeignKey<Order>(order => order.CustomerId);

            var orderEntity = modelBuilder.Entity<Order>();
            orderEntity.HasKey(order => order.Id);
            //orderEntity
            //    .HasMany(order => order.PizzaOrders)
            //    .WithOne(pizzaOrder => pizzaOrder.Order);
            orderEntity.Property(order => order.TotalPrice).HasColumnType("money");

            var pizzaOrderEntity = modelBuilder.Entity<PizzaOrder>();
            pizzaOrderEntity
                .HasOne(po => po.Pizza)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            pizzaOrderEntity
                .HasOne(po => po.Order)
                .WithMany(order => order.PizzaOrders)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
