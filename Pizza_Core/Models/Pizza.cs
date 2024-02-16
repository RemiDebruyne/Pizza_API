using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pizza_Core.Models
{
    [Table("pizzas")]
    public class Pizza : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsVege { get; set; }
        public string? ImagePath { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public List<PizzaIngredient>? PizzaIngredients { get; set; }

    }
}
