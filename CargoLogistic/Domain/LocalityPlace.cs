using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain
{
    public abstract class LocalityPlace : EntityBase
    {
       
        public virtual string Name { get; set; }
        public virtual Country Country { get; set; }

        public LocalityPlace(string name, Country country)
        {
            Name = name;
            Country = country;
        }

        protected LocalityPlace()
        {

        }
    }
}
