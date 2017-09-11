using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Entities.SpecificationType;
using CargoLogistic.DAL.Entities.Users;


namespace CargoLogistic.DAL.Factory
{
    
    public class PostFactory
    {
        public Post CreateNewPost(ApplicationUser user, DateTime dataFrom, DateTime dateTo,
            Location locationFrom, Location locationTo, string transportType, decimal price,  string additionalInformation, ISpecification specification)
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
