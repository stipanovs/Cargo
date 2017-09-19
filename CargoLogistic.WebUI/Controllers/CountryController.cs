using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
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
        private ICountryService _countryService;

        public CountryController(ICountryRepository countryRepository,
            IRepository<Locality> localityRepository, ICountryService countryService)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
            _countryService = countryService;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetLocality(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);
            var locality = country.Localities.Select(x => x.Name).ToList();
            
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
            
            var countryDto = Mapper.Map<CountryDetailsModel, CountryCreateDto>(model);
            _countryService.CreateCountry(countryDto);
            
            return RedirectToAction("CountryList");
        }

        public ActionResult CountryList()
        {
            var countriesDto = _countryService.CountryDtos();
            var countriesListModel = Mapper.Map<IEnumerable<CountryListDetailsModel>>(countriesDto);
            return View(countriesListModel);
        }

        [HttpGet]
        public ActionResult EditCountry(long countryId)
        {
            var country = _countryRepository.GetById(countryId);
            var model = new CountryDetailsModel
            {
                Id = country.Id,
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
            var country = _countryRepository.GetById(model.Id);
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
                Id = countryId,
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