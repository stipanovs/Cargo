using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CargoLogistic.Domain
{
    public class Locality : EntityBase
    {
        
        public virtual LocalityPlace LocalityPlace { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string PostCode { get; set; }


        public Locality(LocalityPlace localityPlace, string line1, string line2, string postCode)
        {
            LocalityPlace = localityPlace;
            Line1 = line1;
            Line2 = line2;
            PostCode = postCode;
        }

        protected Locality()
        {

        }

        public override string ToString()
        {
            return $"{LocalityPlace.Country.Name}, {LocalityPlace?.Name}, {Line1}, {Line2}, {PostCode}" ;
        }
    }
}
