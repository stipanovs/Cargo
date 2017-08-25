﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities;
using CargoLogistic.NHibernateInitialize;
using NHibernate;

namespace CargoLogistic.Domain.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {

        private readonly ISession _session = null;

       
        public Repository()
        {
            _session = NHibernateProvider.GetSession();
        }
        public Repository(ISession session)
        {
            _session = session;
        }



       
        public void Save(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }

        }

       public IEnumerable<T> GetAll()
        {
            return _session.QueryOver<T>()
                .List<T>();
        }

        public T GetById(long Id)
        {
           
            return _session.Get<T>(Id);
        }

        public T Load(long Id)
        {
            return _session.Load<T>(Id);
        }

        
        public void Dispose()
        {
            _session.Close();
        }

    }
}
