using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.WebUI.Models;
using NHibernate;
using NHibernate.AspNet.Identity;
using SharpArch.NHibernate;

namespace CargoLogistic.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private ISession _session = NHibernateSession.Current;

        // GET: Role
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult RoleList()
        {
            var roleStore = new RoleStore<IdentityRole>(_session);
            var list = roleStore.Roles;
            return View(list);
        }

        [Authorize(Roles = "admin")]
        public ActionResult CreateRole()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreateRole(CreateUserRole model)
        {
            var role = new IdentityRole(model.RoleName);
            var roleStore = new RoleStore<IdentityRole>(_session);
            roleStore.CreateAsync(role);

            return RedirectToAction("Index", "Role");
        }
    }

}