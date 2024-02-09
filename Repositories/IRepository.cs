using System.Linq.Expressions;
using Pizza_API.Models;

namespace Pizza_API.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {

        public bool Add(T entity);
        public bool Update(T entity);
        public bool Delete(int id);
        public T? Get(Expression<Func<T, bool>> predicate);
        public IEnumerable<T>? GetAll();
        public IEnumerable<T>? GetAll(Expression<Func<T, bool>> predicate);
    }
}
