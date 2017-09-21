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
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<Locality, LocalityDto>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(c => c.Country.Name))
                .ForMember(dest=>dest.LocalityType, opt=>opt.Ignore());
            CreateMap<PostCargo, PostCargoEditDto>()
                .ForMember(dest => dest.CountryFrom, opt => opt.MapFrom(s => s.LocationFrom.Country.Name))
                .ForMember(dest => dest.CountryTo, opt => opt.MapFrom(s => s.LocationTo.Country.Name))
                .ForMember(dest => dest.LocalityFrom, opt => opt.MapFrom(s => s.LocationFrom.Locality.Name))
                .ForMember(dest => dest.LocalityTo, opt => opt.MapFrom(s => s.LocationTo.Locality.Name))
                .ForMember(dest => dest.PostTransportTypes, opt => opt.MapFrom(s => s.PostTransportType.ToString()))
                .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(s => s.AdditionalInformation))
                .ForMember(dest => dest.CargoDescription, opt => opt.MapFrom(s => s.Specification.Description))
                .ForMember(dest => dest.CargoWeight, opt => opt.MapFrom(s => s.Specification.Weight))
                .ForMember(dest => dest.CargoVolume, opt => opt.MapFrom(s => s.Specification.Volume))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(s => s.Id));
            CreateMap<PostCargo, PostCargoDetailsDto>()
                .IncludeBase<PostCargo, PostCargoEditDto>()
                .ForMember(dest=>dest.UserCompany, opt => opt.MapFrom(s => s.User.CompanyName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(s => s.User.Email))
                .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(s => s.User.PhoneNumber));
            CreateMap<PostTransport, PostTransportCreateDto>()
                .ForMember(dest => dest.CountryFrom, opt => opt.MapFrom(s => s.LocationFrom.Country.Name))
                .ForMember(dest => dest.CountryTo, opt => opt.MapFrom(s => s.LocationTo.Country.Name))
                .ForMember(dest => dest.LocalityFrom, opt => opt.MapFrom(s => s.LocationFrom.Locality.Name))
                .ForMember(dest => dest.LocalityTo, opt => opt.MapFrom(s => s.LocationTo.Locality.Name))
                .ForMember(dest => dest.PostTransportTypes, opt => opt.MapFrom(s => s.PostTransportType.ToString()))
                .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(s => s.AdditionalInformation))
                .ForMember(dest => dest.TransportDescription, opt => opt.MapFrom(s => s.Specification.Description))
                .ForMember(dest => dest.WeightCapacity, opt => opt.MapFrom(s => s.Specification.WeightCapacity))
                .ForMember(dest => dest.VolumeCapacity, opt => opt.MapFrom(s => s.Specification.VolumeCapacity))
                .ForMember(dest => dest.PostId, opt => opt.MapFrom(s => s.Id));
            CreateMap<PostTransport, PostTransportDetailsDto>()
                .IncludeBase<PostTransport, PostTransportCreateDto>()
                .ForMember(dest => dest.UserCompany, opt => opt.MapFrom(s => s.User.CompanyName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(s => s.User.Email))
                .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(s => s.User.PhoneNumber));
            
        }
    }
}