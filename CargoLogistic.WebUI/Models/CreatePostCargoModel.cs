using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CargoLogistic.DAL.Entities;
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
        public string PostTransportType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateToGreaterThanDateFrom("DateFrom")]
        public DateTime DateTo { get; set; }

        
        [DataType(DataType.Currency)]
        [PositiveNumber(ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "The length can't exceed 200 symbols")]
        public string AdditionalInfo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The length can't exceed 100 symbols")]
        public string CargoDescription { get; set; }

        [PositiveNumber(ErrorMessage = "Weight must be positive")]
        public int CargoWeight { get; set; }

        [PositiveNumber(ErrorMessage = "Volume must be positive")]
        public int CargoVolume { get; set; }


    }
}
