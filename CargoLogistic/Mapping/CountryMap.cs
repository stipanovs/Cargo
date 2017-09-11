using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using FluentNHibernate.Mapping;


namespace CargoLogistic.DAL.Mapping
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

            HasMany(x => x.Locations).Cascade.All().Inverse();
        }
       

    }
}
