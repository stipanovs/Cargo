using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CargoLogistic.DAL.Entities;
using CargoLogistic.WebUI.Models.CustomValidationAttributes;

namespace CargoLogistic.WebUI.Models
{
    public class CountryDetailsModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Please enter up to 3 digits for a NumericCode")]
        public int NumericCode { get; set; }
        [Required]
        [StringLength(2)]
        public string Alpha2Code { get; set; }
        
    }
}