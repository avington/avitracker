using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AviTracker.Web.Models.ContextConfiguration;

namespace AviTracker.Web.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;
        protected ProjectTrackerContext Context;

        protected BaseRepository()
        {
            Context = new ProjectTrackerContext();
            _dbSet = Context.Set<T>();
        }

        public void Update(T entity, int id)
        {
            var current = _dbSet.Find(id);
            Context.Entry(current).CurrentValues.SetValues(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public T Delete(int id)
        {
            T item = Find(id);
            if (item != null)
            {
                Context.Entry(item).State = EntityState.Deleted;
            }
            return item;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}