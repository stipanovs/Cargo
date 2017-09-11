using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.NHibernateInitialize;
using NHibernate;

namespace CargoLogistic.DAL.Repository
{
    public class LocalityRepository : Repository<Locality>, ILocalityRepository
    {
        public ISession _session;

        public LocalityRepository(ISession session)
        {
            _session = session;
        }

        public LocalityRepository()
        {
            _session = NHibernateProvider.GetSession();
        }

        
        public Locality GetByName(string name)
        {
            return _session.QueryOver<Locality>()
                .Where(x => x.Name == name)
                .SingleOrDefault();
        }
    }
}
