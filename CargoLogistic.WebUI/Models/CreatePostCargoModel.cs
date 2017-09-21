using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CargoLogistic.WebUI.Models.CustomValidationAttributes;


namespace CargoLogistic.WebUI.Models
{
    public class CreatePostCargoModel
    {
        public string CountryFrom { get; set; }
        
        public string LocalityFrom { get; set; }

        public string CountryTo { get; set; }

        public string LocalityTo { get; set; }
        
        [Display(Name = "Transport Type")]
        public string PostTransportTypes { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        [DateToGreaterThanDateFrom("DateFrom")]
        public DateTime DateTo { get; set; }

        [Required]
        //[DataType(DataType.Currency)]
        [PositivePrice(ErrorMessage = "Price must be positive(Server)")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "The length can't exceed 200 symbols")]
        public string AdditionalInfo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The length can't exceed 100 symbols")]
        public string CargoDescription { get; set; }

        [Display(Name = "Cargo Weight, tonnes")]
        public double CargoWeight { get; set; }

        [Display(Name ="Cargo Volume, m3" )]
        public double CargoVolume { get; set; }
        
    }
}
