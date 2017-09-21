using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;

namespace CargoLogistic.BLL.DTO
{
    public class CountryDto : CountryCreateDto
    {
        public long Id { get; set; }
        public IEnumerable<LocalityDto> Localities { get; set; }
    }
}
