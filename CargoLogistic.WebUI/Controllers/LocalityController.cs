using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.DAL.Factory;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    public class LocalityController : Controller
    {
        private ICountryService _countryService;
        private ILocalityService _localityService;

        public LocalityController(ICountryService countryService, ILocalityService localityService)
        {
            _countryService = countryService;
            _localityService = localityService;
        }
        
        [HttpGet]
        public ActionResult AddLocality()
        {
            ViewBag.Country = new SelectList(
                _countryService.CountryDtos().Select(x => x.Name), "Country");

            return View();
        }

        [HttpPost]
        public ActionResult AddLocality(CreateLocalityModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var localityDto = Mapper.Map<LocalityDto>(model);
            _localityService.CreateLocality(localityDto);

            return RedirectToAction("CountryList", "Country");
        }

    }
}