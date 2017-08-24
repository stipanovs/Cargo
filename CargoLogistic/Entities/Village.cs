using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain.Entities
{
    public class Village : LocalityPlace
    {
        
        public Village(string name, Country country) : base(name, country)
        {

        }

        protected Village()
        {

        }

    }
}
