using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Interfaces;
using CargoLogistic.NHibernateInitialize;
using FluentNHibernate.Automapping;
using NHibernate;

namespace CargoLogistic.DAL.Repository
{
    public class PostCargoRepository : Repository<PostCargo>, IPostCargoRepository
    {
        public ISession _session;

        public PostCargoRepository()
        {
            _session = NHibernateProvider.GetSession();
        }

        public PostCargoRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<PostCargo> GetAllPostCargoUser(string userId)
        {
            return _session.QueryOver<PostCargo>()
                .Where(x => x.User.Id == userId)
                .List<PostCargo>();
        }
    }
}
