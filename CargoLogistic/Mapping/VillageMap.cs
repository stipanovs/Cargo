using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using FluentNHibernate.Mapping;

namespace CargoLogistic.DAL.Mapping
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
