using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using CargoLogistic.Domain;


namespace CargoLogistic.Mapping
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Table("Country");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.NumericCode);
            Map(x => x.Alpha2Code);

            HasMany(x => x.Locations).Inverse();
        }
       

    }
}
