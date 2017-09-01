using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.Domain.Entities;

namespace CargoLogistic.Domain.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPostUser(string userId);
    }
}
