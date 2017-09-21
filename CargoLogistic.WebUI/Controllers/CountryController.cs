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
       
        private ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
           _countryService = countryService;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        //public JsonResult GetLocality(string countryName)
        //{
        //    var country = _countryRepository.GetByName(countryName);
        //    var locality = country.Localities.Select(x => x.Name).ToList();
            
        //    return Json(locality);
        //}

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
            var countryModel = Mapper.Map<CountryDetailsModel>(_countryService.GetById(countryId));
            return View(countryModel);
        }

        [HttpPost]
        public ActionResult EditCountry(CountryDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var countryDto = Mapper.Map<CountryDto>(model);
            _countryService.EditCountry(countryDto);

            return Redirect("CountryList");
        }

        [HttpGet]
        public ActionResult DeleteCountry(long countryId)
        {
            var countryModel = Mapper.Map<CountryDetailsModel>(_countryService.GetById(countryId));
            return View(countryModel);
        }


        [HttpPost, ActionName("DeleteCountry")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCountry(long countryId)
        {
            _countryService.DeleteCountry(countryId);
            return RedirectToAction("CountryList", "Country");
        }
    }

}