using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.GenericRepozitory
{
   public class EFRepozitor<TEntity> : IEFRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        DbSet<TEntity> _dbSet;

        public EFRepozitor(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public TEntity FindById(Guid id)
        {

            return _dbSet.Find(id);
        }

        public async Task<TEntity> FindAsyncMethod(Expression<Func<TEntity, bool>> predicate)
        {

            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task AddAsyn(TEntity item)
        {
            _dbSet.Add(item);
            await _context.SaveChangesAsync();
        }

        /* public IEnumerable<TEntity> GetEntities()
         {
             return _dbSet.ToList();
         }*/
        public TEntity FindById(Func<TEntity, bool> predicate)
        {

            var item = _dbSet.FirstOrDefault(predicate);

            return item;
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);

            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = _context.Entry(item).State;
            _context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            if (item != null)
            {
                //_context.Database.ExecuteSqlCommand("ALTER TABLE dbo.People ADD CONSTRAINT Peoples_Teams FOREIGN KEY (TeamId) REFERENCES dbo.Teams (Id) ON DELETE SET NULL");
                // _context.Entry(item).State = EntityState.Modified;
                //_dbSet.Attach(item);
                _dbSet.Remove(item);
                _context.SaveChanges();

            }
        }
        /* public async Task<TEntity> GetAsync(Expression< Func<TEntity, bool>> predicate)
         {
             return await _dbSet.FirstOrDefaultAsync(predicate);
         }*/
        public IQueryable<TEntity> IncludeGet(Expression<Func<TEntity, object>> includes)
        {


            IQueryable<TEntity> query = null;

            query = _dbSet.Include(includes);


            return query;
        }
        public int Count(Func<TEntity, bool> predicate)
        {
            return _dbSet.Count(predicate);
        }
        public int Count()
        {
            return _dbSet.Count();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetSort(Func<TEntity, string> predicate)
        {
            return _dbSet.AsNoTracking().OrderBy(predicate).ToList();
        }
    }
}

