using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using FluentNHibernate.Mapping;

namespace CargoLogistic.DAL.Mapping
{
    public class LocalityMap : ClassMap<Locality>
    {
        public LocalityMap()
        {
            Table("Locality");
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable();

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Column("Name");
            References(x => x.Country).Column("CountryId");
        }

    }
}
