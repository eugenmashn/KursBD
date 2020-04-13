using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.GenericRepozitory
{
   public interface IEFRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        TEntity FindById(Guid id);
        TEntity FindById(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        int Count(Func<TEntity, bool> predicate);
        int Count();
        Task<TEntity> FindAsyncMethod(Expression<Func<TEntity, bool>> predicate);
        Task AddAsyn(TEntity item);
        IEnumerable<TEntity> GetSort(Func<TEntity, string> predicate);
        void Update(TEntity item);
        IQueryable<TEntity> IncludeGet(Expression<Func<TEntity, object>> includes);
    }
}
