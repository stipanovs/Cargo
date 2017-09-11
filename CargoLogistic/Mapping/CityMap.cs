using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using FluentNHibernate.Mapping;

namespace CargoLogistic.DAL
{
    public class CityMap : SubclassMap<City>
    {
        public CityMap()
        {
            Table("Locality");
            DiscriminatorValue(@"City");
                       
        }
    }
}
