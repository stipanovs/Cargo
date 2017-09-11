using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Factory;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.DAL.Repository;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CountryController : Controller
    {
        private ICountryRepository _countryRepository;
        private IRepository<Locality> _localityRepository;

        public CountryController(ICountryRepository countryRepository, IRepository<Locality> localityRepository)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
        }

        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult CreateCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCountry(CountryDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = new Country{Name = model.Name, NumericCode = model.NumericCode, Alpha2Code = model.Alpha2Code};

            _countryRepository.Save(country);

            return RedirectToAction("CountryList");
        }

        [HttpGet]
        public ActionResult List()
        {
            
            SelectList countries = new SelectList(_countryRepository.GetAll()
                .Select(x => x.Name).ToList());
            
            ViewData["countries"] = countries;
            
            return View();
        }

       
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


        public ActionResult CountryList()
        {
            var countries = _countryRepository.GetAll();
            var listCountries = new List<CountryDetailsModel>();
            foreach (var c in countries)
            {
                listCountries.Add( new CountryDetailsModel
                {
                    CountryId = c.Id,
                    Name = c.Name,
                    NumericCode = c.NumericCode,
                    Alpha2Code = c.Alpha2Code,
                    Localities = c.Locations
                    }
                );
            }
           
            return View(listCountries);
        }

        [HttpGet]
        public ActionResult EditCountry(long countryId)
        {
            var country = _countryRepository.GetById(countryId);
            var model = new CountryDetailsModel
            {
                CountryId = country.Id,
                Name = country.Name,
                NumericCode = country.NumericCode,
                Alpha2Code = country.Alpha2Code
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCountry(CountryDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var country = _countryRepository.GetById(model.CountryId);
            country.Name = model.Name;
            country.NumericCode = model.NumericCode;
            country.Alpha2Code = model.Alpha2Code;

            _countryRepository.Update(country);

            return Redirect("CountryList");
        }

        [HttpGet]
        public ActionResult DeleteCountry(long countryId)
        {
            
            var country = _countryRepository.GetById(countryId);
            if (country == null)
            {
                return HttpNotFound();
            }

            var model = new CountryDetailsModel
            {
                CountryId = countryId,
                Name = country.Name,
                NumericCode = country.NumericCode,
                Alpha2Code = country.Alpha2Code

            };

            return View(model);
        }


        [HttpPost, ActionName("DeleteCountry")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCountry(long countryId)
        {
            var country = _countryRepository.GetById(countryId);

            _countryRepository.Delete(country);

            return RedirectToAction("CountryList", "Country");
        }


        [HttpGet]
        public ActionResult AddLocality()
        {
            ViewBag.Countries = new SelectList(
                _countryRepository.GetAll().Select(x => x.Name), "Countries");

            return View();
        }

        [HttpPost]
        public ActionResult AddLocality(CreateLocalityModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var country = _countryRepository.GetByName(model.Countries);
            var locality = LocalityFactory.CreateLocality(model.Name, country, model.LocalityType);
            _localityRepository.Save(locality);

            return RedirectToAction("CountryList");
        }

        
    }

}