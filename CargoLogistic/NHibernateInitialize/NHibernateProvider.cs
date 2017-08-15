using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using CargoLogistic.Mapping;

namespace CargoLogistic.NHibernateInitialize
{
    public class NHibernateProvider
    {
        
        private const string connString = @"Server=.;Database=CARGO;Trusted_Connection=True";


        private static ISessionFactory _sessionFactory;

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }
        private static ISessionFactory CreateSessionFactory()
        {
            
            return Fluently.Configure()
                     .Database(MsSqlConfiguration
                     .MsSql2012
                     .ConnectionString(connString))
                     .Mappings(m => m.FluentMappings
                     .AddFromAssemblyOf<CountryMap>())
                     .BuildSessionFactory();
        }
    }
}
