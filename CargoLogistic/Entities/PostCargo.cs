using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities.Users;


namespace CargoLogistic.DAL.Entities
{
    public class PostCargo : Post
    {
        public virtual CargoSpecification Specification { get; set; }
       
        public PostCargo(ApplicationUser user, DateTime dateFrom, DateTime dateTo,
            Location locationFrom, Location locationTo, PostTransportType postTransportType, decimal price,
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
