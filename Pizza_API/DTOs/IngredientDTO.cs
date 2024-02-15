using Newtonsoft.Json;
using Pizza_API.Models;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Pizza_API.DTOs
{
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Pizza>? Pizzas { get; set; }
    }
}
