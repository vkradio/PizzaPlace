using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaPlace.Client.Services
{
    public class MenuService : IMenuService
    {
        readonly HttpClient httpClient;

        public MenuService(HttpClient httpClient) => this.httpClient = httpClient;

        public async Task<Menu> GetMenu()
        {
            var pizzas = await httpClient.GetFromJsonAsync<Pizza[]>("/pizzas").ConfigureAwait(true);
            return new Menu { Pizzas = pizzas.ToList() };
        }
    }
}
