using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities.Users;
using FluentNHibernate.Mapping;

namespace CargoLogistic.DAL.Mapping
{
    public  class ApplicationUserMap : ClassMap<ApplicationUser>
    {
        public ApplicationUserMap()
        {
            Id(x => x.Id).Column("applicationuser_key");
            Map(x => x.CompanyName).Column("CompanyName");
            Map(x => x.ContactPerson).Column("ContactPerson");
            Map(x => x.City).Column("City");
        }
    }
}
