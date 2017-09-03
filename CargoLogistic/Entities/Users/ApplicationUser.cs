﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.AspNet.Identity;

namespace CargoLogistic.Domain.Entities.Users
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string CompanyName { get; set; }
        public virtual int City { get; set; }
        public virtual int ContactPerson { get; set; }

    }
}
