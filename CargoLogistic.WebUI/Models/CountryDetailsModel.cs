using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CargoLogistic.Domain.Entities;
using CargoLogistic.WebUI.Models.CustomValidationAttributes;

namespace CargoLogistic.WebUI.Models
{
    public class CountryDetailsModel
    {
        public long CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [PositiveNumber]
        public int NumericCode { get; set; }
        [Required]
        [StringLength(3)]
        public string Alpha2Code { get; set; }
        public IEnumerable<Locality> Localities { get; set; }

    }
}