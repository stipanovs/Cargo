using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.BLL.DTO
{
    public class PostCargoEditDto : PostCargoCreateDto
    {
        public long PostId { get; set; }
    }
}
