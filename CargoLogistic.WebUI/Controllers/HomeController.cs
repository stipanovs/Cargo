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
        
    }
}