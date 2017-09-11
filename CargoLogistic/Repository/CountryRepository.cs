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
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public ISession _session;

        public CountryRepository(ISession session)
        {
            _session = session;
        }

        public CountryRepository()
        {
            _session = NHibernateProvider.GetSession();
        }

        public Country GetByName(string name)
        {
           
            return _session.QueryOver<Country>()
                .Where(c => c.Name == name)
                .SingleOrDefault();
        }
    }
}
