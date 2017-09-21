using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.DAL.Repository;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    public class PostCargoController : Controller
    {
        private IPostCargoService _postCargoService;
        private ICountryService _countryService;

        public PostCargoController(IPostCargoService postCargoService, ICountryService countryService)
        {
            _postCargoService = postCargoService;
            _countryService = countryService;
        }

        public ActionResult ListAllPost()
        {
            var dtos = _postCargoService.GetAllPublishedPostCargoDetailsDtos();
            var model = Mapper.Map<IEnumerable<PostCargoDetailsModel>>(dtos);
            return View(model);
        }

        [Authorize]
        public ActionResult PostCargoDetails(long postId)
        {
            var postCargoDetailsDto = _postCargoService.PostCargoDetailsAuthorized(postId);
            var model = Mapper.Map<PostCargoDetailsModel>(postCargoDetailsDto);
            
            return PartialView("PostCargoDetails", model);
        }

        [HttpGet]
        public ActionResult PostCargoSearch()
        {
            var countriesDto = _countryService.CountryDtos();

            ViewBag.CountryFrom = new SelectList(
                countriesDto.Select(x => x.Name), "CountryFrom");

            ViewBag.CountryTo = new SelectList(
                countriesDto.Select(x => x.Name), "CountryTo");
            

            return View();
        }

        [HttpPost]
        public ActionResult PostCargoSearch(SearchPostCargoModel model)
        {
            var postsDto = _postCargoService.SearchPostCargoDetailsDtos(
                Mapper.Map<SearchPostCargoDto>(model));
            if (!postsDto.Any())
            {
                return PartialView("_ResultNullPost");
            }

            var modelList = Mapper.Map<IEnumerable<PostCargoDetailsModel>>(postsDto);
            return PartialView("DisplayTemplates/PostListDisplay", modelList);
        }
    }
}