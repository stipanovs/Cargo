using System;
using System.Collections.Generic;
using CargoLogistic.Domain.Entities;

namespace CargoLogistic.Domain.Repository
{
    public interface IRepository<T> where T: EntityBase
    {
        
        T Load(long Id);
        T GetById(long Id);
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        
    }
}
