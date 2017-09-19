using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CargoLogistic.BLL.Infrastructure;
using CargoLogistic.WebUI.App_Start;
using FluentNHibernate.Cfg;

namespace CargoLogistic.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg=>
            {
                cfg.AddProfile<AutomapperBLLProfile>();
                cfg.AddProfile<AutomapperWebProfile>();
            });
        }
    }
    
}
