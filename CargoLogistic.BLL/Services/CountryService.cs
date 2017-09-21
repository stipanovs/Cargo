using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Infrastructure;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Interfaces;


namespace CargoLogistic.BLL.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;
       
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IEnumerable<CountryDto> CountryDtos()
        {
            var countries = Mapper.Map<IEnumerable<Country>, List<CountryDto>>(_countryRepository.GetAll());
            return countries;
        }

        public void CreateCountry(CountryCreateDto countryDto)
        {
            var country = Mapper.Map<CountryCreateDto, Country>(countryDto);
            _countryRepository.Save(country);
        }

        public void DeleteCountry(long countryId)
        {
            var country = _countryRepository.GetById(countryId);
            _countryRepository.Delete(country);
        }

        public void EditCountry(CountryDto countryDto)
        {
            var country = Mapper.Map<Country>(countryDto);
            _countryRepository.Update(country);
        }

        public CountryDto GetById(long Id)
        {
            var country = _countryRepository.GetById(Id);
            if (country == null)
                throw new ValidationException("Country not found", "");
            
            return Mapper.Map<Country, CountryDto>(country);
        }

        public CountryDto GetByName(string name)
        {
            var country = _countryRepository.GetByName(name);
            if (country == null)
                throw new ValidationException("Country not found", "");

            return Mapper.Map<Country, CountryDto>(country);
        }

        public IEnumerable<LocalityDto> LocalitiesDtosByCountryName(string countryName)
        {
            var country = _countryRepository.GetByName(countryName);
            var localitiesDtos = Mapper.Map<IEnumerable<Locality>, IEnumerable<LocalityDto>>(country.Localities);
            return localitiesDtos;
        }
    }
}
