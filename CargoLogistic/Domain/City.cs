using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain
{
    public class City : LocalityPlace
    {
        
        public City(string name, Country country) : base(name, country)
        {
           
        }

        public City()
        {

        }

    }
}
