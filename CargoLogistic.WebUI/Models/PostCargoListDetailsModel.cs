using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CargoLogistic.DAL.Entities;
using CargoLogistic.WebUI.Models.CustomValidationAttributes;

namespace CargoLogistic.WebUI.Models
{
    public class PostCargoListDetailsModel
    {
        public long PostId { get; set; }

        [UIHint("MyPublishDate")]
        public DateTime PublicationDate { get; set; }

        public Country CountryFrom { get; set; }

        public string LocalityFrom { get; set; }

        public Country CountryTo { get; set; }

        public string LocalityTo { get; set; }
        
        [Display(Name = "Transport Type")]
        public string PostTransportTypes { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [UIHint("MyDate")]
        public DateTime DateFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [UIHint("MyDate")]
        [DateToGreaterThanDateFrom("DateFrom")]
        public DateTime DateTo { get; set; }


        [DataType(DataType.Currency)]
        [PositiveNumber(ErrorMessage = "Price must be positive")]
        [UIHint("Currency")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "The length can't exceed 200 symbols")]
        public string AdditionalInfo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The length can't exceed 100 symbols")]
        public string CargoDescription { get; set; }

        [PositiveNumber(ErrorMessage = "Weight must be positive")]
        public double CargoWeight { get; set; }

        [PositiveNumber(ErrorMessage = "Volume must be positive")]
        public double CargoVolume { get; set; }

        public string UserCompany { get; set; }

        public bool Status { get; set; }

        public int NumberOfViews { get; set; }


    }
}