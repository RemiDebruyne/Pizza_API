using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pizza_Core.Models
{
    public class PizzaIngredient : BaseModel
    {
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public Pizza? Pizza { get; set; }
        public Ingredient? Ingredient { get; set; }

    }
}
