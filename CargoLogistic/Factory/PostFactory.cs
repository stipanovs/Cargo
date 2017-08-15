using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain;
using CargoLogistic.Domain.SpecificationType;
using Microsoft.Scripting.Utils;


namespace CargoLogistic
{
    
    public class PostFactory
    {
        
        public Post CreateNewPost(DateTime dataFrom, DateTime dateTo,
            Locality locationFrom, Locality locationTo, double price, string additionalInformation, ISpecification specification)
        {
            Post post = null;

            if (specification is CargoSpecification)
            {
                post = new PostCargo(dataFrom, dateTo, locationFrom, locationTo, price, additionalInformation, (CargoSpecification)specification);
            }
            else if (specification is TransportSpecification)
            {
                post = new PostTransport(dataFrom, dateTo, locationFrom, locationTo, price, additionalInformation, (TransportSpecification)specification);
            }
            return post;
        }

    }
}
