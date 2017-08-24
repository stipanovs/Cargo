using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain.Entities
{
    public abstract class EntityBase
    {
        public virtual long Id { get; protected set; }
    }
}
