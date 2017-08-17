using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CargoLogistic.Domain;
using NHibernate;

namespace CargoLogistic.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        private readonly ISession _session;

        private readonly List<T> _contextList = new List<T>(); // DbSet

        public Repository(ISession session)
        {
            _session = session;
        }


        public void Create(T entity)
        {
            _contextList.Add(entity);
        }

        public void Delete(T entity)
        {
            _contextList.Remove(entity);
        }

        public T Get(long Id)
        {
            return _session.Get<T>(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return _contextList;
        }

        public T GetById(long ID)
        {
            return _contextList.FirstOrDefault(x => x.Id == ID);
        }

        public T Load(long Id)
        {
            return _session.Load<T>(Id);
        }

        //public void SaveToFile(T entity, string filename)
        //{
        //    FileInfo f = new FileInfo(filename);
           
        //    using (StreamWriter stream = f.AppendText())
        //    {
        //        stream.WriteLine(entity.ToString());
        //        stream.Close();
        //    }
        //}

        public void Update(T entity)
        {
            int index = _contextList.IndexOf(entity);
            _contextList[index] = entity;
        }
    }
}
