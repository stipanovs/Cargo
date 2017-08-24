using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Entities;
using CargoLogistic.Domain.Repository;

namespace CargoLogistic.WebUI.Controllers
{
    public class CountryController : Controller
    {
        private IRepository<Country> _repository;

        public CountryController(IRepository<Country> repo)
        {
            _repository = repo;
        }
        
    
        // GET: Country
        public ViewResult List()
        {
            var countries = _repository.GetAll()
                .OrderBy(c => c.Id);

            return View(countries);
        }
        
    }

}