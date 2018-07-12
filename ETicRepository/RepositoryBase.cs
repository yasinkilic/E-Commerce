using ETicContext;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ETicRepository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(ProjectContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Ekle(T item)
        {
            _dbSet.Add(item);
        }

        public T GetElementById(int id)
        {
            T item = _dbSet.Find(id);
            return item;

        }

        public void Guncelle(T item)
        {
            _dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<T> Include(Expression<Func<T, bool>> filter, string children)
        {
            return _dbSet.Include(children).Where(filter);
        }
        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {

            return _dbSet.Where(filter);
        }
        public List<T> Listele()
        {
            return _dbSet.ToList();
        }

        public void Sil(int id)
        {
            T item = _dbSet.Find(id);
            _dbSet.Remove(item);
        }

    }
}
