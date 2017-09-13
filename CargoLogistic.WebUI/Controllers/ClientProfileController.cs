using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Entities.Users;
using CargoLogistic.DAL.Factory;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.DAL.Repository;
using CargoLogistic.WebUI.Models;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;
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
        
        public ActionResult PostCargoList()
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
                        LocalityFrom = p.LocationFrom.Locality.Name,
                        LocalityTo = p.LocationTo.Locality.Name,
                        Price = p.Price,
                        CargoDescription = p.Specification.Description,
                        CargoWeight = p.Specification.Weight,
                        CargoVolume = p.Specification.Volume,
                        Status = p.Status,
                        NumberOfViews = p.NumberOfViews
                        
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
               var countries = _countryRepository.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        
                    });

                ViewBag.CountryFrom = countries;
                ViewBag.CountryTo = countries;
               
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
            
            return Redirect("PostCargoList");
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
                return RedirectToAction("PostCargoList", "ClientProfile");
            }

            var model = new PostCargoListDetailsModel
            {
                PostId = post.Id,
                PublicationDate = post.PublicationDate,
                CountryFrom = post.LocationFrom.Country,
                CountryTo = post.LocationTo.Country
            };

            return PartialView(model); 
        }

        [HttpPost, ActionName("PublishPostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishConfirmedPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (post.Status)
            {
                return RedirectToAction("PostCargoList", "ClientProfile");
            }
            
            post.Status = true;
            post.PublicationDate = DateTime.Now;
            _postCargoRepository.Update(post);
            
            return RedirectToAction("PostCargoList", "ClientProfile");
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
                return RedirectToAction("PostCargoList", "ClientProfile");
            }

            var model = new PostCargoListDetailsModel
            {
                PostId = post.Id,
                PublicationDate = post.PublicationDate,
                CountryFrom = post.LocationFrom.Country,
                CountryTo = post.LocationTo.Country
            };

            return PartialView(model);
        }

        [HttpPost, ActionName("UnPublishPostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult UnPublishConfirmedPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (!post.Status)
            {
                return RedirectToAction("PostCargoList", "ClientProfile");
            }

            post.Status = false;
            _postCargoRepository.Update(post);

            return RedirectToAction("PostCargoList", "ClientProfile");
        }

        [HttpGet]
        public ActionResult EditPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            var model = new EditPostCargoModel()
            {
                PostId = post.Id,
                PublicationDate = post.PublicationDate,
                CountryFrom =  post.LocationFrom.Country.Name,
                LocalityFrom = post.LocationFrom.Locality.Name,
                CountryTo = post.LocationTo.Country.Name,
                LocalityTo = post.LocationTo.Locality.Name,
                AdditionalInfo = post.AdditionalInformation,
                CargoDescription = post.Specification.Description,
                CargoVolume = post.Specification.Volume,
                CargoWeight = post.Specification.Weight,
                DateFrom = post.DateFrom,
                DateTo = post.DateTo,
                PostTransportTypes = post.PostTransportType.ToString(),
                Price = post.Price,
                Status = post.Status
            };

            var countriesFrom = _countryRepository.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name,
                    Selected = c.Name == model.CountryFrom
                });
            

            var countriesTo = _countryRepository.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name,
                    Selected = c.Name == model.CountryTo
                });
            

            var localityFrom = _localityRepository.GetAll()
                .Where(l=>l.Country.Name == model.CountryFrom)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Name,
                    Selected = l.Name == model.LocalityFrom
                });

            var localityTo = _localityRepository.GetAll()
                .Where(l => l.Country.Name == model.CountryTo)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Name,
                    Selected = l.Name == model.LocalityTo
                });

           
            ViewBag.CountryFrom = countriesFrom;
            ViewBag.LocalityFrom = localityFrom;
            ViewBag.CountryTo = countriesTo;
            ViewBag.LocalityTo = localityTo;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPostCargo(EditPostCargoModel model)
        {
            if (!ModelState.IsValid)
            {
                var countriesFrom = _countryRepository.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == model.CountryFrom
                    });


                var countriesTo = _countryRepository.GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == model.CountryTo
                    });


                var localityFrom = _localityRepository.GetAll()
                    .Where(l => l.Country.Name == model.CountryFrom)
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Name,
                        Selected = l.Name == model.LocalityFrom
                    });

                var localityTo = _localityRepository.GetAll()
                    .Where(l => l.Country.Name == model.CountryTo)
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Name,
                        Selected = l.Name == model.LocalityTo
                    });

                ViewBag.CountryFrom = countriesFrom;
                ViewBag.LocalityFrom = localityFrom;
                ViewBag.CountryTo = countriesTo;
                ViewBag.LocalityTo = localityTo;

                return View(model);
            }

            var post = _postCargoRepository.GetById(model.PostId);

            Location locationFrom = post.LocationFrom;
            locationFrom.Country = _countryRepository.GetByName(model.CountryFrom);
            locationFrom.Locality = _localityRepository.GetByName(model.LocalityFrom);

            Location locationTo = post.LocationTo;

            locationTo.Country = _countryRepository.GetByName(model.CountryTo);
            locationTo.Locality = _localityRepository.GetByName(model.LocalityTo);

            CargoSpecification cargoSpecification = post.Specification;

            cargoSpecification.Description = model.CargoDescription;
            cargoSpecification.Weight = model.CargoWeight;
            cargoSpecification.Volume = model.CargoVolume;

            post.LocationTo = locationTo;
            post.LocationFrom = locationFrom;
            post.Specification = cargoSpecification;
            post.Price = model.Price;
            PostTransportType postTransportType;
            Enum.TryParse(model.PostTransportTypes, true, out postTransportType);
            post.PostTransportType = postTransportType;
            post.DateFrom = model.DateFrom;
            post.DateTo = model.DateTo;
            post.AdditionalInformation = model.AdditionalInfo;

            _postCargoRepository.Update(post);

           return RedirectToAction("PostCargoList");
        }

        public ActionResult DeletePostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            if (post == null)
            {
                return HttpNotFound();
            }

            var model = new EditPostCargoModel()
            {
                PostId = post.Id,
                PublicationDate = post.PublicationDate,
                CountryFrom = post.LocationFrom.Country.Name,
                LocalityFrom = post.LocationFrom.Locality.Name,
                CountryTo = post.LocationTo.Country.Name,
                LocalityTo = post.LocationTo.Locality.Name,
                AdditionalInfo = post.AdditionalInformation,
                CargoDescription = post.Specification.Description,
                CargoVolume = post.Specification.Volume,
                CargoWeight = post.Specification.Weight,
                DateFrom = post.DateFrom,
                DateTo = post.DateTo,
                PostTransportTypes = post.PostTransportType.ToString(),
                Price = post.Price,
                Status = post.Status
            };

            return View(model);
        }

        [HttpPost, ActionName("DeletePostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPostCargo(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            _postCargoRepository.Delete(post);
            
            return RedirectToAction("PostCargoList", "ClientProfile");
        }



    }
}