using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities.Users;
using FluentNHibernate.Mapping;

namespace CargoLogistic.Domain.Mapping
{
    public  class ApplicationUserMap : ClassMap<ApplicationUser>
    {
        public ApplicationUserMap()
        {
            Id(x => x.Id).Column("applicationuser_key");
        }

    }
}
