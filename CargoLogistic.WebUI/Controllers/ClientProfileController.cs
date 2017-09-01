using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Repository;
using Microsoft.AspNet.Identity;

namespace CargoLogistic.WebUI.Controllers
{
    public class ClientProfileController : Controller
    {
        private IPostRepository _repository;

        public ClientProfileController(IPostRepository repo)
        {
            _repository = repo;
        }

        // GET: ClientProfile
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult PostList()
        {
            var posts = _repository.GetAllPostUser(User.Identity.GetUserId());
            
            return View(posts);
        }
    }
}