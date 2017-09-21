using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.BLL.DTO;

namespace CargoLogistic.BLL.Intefaces
{
    public interface ILocalityService
    {

        void CreateLocality(LocalityDto localityDto);
    }
}
