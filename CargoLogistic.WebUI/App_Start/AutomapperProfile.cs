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
            CreateMap<CountryDetailsModel, CountryDto>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Localities, opt => opt.Ignore());
            CreateMap<CountryDetailsModel, CountryCreateDto>();
            CreateMap<CountryDto, CountryListDetailsModel>();
            CreateMap<LocalityDto, LocalityModel>();
            CreateMap<CountryDto, CountryDetailsModel>();
            CreateMap<CountryDetailsModel, CountryDto>();
            CreateMap<CreateLocalityModel, LocalityDto>();

            CreateMap<CreatePostCargoModel, PostCargoCreateDto>();
            CreateMap<PostCargoEditDto, EditPostCargoModel>();
            CreateMap<EditPostCargoModel, PostCargoEditDto>();
            CreateMap<PostCargoDetailsDto, PostCargoDetailsModel>();

            CreateMap<PostTransportDetailsDto, PostTransportDetailsModel>();
            CreateMap<CreatePostTransportModel, PostTransportCreateDto>();
            CreateMap<PostTransportCreateDto, CreatePostTransportModel>();
            CreateMap<SearchPostCargoModel, SearchPostCargoDto>();
        }
    }
}