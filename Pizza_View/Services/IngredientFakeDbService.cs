using Pizza_View.Models;

namespace Pizza_View.Services
{
    public class IngredientFakeDbService : ICrudService<Ingredient>
    {
        private int _lastId;
        private List<Ingredient> _ingredient = InitialPizza.ingredients;


        public bool Delete(int id)
        {
            var nbRemoved = _ingredient.RemoveAll(m => m.Id == id);
            Console.WriteLine(_ingredient.Count);
            return nbRemoved == 1;
        }

        public List<Ingredient> GetAll()
        {
            return _ingredient;
        }

        public bool Post(Ingredient ingredient)
        {
            ingredient.Id = ++_lastId;
            _ingredient.Add(ingredient);
            Console.WriteLine(_ingredient.Count);
            return true;
        }
    }
}
