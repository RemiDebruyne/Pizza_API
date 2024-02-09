using Pizza_API.Data;
using Pizza_API.Models;

namespace Pizza_API.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T? Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
