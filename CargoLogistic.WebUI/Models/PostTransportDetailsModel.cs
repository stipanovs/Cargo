using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoLogistic.WebUI.Models
{
    public class PostTransportDetailsModel : CreatePostTransportModel
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