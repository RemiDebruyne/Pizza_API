using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza_View.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsVege { get; set; }
        public string? ImagePath { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

    }
}
