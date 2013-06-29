using System;
using System.Collections.Generic;
using System.Linq;

namespace AviTracker.Web.Repositories
{
    public interface IRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> GetAll();
        IQueryable<TEntity> Query();
        TEntity Find(int id);
        TEntity Add(TEntity entity, bool persist);
        void Update(TEntity entity, int id);
        TEntity Delete(int id);
        void Save();
    }
}