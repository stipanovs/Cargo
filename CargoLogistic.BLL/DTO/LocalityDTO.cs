using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.BLL.DTO
{
    public class LocalityDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CountryDTO Country { get; set; }
    }
}
