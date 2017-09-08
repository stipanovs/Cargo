using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoLogistic.Domain.Repository;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.Controllers
{
    public class PostCargoController : Controller
    {
        private IPostCargoRepository _postCargoRepository;

        public PostCargoController(IPostCargoRepository postCargoRepository)
        {
            _postCargoRepository = postCargoRepository;
        }

        public ActionResult ListAllPost()
        {
            var posts = _postCargoRepository.GetAll().OrderByDescending(x=>x.PublicationDate);
            var model = new List<PostCargoListDetailsModel>();

            foreach (var p in posts)
            {
                model.Add(new PostCargoListDetailsModel
                {
                    PostId = p.Id,
                    CountryFrom = p.LocationFrom.Country,
                    CountryTo = p.LocationTo.Country,
                    LocalityFrom = p.LocationFrom.Locality.Name,
                    LocalityTo = p.LocationTo.Locality.Name,
                    DateFrom = p.DateFrom,
                    DateTo = p.DateTo,
                    PostTransportTypes = p.PostTransportType.ToString(),
                    CargoDescription = p.Specification.Description,
                    CargoWeight = p.Specification.Weight,
                    CargoVolume = p.Specification.Volume,
                    AdditionalInfo = p.AdditionalInformation,
                    PublicationDate = p.PublicationDate,
                    UserCompany = p.User.CompanyName

                });
            }

            return View(model);
        }
        [Authorize]
        public ActionResult PostCargoDetails(long postId)
        {
            var post = _postCargoRepository.GetById(postId);
            var model = new PostCargoListDetailsModel
            {
                CountryFrom = post.LocationFrom.Country,
                CountryTo =  post.LocationTo.Country,
                LocalityTo = post.LocationTo.Locality.Name,
                LocalityFrom = post.LocationFrom.Locality.Name,
                Price = post.Price
            };
            
            return PartialView("PostCargoDetails", model);
        }

        

    }
}