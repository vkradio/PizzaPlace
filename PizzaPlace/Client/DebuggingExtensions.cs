using Ardalis.GuardClauses;
using System.Text.Json;

namespace PizzaPlace.Client
{
    public static class DebuggingExtensions
    {
        public static string ToJson(this object obj)
        {
            Guard.Against.Null(obj, nameof(obj));

            return JsonSerializer.Serialize(obj, obj.GetType(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
    }
}
