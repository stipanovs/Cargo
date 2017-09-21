using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.NHibernateInitialize;
using NHibernate;

namespace CargoLogistic.DAL.Repository
{
    public class PostTransportRepository : Repository<PostTransport>, IPostTransportRepository
    {
        public ISession _session;

        public PostTransportRepository(ISession session)
        {
            _session = session;
        }

        public PostTransportRepository()
        {
            _session = NHibernateProvider.GetSession();
        }

        public IEnumerable<PostTransport> GetAllPostTransportUser(string userId)
        {
            return _session.QueryOver<PostTransport>()
                .Where(x => x.User.Id == userId)
                .List<PostTransport>();
        }

        public IEnumerable<PostTransport> GetAllPublishedPostTransport()
        {
            var posts = _session.QueryOver<PostTransport>()
                .Where(x => x.Status)
                .List<PostTransport>();
            return posts;
        }

        public IEnumerable<PostTransport> SearchPostTransportByNameCountryFromCountryTo(string countryFromName, string countryToName)
        {
            Country countryFrom = null;
            Country countryTo = null;
            Location locationFrom = null;
            Location locationTo = null;
            PostTransport postTransport = null;

            var posts = _session.QueryOver(() => postTransport)
                .JoinAlias(p => p.LocationFrom, () => locationFrom)
                .JoinAlias(p => p.LocationTo, () => locationTo)
                .JoinAlias(() => locationFrom.Country, () => countryFrom)
                .JoinAlias(() => locationTo.Country, () => countryTo)
                .Where(() => countryFrom.Name == countryFromName && countryTo.Name == countryToName)
                .List<PostTransport>();

            return posts;
        }
    }
}
