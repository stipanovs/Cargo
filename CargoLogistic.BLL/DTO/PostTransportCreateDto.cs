using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.BLL.DTO
{
    public class PostTransportCreateDto
    {
        public long PostId { get; set; }

        public string CountryFrom { get; set; }

        public string LocalityFrom { get; set; }

        public string CountryTo { get; set; }

        public string LocalityTo { get; set; }

        public string PostTransportTypes { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public decimal Price { get; set; }

        public string AdditionalInfo { get; set; }

        public string TransportDescription { get; set; }

        public double WeightCapacity { get; set; }

        public double VolumeCapacity { get; set; }
    }
}
