using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.BLL.DTO
{
    public class PostCargoDetailsDto : PostCargoEditDto
    {
        public bool Status { get; set; }

        public DateTime PublicationDate { get; set; }

        public string UserCompany { get; set; }

        public int NumberOfViews { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }
    }
}
