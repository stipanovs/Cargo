using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities.Users;


namespace CargoLogistic.Domain.Entities
{
    public class PostCargo : Post
    {
        public virtual CargoSpecification Specification { get; set; }
       
        public PostCargo(ApplicationUser user, DateTime dateFrom, DateTime dateTo,
            Location locationFrom, Location locationTo, PostTransportType postTransportType, double price,
            bool status, string additionalInformation, CargoSpecification specification = null) 
            : base(user, dateFrom, dateTo, locationFrom, locationTo, postTransportType, price, status, additionalInformation)
        {
            Specification = specification;
        }

        public PostCargo(CargoSpecification specification)
        {
            Specification = specification;
        }

        protected PostCargo()
        {
            
        }
    }
}
