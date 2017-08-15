using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using CargoLogistic.Domain;

namespace CargoLogistic.Mapping
{
    public class LocalityMap : ClassMap<Locality>
    {
        public LocalityMap()
        {
            Table("Locality");
           
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.LocalityPlace).Column("LocalyPlaceId");
            Map(x => x.Line1).Column("Line1");
            Map(x => x.Line2).Column("Line2");
            Map(x => x.PostCode).Column("PostCode");
        }
    }
}
