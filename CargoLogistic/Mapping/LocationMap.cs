using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using CargoLogistic.Domain.Entities;

namespace CargoLogistic.Domain.Mapping
{
    public class LocationMap : ClassMap<Location>
    {
        public LocationMap()
        {
            Table("Location");
           
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Line1).Column("Line1");
            Map(x => x.Line2).Column("Line2");
            Map(x => x.PostCode).Column("PostCode");
            References(x => x.Country).Column("CountryId");
            References(x => x.Locality).Column("LocalityId");
        }
    }
}
