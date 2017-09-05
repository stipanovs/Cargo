using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Entities;
using CargoLogistic.Domain.Factory;
using CargoLogistic.Domain.Repository;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ICountryRepository _countryRepository;
        private IRepository<Locality> _localityRepository;

        public AdminController(ICountryRepository countryRepository, IRepository<Locality> localityRepository)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

       
    }
}