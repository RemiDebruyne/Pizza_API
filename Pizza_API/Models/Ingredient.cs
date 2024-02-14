using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_API.Models
{
    [Table("ingredients")]
    public class Ingredient : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Pizza> Pizzas { get; set; }
        public List<PizzaIngredient>? PizzaIngredients{ get; set; }

        public override string ToString()
        {
            return $"{Name} \n {Description}";
        }
    }
}
