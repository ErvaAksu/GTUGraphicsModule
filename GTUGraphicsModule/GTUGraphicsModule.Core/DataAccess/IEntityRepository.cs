
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GTUGraphicsModule.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class
    {
        public Task<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        public Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        public Task<T> Add(T Entity);
        public Task<T> Update(T Entity);
        public Task<T> Remove(T Entity);
    }
}

