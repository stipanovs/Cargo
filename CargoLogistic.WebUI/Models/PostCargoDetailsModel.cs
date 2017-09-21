using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CargoLogistic.DAL.Entities;
using CargoLogistic.WebUI.Models.CustomValidationAttributes;

namespace CargoLogistic.WebUI.Models
{
    public class PostCargoDetailsModel : EditPostCargoModel
    {
        public bool Status { get; set; }

        [UIHint("MyPublishDate")]
        public DateTime PublicationDate { get; set; }

        public string UserCompany { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }

        public int NumberOfViews { get; set; }
    }
}