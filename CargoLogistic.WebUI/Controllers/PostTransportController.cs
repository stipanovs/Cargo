using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    public class PostTransportController : Controller
    {
        private IPostTransportService _postTransportService;
        private ICountryService _countryService;

        public PostTransportController(IPostTransportService postTransportService, ICountryService countryService)
        {
            _postTransportService = postTransportService;
            _countryService = countryService;
        }
        public ActionResult ListAllPostTransport()
        {
            var dtos = _postTransportService.GetAllPublishedPostTransportDetailsDtos();
            var model = Mapper.Map<IEnumerable<PostTransportDetailsModel>>(dtos);
            return View(model);
        }

        [Authorize]
        public ActionResult PostTransportDetails(long postId)
        {
            var postTransportDetailsDto = _postTransportService.PostTransportDetailsAuthorized(postId);
            var model = Mapper.Map<PostTransportDetailsModel>(postTransportDetailsDto);

            return PartialView("PostTransportDetails", model);
        }

        [HttpGet]
        public ActionResult PostTransportSearch()
        {
            var countriesDto = _countryService.CountryDtos();

            ViewBag.CountryFrom = new SelectList(
                countriesDto.Select(x => x.Name), "CountryFrom");

            ViewBag.CountryTo = new SelectList(
                countriesDto.Select(x => x.Name), "CountryTo");


            return View();
        }

        [HttpPost]
        public ActionResult PostTransportSearch(SearchPostCargoModel model)
        {
            var postsDto = _postTransportService.SearchPostTransportDetailsDtos(Mapper.Map<SearchPostCargoDto>(model));

            if (!postsDto.Any())
            {
                return PartialView("_ResultNullPost");
            }

            var modelList = Mapper.Map<IEnumerable<PostTransportDetailsModel>>(postsDto);
            return PartialView("DisplayTemplates/PostTransportListDisplay", modelList);
        }
    }
}