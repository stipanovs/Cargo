using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Entities;
using CargoLogistic.Domain.Repository;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    public class CountryController : Controller
    {
        private ICountryRepository _countryRepository;

        public CountryController(ICountryRepository repo)
        {
            _countryRepository = repo;
        }

        public ActionResult ShowLocalities(IEnumerable<Locality> localities)
        {
            return View(localities);
        }


        public JsonResult GetLocality(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);
            var locality = country.Locations.Select(x => x.Name).ToList();
            
            return Json(locality);
        }

        [Authorize]
        [HttpGet]
        public ActionResult List()
        {
            
            SelectList countries = new SelectList(_countryRepository.GetAll()
                .Select(x => x.Name).ToList());
            
            ViewData["countries"] = countries;
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult List(ListCountryLocalityModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var country = _countryRepository.GetByName(model.Countries);

            //ViewBag.Countries = new SelectList(
            //    _countryRepository.GetAll().Select(x => x.Name), "Countries", "Text");
            //ViewBag.Localities = country.Locations;


            return View("ShowLocalities", country.Locations);
        }





    }

}