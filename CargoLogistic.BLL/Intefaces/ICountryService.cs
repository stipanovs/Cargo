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
        CountryDto GetById(long Id);
        CountryDto GetByName(string name);
        void CreateCountry(CountryCreateDto countryDto);
        IEnumerable<CountryDto> CountryDtos();
        IEnumerable<LocalityDto> LocalitiesDtosByCountryName(string countryName);
        void EditCountry(CountryDto countryDto);
        void DeleteCountry(long countryId);
    }
}
