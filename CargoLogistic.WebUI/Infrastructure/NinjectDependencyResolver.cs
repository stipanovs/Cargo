using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Entities;
using Ninject;
using CargoLogistic.Domain.Repository;


namespace CargoLogistic.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // add here
            //kernel.Bind<IRepository<Country>>().To<Repository<Country>>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind(typeof(IPostCargoRepository)).To(typeof(PostCargoRepository));
            kernel.Bind(typeof(ICountryRepository)).To(typeof(CountryRepository));
            kernel.Bind(typeof(ILocalityRepository)).To(typeof(LocalityRepository));

        }
    }
}
