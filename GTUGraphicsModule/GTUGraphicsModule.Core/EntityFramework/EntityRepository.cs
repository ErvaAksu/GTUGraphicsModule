using GTUGraphicsModule.Core.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace GTUGraphicsModule.Core.EntityFramework
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class

    {
        protected readonly DbContext _dbContext;
        public EntityRepository(DbContext context)
        {
            _dbContext = context;
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> queryable = _dbContext.Set<T>();

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (includes is { Length: > 0 })
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }

            return queryable.AsNoTracking().SingleOrDefault();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (includes is { Length: > 0 })
            {
                queryable = includes.Aggregate(queryable, (current, include) => current.Include(include));
            }

            return await queryable.AsNoTracking().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            var added = _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
            return added.Result.Entity;
        }
        public async Task<T> Update(T entity)
        {
            var updated = _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return updated.Entity;
        }

        public async Task<T> Remove(T Entity)
        {
            var deleted = _dbContext.Remove(Entity);
            _dbContext.SaveChanges();
            return deleted.Entity;
        }

    }
}

