using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;

namespace CargoLogistic.DAL.Interfaces
{
    public interface IPostTransportRepository : IRepository<PostTransport>
    {
        IEnumerable<PostTransport> GetAllPostTransportUser(string userId);
        IEnumerable<PostTransport> GetAllPublishedPostTransport();
        IEnumerable<PostTransport> SearchPostTransportByNameCountryFromCountryTo(string countryFromName, string countryToName);
    }
}
