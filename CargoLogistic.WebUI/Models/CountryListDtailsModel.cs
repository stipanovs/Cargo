using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CargoLogistic.BLL.DTO;
using CargoLogistic.DAL.Entities;

namespace CargoLogistic.WebUI.Models
{
    public class CountryListDetailsModel : CountryDetailsModel
    {
        public IEnumerable<LocalityModel> Localities { get; set; }
    }
}