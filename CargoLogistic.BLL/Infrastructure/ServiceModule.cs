using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.DAL.Repository;
using Ninject.Modules;

namespace CargoLogistic.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(Repository<>)).WithConstructorArgument(connectionString);
            Bind(typeof(ICountryRepository)).To(typeof(CountryRepository)).WithConstructorArgument(connectionString);
        }
    }
}
