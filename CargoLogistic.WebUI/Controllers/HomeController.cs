using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.DAL.Repository;
using CargoLogistic.WebUI.Models;
using CargoLogistic.BLL.Intefaces;

namespace CargoLogistic.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICountryRepository _countryRepository;
        private IPostCargoRepository _postCargoRepository;
       


        public HomeController(ICountryRepository countryRepository, IPostCargoRepository postCargoRepository, ICountryService countryService)
        {
            _countryRepository = countryRepository;
            _postCargoRepository = postCargoRepository;
            
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "My page description";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us: ";

            return View();
        }

        [HttpGet]
        public ActionResult PostCargoSearch()
        {
            ViewBag.CountryFrom = new SelectList(
                _countryRepository.GetAll().Select(x => x.Name), "CountryFrom");

            return View();
        }

        [HttpPost]
        public ActionResult PostCargoSearch(SearchPostCargoModel model)
        {
            var posts = _postCargoRepository.GetAll()
                .Where(x=>x.LocationFrom.Country.Name == model.CountryFrom)
                .OrderByDescending(x => x.PublicationDate);

            var modelList = new List<PostCargoListDetailsModel>();

            foreach (var p in posts)
            {
                modelList.Add(new PostCargoListDetailsModel
                {
                    PostId = p.Id,
                    CountryFrom = p.LocationFrom.Country,
                    CountryTo = p.LocationTo.Country,
                    LocalityFrom = p.LocationFrom.Locality.Name,
                    LocalityTo = p.LocationTo.Locality.Name,
                    DateFrom = p.DateFrom,
                    DateTo = p.DateTo,
                    PostTransportTypes = p.PostTransportType.ToString(),
                    CargoDescription = p.Specification.Description,
                    CargoWeight = p.Specification.Weight,
                    CargoVolume = p.Specification.Volume,
                    AdditionalInfo = p.AdditionalInformation,
                    PublicationDate = p.PublicationDate,
                    UserCompany = p.User.CompanyName

                });
            }

            return PartialView("DisplayTemplates/PostListDisplay", modelList);
        }
        

    }
}