using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.WebUI.Models;

namespace CargoLogistic.WebUI.App_Start
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<CountryDetailsModel, CountryDTO>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Localities, opt => opt.Ignore());
            CreateMap<CountryDetailsModel, CountryCreateDto>();
            CreateMap<CountryDTO, CountryListDetailsModel>();
            CreateMap<LocalityDto, LocalityModel>();
        }
    }
}