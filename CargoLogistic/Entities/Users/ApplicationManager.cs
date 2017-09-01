using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
using NHibernate.AspNet.Identity;
//using SharpArch.NHibernate;

namespace CargoLogistic.Domain.Entities.Users
{
    public class ApplicationManager : UserManager<ApplicationUser>
    {
        public ApplicationManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }

        //public static ApplicationManager Create(IdentityFactoryOptions<ApplicationManager> options,
        //    IOwinContext context)
        //{
        //    //ApplicationContext db = context.Get<ApplicationContext>();

        //    ApplicationManager manager = new ApplicationManager(new UserStore<ApplicationUser>(NHibernateSession.Current));
        //    return manager;
        //}
    }
}
