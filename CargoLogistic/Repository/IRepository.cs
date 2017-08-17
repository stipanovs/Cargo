using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic;
using CargoLogistic.Domain;

namespace CargoLogistic.Repository
{
    public interface IRepository<T> where T: EntityBase
    {
        T Get(long Id);
        T Load(long Id);
        T GetById(long Id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        
    }
}
