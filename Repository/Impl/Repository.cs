using Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Impl
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationContext _db;
        public Repository(ApplicationContext db)
        {
            _db = db;
        }
        public virtual EntityEntry<T> Add(T obj)
        {
            return _db.Set<T>().Add(obj);
        }

        public virtual T Find(Guid id)
        {
            return _db.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public virtual void Remove(T obj)
        {
            _db.Set<T>().Remove(obj);
        }

        public virtual EntityEntry<T> Update(T obj)
        {
            return _db.Set<T>().Update(obj);
        }

        public virtual void Dispose()
        {
            _db.Dispose();
        }

        public virtual void Commit()
        {
            _db.SaveChanges();
        }
    }
}
