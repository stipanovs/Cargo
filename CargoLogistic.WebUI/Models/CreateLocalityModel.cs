using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoLogistic.WebUI.Models
{
    public class CreateLocalityModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Select Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Select Locality Type")]
        public string LocalityType { get; set; }
    }
}