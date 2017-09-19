using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.BLL.DTO;

namespace CargoLogistic.BLL.Intefaces
{
    public interface ICountryService
    {
        CountryDTO GetById(long Id);
        CountryDTO GetByname(string name);
        void CreateCountry(CountryCreateDto countryDto);
        IEnumerable<CountryDTO> CountryDtos();
        IEnumerable<LocalityDto> LocalitiesDtos(CountryDTO countryDto);
    }
}
