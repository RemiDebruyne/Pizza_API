using Pizza_Core.Models;
using System.Linq.Expressions;

namespace Pizza_View.Services
{
    public interface IService
    {
        public Task<Pizza> Add(Pizza entity);
        public Task<Pizza> Update(Pizza entity);
        public Task<bool> Delete(int id);
        public Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate);
        public Task<IEnumerable<Pizza?>> GetAll();
        public Task<IEnumerable<Pizza?>> GetAll(Expression<Func<Pizza, bool>> predicate);
    }
}
