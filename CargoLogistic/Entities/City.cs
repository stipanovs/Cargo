using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.DAL.Entities
{
    public class City : Locality
    {
        
        public City(string name, Country country) : base(name, country)
        {
           
        }

       
        public City()
        {

        }

    }
}
