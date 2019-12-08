using System;
using System.Linq;
using Flight.DataLayer.Entities;

namespace Flight.DataLayer.Repositories
{
    public interface IGenericRepository<T> where T :class, IEntity
    {
        IQueryable<T> Table { get; }
        T GetById(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Guid id);
    }
}