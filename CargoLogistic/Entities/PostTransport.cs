using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities.Users;


namespace CargoLogistic.Domain.Entities
{
    public class PostTransport : Post
    {
        public virtual TransportSpecification Specification { get; set; }

        public PostTransport(ApplicationUser user, DateTime dateFrom, DateTime dateTo,
            Location locationFrom, Location locationTo, PostTransportType postTransportType, decimal price,
            bool status, string additionalInformation, TransportSpecification transportSpecification = null) 
            : base(user, dateFrom, dateTo, locationFrom, locationTo, postTransportType, price, status, additionalInformation)
        {
            Specification = transportSpecification;
        }

        protected PostTransport()
        {
            
        }
    }
}



