using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.BLL.DTO
{
    public class CountryCreateDto
    {
        public string Name { get; set; }
        public int NumericCode { get; set; }
        public string Alpha2Code { get; set; }
    }
}
