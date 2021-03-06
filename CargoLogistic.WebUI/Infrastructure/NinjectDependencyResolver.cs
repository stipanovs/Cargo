﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.BLL.Services;
using CargoLogistic.DAL.Interfaces;
using Ninject;
using CargoLogistic.DAL.Repository;


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
            kernel.Bind(typeof(IPostTransportRepository)).To(typeof(PostTransportRepository));
            kernel.Bind(typeof(ICountryRepository)).To(typeof(CountryRepository));
            kernel.Bind(typeof(ILocalityRepository)).To(typeof(LocalityRepository));

            kernel.Bind(typeof(ICountryService)).To(typeof(CountryService));
            kernel.Bind(typeof(ILocalityService)).To(typeof(LocalityService));
            kernel.Bind(typeof(IPostCargoService)).To(typeof(PostCargoService));
            kernel.Bind(typeof(IPostTransportService)).To(typeof(PostTransportService));

        }
    }
}
