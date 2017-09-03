using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

using CargoLogistic.Domain.Entities;

namespace CargoLogistic.Domain.Mapping
{
    public class VillageMap : SubclassMap<Village>
    {
        public VillageMap()
        {
            Table("Locality");
            DiscriminatorValue(@"Village");
        }
    }
}
