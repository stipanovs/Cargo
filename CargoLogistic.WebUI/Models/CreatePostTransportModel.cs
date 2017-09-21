using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CargoLogistic.WebUI.Models.CustomValidationAttributes;

namespace CargoLogistic.WebUI.Models
{
    public class CreatePostTransportModel
    {
        public long PostId { get; set; }

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
        //[PositiveNumber(ErrorMessage = "Price must be positive(Server)")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "The length can't exceed 200 symbols")]
        public string AdditionalInfo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The length can't exceed 100 symbols")]
        public string TransportDescription { get; set; }

        public double WeightCapacity { get; set; }

        public double VolumeCapacity { get; set; }
        
    }
}