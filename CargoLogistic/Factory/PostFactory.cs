using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities;
using CargoLogistic.Domain.Entities.SpecificationType;
using CargoLogistic.Domain.Entities.Users;


namespace CargoLogistic.Domain.Factory
{
    
    public class PostFactory
    {
        
        public Post CreateNewPost(ApplicationUser user, DateTime dataFrom, DateTime dateTo,
            Location locationFrom, Location locationTo, string transportType, double price,  string additionalInformation, ISpecification specification)
        {
            Post post = null;
            bool status = false;
            PostTransportType postTransportType;
            Enum.TryParse(transportType, true, out postTransportType);
            

            if (specification is CargoSpecification)
            {
                post = new PostCargo(user, dataFrom, dateTo, locationFrom, locationTo, postTransportType, price, status, additionalInformation, (CargoSpecification)specification);
            }
            else if (specification is TransportSpecification)
            {
                post = new PostTransport(user, dataFrom, dateTo, locationFrom, locationTo, postTransportType, price, status, additionalInformation, (TransportSpecification)specification);
            }
            return post;
        }

    }
}
