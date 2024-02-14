using Microsoft.EntityFrameworkCore;
using Pizza_API.Models;

namespace Pizza_API.DTOs
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Precision(37, 2)]
        public decimal Price { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsVege { get; set; }
        public string? ImagePath { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

        public List<PizzaIngredient>? PizzaIngredients { get; set; }
    }
}
