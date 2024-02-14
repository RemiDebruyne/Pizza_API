namespace Pizza_View.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set;}
    }
}
