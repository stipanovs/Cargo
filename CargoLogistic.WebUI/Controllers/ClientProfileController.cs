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
using NHibernate.Type;
using SharpArch.NHibernate;

namespace CargoLogistic.WebUI.Controllers
{
    [Authorize]
    public class ClientProfileController : Controller
    {
        private IPostCargoRepository _postCargoRepository;
        private ICountryRepository _countryRepository;
        private ILocalityRepository _localityRepository;
        private IRepository<Location> _locationRepository;
        private IRepository<CargoSpecification> _cargospecRepository;


        public ClientProfileController(IPostCargoRepository postCargoRepo, 
            ICountryRepository countryRepository, ILocalityRepository localityRepository,
            IRepository<Location> locationRepository, IRepository<CargoSpecification> cargospecRepository)
        {
            _postCargoRepository = postCargoRepo;
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
            var posts = _postCargoRepository.GetAllPostCargoUser(User.Identity.GetUserId());
            var model = new List<PostCargoListDetailsModel>();
            foreach (var p in posts)
            {
                model.Add(
                    new PostCargoListDetailsModel
                    {
                        PostId = p.Id,
                        PublicationDate = p.PublicationDate,
                        DateFrom = p.DateFrom,
                        DateTo = p.DateTo,
                        CountryFrom = p.LocationFrom.Country,
                        CountryTo = p.LocationTo.Country,
                        Price = p.Price,
                        Status = p.Status
                    });
            }
            

           return View(model.OrderByDescending(x=>x.PublicationDate));
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
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(CreatePostCargoModel model)
        {
            
            if (!ModelState.IsValid)
            {
                //serii
                var countries = _countryRepository.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name
                    });

                ViewBag.CountryFrom = countries;
                ViewBag.CountryTo = countries;
                //serii
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
            _postCargoRepository.Save(post as PostCargo);

            
            return Redirect("PostList");
        }

        public JsonResult GetLocality(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);
            var locality = country.Locations.Select(x => x.Name).ToList();

            return Json(locality);
        }

        [HttpGet]
        public ActionResult PublishPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (post == null)
            {
                return HttpNotFound();
            }

            if (post.Status)
            {
                return RedirectToAction("PostList", "ClientProfile");
            }

            var model = new PostCargoListDetailsModel
            {
                PostId = post.Id,
                PublicationDate = post.PublicationDate,
                CountryFrom = post.LocationFrom.Country,
                CountryTo = post.LocationTo.Country
            };

            return View(model);
        }

        [HttpPost, ActionName("PublishPostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishConfirmedPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (post.Status)
            {
                return RedirectToAction("PostList", "ClientProfile");
            }
            
            post.Status = true;
            _postCargoRepository.Update(post);
            
            return RedirectToAction("PostList", "ClientProfile");
        }

        [HttpGet]
        public ActionResult UnPublishPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (post == null)
            {
                return HttpNotFound();
            }

            if (!post.Status)
            {
                return RedirectToAction("PostList", "ClientProfile");
            }

            var model = new PostCargoListDetailsModel
            {
                PostId = post.Id,
                PublicationDate = post.PublicationDate,
                CountryFrom = post.LocationFrom.Country,
                CountryTo = post.LocationTo.Country
            };

            return View(model);
        }

        [HttpPost, ActionName("UnPublishPostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult UnPublishConfirmedPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (!post.Status)
            {
                return RedirectToAction("PostList", "ClientProfile");
            }

            post.Status = false;
            _postCargoRepository.Update(post);

            return RedirectToAction("PostList", "ClientProfile");
        }
    }
}