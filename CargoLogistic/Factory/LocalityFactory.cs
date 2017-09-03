using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities;

namespace CargoLogistic.Domain.Factory
{
    public class LocalityFactory
    {
        public static Locality CreateLocality(string name, Country country, string localityType)
        {
            LocalityType type;

           Enum.TryParse(localityType, true, out type);

            if(type == LocalityType.Village)
                return new Village(name, country);
            return new City(name, country);

        }
    }
}
