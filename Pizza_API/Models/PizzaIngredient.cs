namespace Pizza_API.Models
{
    public class PizzaIngredient : BaseModel
    {
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
    }
}
