using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Repository;

namespace CargoLogistic.DAL.Interfaces
{
    public interface IPostCargoRepository : IRepository<PostCargo>
    {
        IEnumerable<PostCargo> GetAllPostCargoUser(string userId);
        IEnumerable<PostCargo> GetAllPublishedPostCargo();
        IEnumerable<PostCargo> SearchPostCargoByNameCountryFromCountryTo(string countryFromName, string countryToName );
    }
}
