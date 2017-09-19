using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.DAL.Entities;


namespace CargoLogistic.BLL.Infrastructure
{
    
    public class AutomapperBLLProfile : Profile
    {
        public AutomapperBLLProfile()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<Locality, LocalityDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(c => c.Country.Name));

        }
    }
}