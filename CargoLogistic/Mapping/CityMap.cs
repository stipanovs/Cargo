using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using CargoLogistic.Domain;

namespace CargoLogistic.Mapping
{
    public class CityMap : SubclassMap<City>
    {
        public CityMap()
        {
            Table("LocalityPlace");
            DiscriminatorValue(@"City");
                       
        }
    }
}
