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
        private ILocalityRepository _localityRepository;

        public CountryService(ICountryRepository countryRepository, ILocalityRepository localityRepository)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
        }
        public IEnumerable<CountryDTO> CountryDtos()
        {
            var countries = Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(_countryRepository.GetAll());
            return countries;
        }

        public void CreateCountry(CountryCreateDto countryDto)
        {
            var country = Mapper.Map<CountryCreateDto, Country>(countryDto);
            _countryRepository.Save(country);
        }

        public CountryDTO GetById(long Id)
        {
            //if (Id == null)
            //    throw new ValidationException("Country Id is null", "");
            var country = _countryRepository.GetById(Id);
            if (country == null)
                throw new ValidationException("Country not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
            return Mapper.Map<Country, CountryDTO>(country);
        }

        public CountryDTO GetByname(string name)
        {
            var country = _countryRepository.GetByName(name);
            if (country == null)
                throw new ValidationException("Country not found", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Country, CountryDTO>());
            return Mapper.Map<Country, CountryDTO>(country);
        }

        public IEnumerable<LocalityDto> LocalitiesDtos(CountryDTO countryDto)
        {
            var country = _countryRepository.GetById(countryDto.Id);
            Mapper.Initialize(cfg => cfg.CreateMap<IEnumerable<Locality>, IEnumerable<LocalityDto>>());
            var localitiesDtos = Mapper.Map<IEnumerable<Locality>, IEnumerable<LocalityDto>>(country.Localities);
            return localitiesDtos;
        }
    }
}
