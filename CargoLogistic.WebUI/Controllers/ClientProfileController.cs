using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Entities;
using CargoLogistic.Domain.Entities.Users;
using CargoLogistic.Domain.Factory;
using CargoLogistic.Domain.Repository;
using CargoLogistic.WebUI.Models;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;
using SharpArch.NHibernate;

namespace CargoLogistic.WebUI.Controllers
{
    [Authorize]
    public class ClientProfileController : Controller
    {
        private IPostRepository _postRepository;
        private ICountryRepository _countryRepository;
        private ILocalityRepository _localityRepository;
        private IRepository<Location> _locationRepository;
        private IRepository<CargoSpecification> _cargospecRepository;


        public ClientProfileController(IPostRepository postRepo, 
            ICountryRepository countryRepository, ILocalityRepository localityRepository,
            IRepository<Location> locationRepository, IRepository<CargoSpecification> cargospecRepository)
        {
            _postRepository = postRepo;
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
            _locationRepository = locationRepository;
            _cargospecRepository = cargospecRepository;
        }

        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult PostList()
        {
            var posts = _postRepository.GetAllPostUser(User.Identity.GetUserId());
            
            return View(posts);
        }

        [HttpGet]
        public ActionResult CreatePost()
        {
            var countries = _countryRepository.GetAll()
                .Select( c => new SelectListItem
                {
                   Text = c.Name,
                   Value = c.Name
                });

            ViewBag.CountryFrom = countries;
            ViewBag.CountryTo = countries;
            
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(CreatePostCargoDto model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(NHibernateSession.Current));
            var user = UserManager.FindById(User.Identity.GetUserId());

            Location locationFrom = new Location()
            {
                Country = _countryRepository.GetByName(model.CountryFrom),
                Locality = _localityRepository.GetByName(model.LocalityFrom)
            };

            Location locationTo = new Location()
            {
                Country = _countryRepository.GetByName(model.CountryTo),
                Locality = _localityRepository.GetByName(model.LocalityTo)
            };

            CargoSpecification cargoSpecification = new CargoSpecification()
            {
                Description = model.CargoDescription,
                Weight = model.CargoWeight,
                Volume = model.CargoVolume
            };

            var postFactory = new PostFactory();
            var post = postFactory.CreateNewPost(user, model.DateFrom, model.DateTo, locationFrom, locationTo,
                model.PostTransportType, model.Price, model.AdditionalInfo, cargoSpecification);


            _locationRepository.Save(locationFrom);
            _locationRepository.Save(locationTo);
            _cargospecRepository.Save(cargoSpecification);
            _postRepository.Save(post);

            
            return Redirect("PostList");
        }

        public JsonResult GetLocality(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);
            var locality = country.Locations.Select(x => x.Name).ToList();

            return Json(locality);
        }

    }
}