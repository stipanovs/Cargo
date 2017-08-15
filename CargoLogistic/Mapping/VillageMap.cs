using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using CargoLogistic.Domain;

namespace CargoLogistic.Mapping
{
    public class VillageMap : SubclassMap<Village>
    {
        public VillageMap()
        {
            Table("LocalityPlace");
            DiscriminatorValue(@"Village");
        }
    }
}
