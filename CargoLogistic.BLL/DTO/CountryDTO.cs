using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;

namespace CargoLogistic.BLL.DTO
{
    public class CountryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int NumericCode { get; set; }
        public string Alpha2Code { get; set; }
        public IEnumerable<LocalityDTO> Locations { get; set; }
    }
}
