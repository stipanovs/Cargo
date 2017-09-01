using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities;
using CargoLogistic.NHibernateInitialize;
using FluentNHibernate.Automapping;
using NHibernate;

namespace CargoLogistic.Domain.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public ISession _session;

        public PostRepository()
        {
            _session = NHibernateProvider.GetSession();
        }

        public PostRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<Post> GetAllPostUser(string userId)
        {
            return _session.QueryOver<PostCargo>()
                .Where(x => x.User.Id == userId)
                .List<PostCargo>();
        }
    }
}
