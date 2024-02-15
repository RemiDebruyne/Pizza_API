using Microsoft.EntityFrameworkCore;
using Pizza_API.Data;
using Pizza_API.Models;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Pizza_API.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>
    {
        public PizzaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Pizza> Add(Pizza entity)
        {
            var addEntry = await _dbContext.
                Set<Pizza>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            if (addEntry.Entity.Id > 0)
                return addEntry.Entity;

            return null;
        }

        public override async Task<Pizza?> Get(Expression<Func<Pizza, bool>> predicate)
        {
            return await _dbContext.Set<Pizza>().Include(p => p.Ingredients)
                .FirstOrDefaultAsync(predicate);
        }

        public  override async Task<IEnumerable<Pizza?>> GetAll()
        {
            return _dbContext.Set<Pizza>().Include(p => p.Ingredients);
        }

        public  override async Task<IEnumerable<Pizza?>> GetAll(Expression<Func<Pizza, bool>> predicate)
        {
            return _dbContext.Set<Pizza>().Include(p => p.Ingredients)
                .Where(predicate);
        }


    }
}
