using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.DAL.Entities.Users;
using CargoLogistic.WebUI.Filters;
using CargoLogistic.WebUI.Models;
using Microsoft.AspNet.Identity;
using NHibernate.AspNet.Identity;
using SharpArch.NHibernate;

namespace CargoLogistic.WebUI.Controllers
{
    [Authorize]
    public class ClientProfileController : Controller
    {
        
        private IPostCargoService _postCargoService;
        private IPostTransportService _postTransportService;
        private ICountryService _countryService;


        public ClientProfileController(IPostCargoService postCargoService, IPostTransportService postTransportService,
            ICountryService countryService)
        {
            _postCargoService = postCargoService;
            _postTransportService = postTransportService;
            _countryService = countryService;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult PostCargoList()
        {
            
            var postCargoDetailsListDto = _postCargoService.GetAllPostCargoDetailsDtos(User.Identity.GetUserId());
            var postCargoDetailsListModel = Mapper.Map<IEnumerable<PostCargoDetailsModel>>(postCargoDetailsListDto)
                .OrderByDescending(x=>x.PublicationDate);

           return View(postCargoDetailsListModel);
        }

        public ActionResult PostTransportList()
        {

            var postTransportDetailsListDto = _postTransportService.GetAllPostTransportDetailsDtos(User.Identity.GetUserId());
            var postTransportDetailsListModel = Mapper.Map<IEnumerable<PostTransportDetailsModel>>(postTransportDetailsListDto)
                .OrderByDescending(x => x.PublicationDate);

            return View(postTransportDetailsListModel);
        }

        #region CreatePostCargo()

        [HttpGet]
        //[ChildActionOnly]
        public ActionResult CreatePost()
        {
            var countries = _countryService.CountryDtos()
                .Select( c => new SelectListItem
                {
                   Text = c.Name,
                   Value = c.Name
                });

            ViewBag.CountryFrom = countries;
            ViewBag.CountryTo = countries;
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(CreatePostCargoModel model)
        {
            if (!ModelState.IsValid)
            {
               var countries = _countryService.CountryDtos()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        
                    });

                ViewBag.CountryFrom = countries;
                ViewBag.CountryTo = countries;
               
                return View(model);
            }

            var UserManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(NHibernateSession.Current));
            var user = UserManager.FindById(User.Identity.GetUserId());

            var postCargodto = Mapper.Map<PostCargoCreateDto>(model);
            _postCargoService.CreatePostCargo(postCargodto, user);
            
            return Redirect("PostCargoList");
        }

        #endregion()

        #region CreatePostTransport()




