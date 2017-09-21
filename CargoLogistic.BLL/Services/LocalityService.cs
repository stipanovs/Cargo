using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.DAL.Factory;
using CargoLogistic.DAL.Interfaces;

namespace CargoLogistic.BLL.Services
{
    public class LocalityService : ILocalityService
    {
        private ICountryRepository _countryRepository;
        private ILocalityRepository _localityRepository;

        public LocalityService(ICountryRepository countryRepository, ILocalityRepository localityRepository)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
        }

        public void CreateLocality(LocalityDto localityDto)
        {
            var country = _countryRepository.GetByName(localityDto.Country);
            var locality = LocalityFactory.CreateLocality(localityDto.Name, country, localityDto.LocalityType);
            _localityRepository.Save(locality);
        }
    }
}