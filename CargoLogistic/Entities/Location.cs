using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Interpreter;


namespace CargoLogistic.DAL.Entities
{
    public class Location : EntityBase
    {
        public virtual Country Country { get; set; }
        public virtual Locality Locality { get; set; }

        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string PostCode { get; set; }


        public Location(Country country, Locality locality, string line1, string line2, string postCode)
        {
            Country = country;
            Locality = locality;
            Line1 = line1;
            Line2 = line2;
            PostCode = postCode;
        }

        public Location(Country country, Locality locality)
        {
            Country = country;
            Locality = locality;
           
        }
        

        public Location()
        {

        }

        
    }
}
