using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CargoLogistic.Domain.Entities;


namespace CargoLogistic.WebUI.Models
{
    public class CreatePostCargoDto
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
        public DateTime DateTo { get; set; }

        
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string AdditionalInfo { get; set; }

        public string CargoDescription { get; set; }
       
        public int CargoWeight { get; set; }

        public int CargoVolume { get; set; }


    }
}
