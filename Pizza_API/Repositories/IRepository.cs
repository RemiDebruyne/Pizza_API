using System.Linq.Expressions;
using Pizza_Core.Models;


namespace Pizza_API.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {

        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(int id);
        public Task<T?> Get(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T?>> GetAll();
        public Task<IEnumerable<T?>> GetAll(Expression<Func<T, bool>> predicate);
    }
}
