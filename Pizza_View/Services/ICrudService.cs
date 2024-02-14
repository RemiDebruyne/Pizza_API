using Pizza_View.Models;

namespace Pizza_View.Services
{
    public interface ICrudService<T> 
    {
        public bool Post(T entity);
        public bool Delete(int id);

        public List<T> GetAll();
    }
}
