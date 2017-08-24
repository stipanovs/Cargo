using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain.Entities
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

        public LocalityPlace(string name)
        {
            Name = name;
            
        }

        protected LocalityPlace()
        {

        }
    }
}
