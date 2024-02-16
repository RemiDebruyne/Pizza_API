using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Pizza_API.Data;
using Pizza_Core.Models;

namespace Pizza_API.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public virtual async Task<T> Add(T entity)
        {
           var addEntry = await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            if (addEntry.Entity.Id > 0)
                return addEntry.Entity;

            return null;
        }

        async virtual public Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return false;

            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        async virtual public Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
           return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        // Pourquoi pas de await
        async virtual public Task<IEnumerable<T?>> GetAll()
        {
            return _dbContext.Set<T>();
        }
        // Pourquoi pas de await
        async virtual public Task<IEnumerable<T?>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return  _dbContext.Set<T>().Where(predicate);
        }

        async virtual public Task<T> Update(T entity)
        {
            // Récupère la valeur de ma db pour comparer à la nouvelle
            var entityFromDb = await Get(e => e.Id == entity.Id);

            // Récupère le type de mon entity (elle est générique)
            // Je dois connaitre son type pour avoir accès à ses propriétées
            Type entityType = entity.GetType();

            // Récupère les propriétés dans mon type
            var entityProperties = entityType.GetProperties();

            // Itère sur chaque propriété de mon array de property info
            foreach (PropertyInfo property in entityProperties)
            {
                var valeurPropriete = property.GetValue(entity, null);
                var valeurProprieteFromDb = property.GetValue(entityFromDb, null);
                if (valeurProprieteFromDb != valeurPropriete)
                    valeurProprieteFromDb = valeurPropriete;
            }

            if (await _dbContext.SaveChangesAsync() == 0)
                return null;

            return entityFromDb;
        }
    }
}
