using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using CargoLogistic.Domain;

namespace CargoLogistic.Mapping
{
    public class LocalityPlaceMap : ClassMap<LocalityPlace>
    {
        public LocalityPlaceMap()
        {
            Table("LocalityPlace");
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable();

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Column("Name");
            References(x => x.Country).Column("CountryId");
        }

    }
}
