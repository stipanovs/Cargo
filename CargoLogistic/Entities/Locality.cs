using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain.Entities
{
    public abstract class Locality : EntityBase
    {
       
        public virtual string Name { get; set; }
        public virtual Country Country { get; set; }

        public Locality(string name, Country country)
        {
            Name = name;
            Country = country;
        }

        public Locality(string name)
        {
            Name = name;
            
        }

        protected Locality()
        {

        }
    }
}
