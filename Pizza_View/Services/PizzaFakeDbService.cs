using Pizza_View.Models;

namespace Pizza_View.Services
{
    public class PizzaFakeDbService : ICrudService<Pizza>
    {
        private int _lastId;

        private List<Pizza> _pizzas;

        public PizzaFakeDbService()
        {
            _pizzas =  InitialPizza.completePizzas;
        }


        public bool Delete(int id)
        {
            var nbRemoved = _pizzas.RemoveAll(m => m.Id == id);
            Console.WriteLine(_pizzas.Count);
            return nbRemoved == 1;
        }

        public bool Post(Pizza pizza)
        {
            pizza.Id = ++_lastId;
            _pizzas.Add(pizza);
            Console.WriteLine(_pizzas.Count);
            return true;
        }

        public List<Pizza> GetAll()
        {
            return _pizzas;
        }

    }
}