        [HttpGet]
        //[ChildActionOnly]
        public ActionResult CreatePostTransport()
        {
            var countries = _countryService.CountryDtos()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name
                });

            ViewBag.CountryFrom = countries;
            ViewBag.CountryTo = countries;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePostTransport(CreatePostTransportModel model)
        {
            if (!ModelState.IsValid)
            {
                var countries = _countryService.CountryDtos()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,

                    });

                ViewBag.CountryFrom = countries;
                ViewBag.CountryTo = countries;

                return View(model);
            }

            var UserManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(NHibernateSession.Current));
            var user = UserManager.FindById(User.Identity.GetUserId());

            var postTransportdto = Mapper.Map<PostTransportCreateDto>(model);
            _postTransportService.CreatePostTransport(postTransportdto, user);

            return RedirectToAction("PostTransportList");
        }


        #endregion

        #region GetLocality()

        public JsonResult GetLocality(string countryName)
        {
            var locality = _countryService.LocalitiesDtosByCountryName(countryName)
                .Select(l=>l.Name).ToList();
            return Json(locality);
        }

        #endregion

        #region EditPostCargo()




        [HttpGet]
        public ActionResult EditPostCargo(long postId)
        {
            var model = Mapper.Map<EditPostCargoModel>(_postCargoService.GetPostCargoEditDtoById(postId));

            var countriesFrom = _countryService.CountryDtos()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name,
                    Selected = c.Name == model.CountryFrom
                });
            

            var countriesTo = _countryService.CountryDtos()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name,
                    Selected = c.Name == model.CountryTo
                });

            var localityFrom = _countryService.LocalitiesDtosByCountryName(model.CountryFrom)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Name,
                    Selected = l.Name == model.LocalityFrom
                }); 
                
            var localityTo = _countryService.LocalitiesDtosByCountryName(model.CountryTo)
               .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Name,
                    Selected = l.Name == model.LocalityTo
                });

           
            ViewBag.CountryFrom = countriesFrom;
            ViewBag.LocalityFrom = localityFrom;
            ViewBag.CountryTo = countriesTo;
            ViewBag.LocalityTo = localityTo;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPostCargo(EditPostCargoModel model)
        {
            if (!ModelState.IsValid)
            {
                var countriesFrom = _countryService.CountryDtos()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == model.CountryFrom
                    });


                var countriesTo = _countryService.CountryDtos()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == model.CountryTo
                    });

                var localityFrom = _countryService.LocalitiesDtosByCountryName(model.CountryFrom)
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Name,
                        Selected = l.Name == model.LocalityFrom
                    });

                var localityTo = _countryService.LocalitiesDtosByCountryName(model.CountryTo)
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Name,
                        Selected = l.Name == model.LocalityTo
                    });


                ViewBag.CountryFrom = countriesFrom;
                ViewBag.LocalityFrom = localityFrom;
                ViewBag.CountryTo = countriesTo;
                ViewBag.LocalityTo = localityTo;

                return View(model);
            }

            var postCargoEditDto = Mapper.Map<PostCargoEditDto>(model);
            _postCargoService.EditPostCargo(postCargoEditDto);

           return RedirectToAction("PostCargoList");
        }

        #endregion

        #region EditPostTransport()
        
        [HttpGet]
        public ActionResult EditPostTransport(long postId)
        {
            var model = Mapper.Map<CreatePostTransportModel>(_postTransportService.GeTransportCreateDtoById(postId));

            var countriesFrom = _countryService.CountryDtos()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name,
                    Selected = c.Name == model.CountryFrom
                });


            var countriesTo = _countryService.CountryDtos()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Name,
                    Selected = c.Name == model.CountryTo
                });

            var localityFrom = _countryService.LocalitiesDtosByCountryName(model.CountryFrom)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Name,
                    Selected = l.Name == model.LocalityFrom
                });

            var localityTo = _countryService.LocalitiesDtosByCountryName(model.CountryTo)
               .Select(l => new SelectListItem
               {
                   Text = l.Name,
                   Value = l.Name,
                   Selected = l.Name == model.LocalityTo
               });


            ViewBag.CountryFrom = countriesFrom;
            ViewBag.LocalityFrom = localityFrom;
            ViewBag.CountryTo = countriesTo;
            ViewBag.LocalityTo = localityTo;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPostTransport(CreatePostTransportModel model)
        {
            if (!ModelState.IsValid)
            {
                var countriesFrom = _countryService.CountryDtos()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == model.CountryFrom
                    });


                var countriesTo = _countryService.CountryDtos()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Name,
                        Selected = c.Name == model.CountryTo
                    });

                var localityFrom = _countryService.LocalitiesDtosByCountryName(model.CountryFrom)
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Name,
                        Selected = l.Name == model.LocalityFrom
                    });

                var localityTo = _countryService.LocalitiesDtosByCountryName(model.CountryTo)
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Name,
                        Selected = l.Name == model.LocalityTo
                    });


                ViewBag.CountryFrom = countriesFrom;
                ViewBag.LocalityFrom = localityFrom;
                ViewBag.CountryTo = countriesTo;
                ViewBag.LocalityTo = localityTo;

                return View(model);
            }

            var postTransportDto = Mapper.Map<PostTransportCreateDto>(model);
            _postTransportService.EditPostTransport(postTransportDto);

            return RedirectToAction("PostTransportList");
        }

        #endregion

        #region DeletePostCargo()

        public ActionResult DeletePostCargo(long postId)
        {
            var postCargoDetailsModel =
                Mapper.Map<PostCargoDetailsModel>(_postCargoService.GetPostCargoDetailsDtoById(postId));
            return View(postCargoDetailsModel);
        }

        [HttpPost, ActionName("DeletePostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPostCargo(long postId)
        {
            _postCargoService.DeletePostCargo(postId);
            return RedirectToAction("PostCargoList", "ClientProfile");
        }

        #endregion

        public ActionResult DeletePostTransport(long postId)
        {
            var postTransportDetailsModel =
                Mapper.Map<PostTransportDetailsModel>(_postTransportService.GetPostTransportDetailsDto(postId));
            return View(postTransportDetailsModel);
        }

        [HttpPost, ActionName("DeletePostTransport")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPostTransport(long postId)
        {
            _postTransportService.DeletePostTransport(postId);
            return RedirectToAction("PostTransportList", "ClientProfile");
        }

        #region PublishPostCargo()
        
        [HttpGet]
        public ActionResult PublishPostCargo(long postId)
        {
            var postCargoDetailsModel =
                Mapper.Map<PostCargoDetailsModel>(_postCargoService.GetPostCargoDetailsDtoById(postId));
            
            if (postCargoDetailsModel.Status)
            {
                return RedirectToAction("PostCargoList", "ClientProfile");
            }
            return PartialView(postCargoDetailsModel);
        }

        [HttpPost, ActionName("PublishPostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishConfirmedPostCargo(long postId)
        {
            var postCargoDetailsModel =
                Mapper.Map<PostCargoDetailsModel>(_postCargoService.GetPostCargoDetailsDtoById(postId));

            if (postCargoDetailsModel.Status)
            {
                return RedirectToAction("PostCargoList", "ClientProfile");
            }

            _postCargoService.PublichPostCargo(postId);
            return RedirectToAction("PostCargoList", "ClientProfile");
        }
        #endregion

        #region UnPublishPostCargo()
        [HttpGet]
        public ActionResult UnPublishPostCargo(long postId)
        {
            var postCargoDetailsModel =
                Mapper.Map<PostCargoDetailsModel>(_postCargoService.GetPostCargoDetailsDtoById(postId));

            if (!postCargoDetailsModel.Status)
            {
                return RedirectToAction("PostCargoList", "ClientProfile");
            }
            
            return PartialView(postCargoDetailsModel);
        }

        [HttpPost, ActionName("UnPublishPostCargo")]
        [ValidateAntiForgeryToken]
        public ActionResult UnPublishConfirmedPostCargo(long postId)
        {
            var postCargoDetailsModel =
                Mapper.Map<PostCargoDetailsModel>(_postCargoService.GetPostCargoDetailsDtoById(postId));
            if (!postCargoDetailsModel.Status)
            {
                return RedirectToAction("PostCargoList", "ClientProfile");
            }

           _postCargoService.UnPublichPostCargo(postId);

            return RedirectToAction("PostCargoList", "ClientProfile");
        }
        #endregion
        
       
        [HttpGet]
        public ActionResult PublishPostTransport(long postId)
        {
            var postTransportDetailsModel =
                Mapper.Map<PostTransportDetailsModel>(_postTransportService.GetPostTransportDetailsDto(postId));

            if (postTransportDetailsModel.Status)
            {
                return RedirectToAction("PostTransportList", "ClientProfile");
            }

            return PartialView("PublishPostTransport", postTransportDetailsModel);
        }

        [HttpPost, ActionName("PublishPostTransport")]
        [ValidateAntiForgeryToken]
        public ActionResult PublishConfirmedPostTransport(long postId)
        {
            var postTransportDetailsModel =
                Mapper.Map<PostTransportDetailsModel>(_postTransportService.GetPostTransportDetailsDto(postId));

            if (postTransportDetailsModel.Status)
            {
                return RedirectToAction("PostTransportList", "ClientProfile");
            }

            _postTransportService.PublishPostTransport(postId);
            return RedirectToAction("PostTransportList", "ClientProfile");
        }

        [HttpGet]
        public ActionResult UnPublishPostTransport(long postId)
        {
            var postTransportDetailsModel =
                Mapper.Map<PostTransportDetailsModel>(_postTransportService.GetPostTransportDetailsDto(postId));

            if (!postTransportDetailsModel.Status)
            {
                return RedirectToAction("PostTransportList", "ClientProfile");
            }

            return PartialView(postTransportDetailsModel);
        }

        [HttpPost, ActionName("UnPublishPostTransport")]
        [ValidateAntiForgeryToken]
        public ActionResult UnPublishConfirmedPostTransport(long postId)
        {
            var postTransportDetailsModel =
                Mapper.Map<PostTransportDetailsModel>(_postTransportService.GetPostTransportDetailsDto(postId));
            if (!postTransportDetailsModel.Status)
            {
                return RedirectToAction("PostTransportList", "ClientProfile");
            }

            _postTransportService.UnPublishPostTransport(postId);

            return RedirectToAction("PostTransportList", "ClientProfile");
        }

    }
}