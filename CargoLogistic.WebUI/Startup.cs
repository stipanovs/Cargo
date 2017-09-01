using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CargoLogistic.WebUI.App_Start;
using Microsoft.Owin;
using Owin;
using SharpArch.NHibernate.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(CargoLogistic.WebUI.Startup))]
namespace CargoLogistic.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureData();
        }

        private static void ConfigureData()
        {
            var storage = new WebSessionStorage(System.Web.HttpContext.Current.ApplicationInstance);
            DataConfig.Configure(storage);
        }
    }
}