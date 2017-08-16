using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain
{
    public class PostDetailRow
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string CountryFrom { get; set; }
        public string CountryTo { get; set; }

        public string CityFrom { get; set; }
        public string CityTo { get; set; }

        public double Price { get; set; }



    }
}
