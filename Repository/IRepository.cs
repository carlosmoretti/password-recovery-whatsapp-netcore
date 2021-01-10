using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        EntityEntry<T> Add(T obj);
        EntityEntry<T> Update(T obj);
        void Remove(T obj);
        IEnumerable<T> GetAll();
        T Find(Guid id);
        void Commit();
    }
}
