using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CargoLogistic.BLL.DTO;
using CargoLogistic.BLL.Intefaces;
using CargoLogistic.DAL.Entities;
using CargoLogistic.DAL.Entities.Users;
using CargoLogistic.DAL.Factory;
using CargoLogistic.DAL.Interfaces;

namespace CargoLogistic.BLL.Services
{
    public class PostTransportService : IPostTransportService
    {
        private ICountryRepository _countryRepository;
        private ILocalityRepository _localityRepository;
        private IRepository<Location> _locationRepository;
        private IRepository<TransportSpecification> _transportSpecRepository;
        private IPostTransportRepository _postTransportRepository;

        public PostTransportService(ICountryRepository countryRepository, ILocalityRepository localityRepository, 
            IRepository<Location> locationRepository, IRepository<TransportSpecification> transportSpecRepository, 
            IPostTransportRepository postTransportRepository)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
            _locationRepository = locationRepository;
            _transportSpecRepository = transportSpecRepository;
            _postTransportRepository = postTransportRepository;
        }

        public void CreatePostTransport(PostTransportCreateDto postTransportCreateDto, ApplicationUser user)
        {
            Location locationFrom = new Location()
            {
                Country = _countryRepository.GetByName(postTransportCreateDto.CountryFrom),
                Locality = _localityRepository.GetByName(postTransportCreateDto.LocalityFrom)
            };

            Location locationTo = new Location()
            {
                Country = _countryRepository.GetByName(postTransportCreateDto.CountryTo),
                Locality = _localityRepository.GetByName(postTransportCreateDto.LocalityTo)
            };

            TransportSpecification transportSpecification = new TransportSpecification()
            {
                Description = postTransportCreateDto.TransportDescription,
                WeightCapacity = postTransportCreateDto.WeightCapacity,
                VolumeCapacity = postTransportCreateDto.VolumeCapacity
            };

            var postFactory = new PostFactory();
            var post = postFactory.CreateNewPost(user, postTransportCreateDto.DateFrom, postTransportCreateDto.DateTo, locationFrom, locationTo,
                postTransportCreateDto.PostTransportTypes, postTransportCreateDto.Price, postTransportCreateDto.AdditionalInfo, transportSpecification);

            _locationRepository.Save(locationFrom);
            _locationRepository.Save(locationTo);
            _transportSpecRepository.Save(transportSpecification);
            _postTransportRepository.Save(post as PostTransport);
        }

        public PostTransportCreateDto GeTransportCreateDtoById(long Id)
        {
            var post = _postTransportRepository.GetById(Id);
            return Mapper.Map<PostTransportCreateDto>(post);
        }

        public IEnumerable<PostTransportDetailsDto> GetAllPostTransportDetailsDtos(string userId)
        {
            var postTransportList = _postTransportRepository.GetAllPostTransportUser(userId);
            return Mapper.Map<IEnumerable<PostTransportDetailsDto>>(postTransportList);
        }

        public void EditPostTransport(PostTransportCreateDto postTransportCreateDto)
        {
            var post = _postTransportRepository.GetById(postTransportCreateDto.PostId);

            Location locationFrom = post.LocationFrom;
            locationFrom.Country = _countryRepository.GetByName(postTransportCreateDto.CountryFrom);
            locationFrom.Locality = _localityRepository.GetByName(postTransportCreateDto.LocalityFrom);

            Location locationTo = post.LocationTo;
            locationTo.Country = _countryRepository.GetByName(postTransportCreateDto.CountryTo);
            locationTo.Locality = _localityRepository.GetByName(postTransportCreateDto.LocalityTo);

            TransportSpecification transportSpecification = post.Specification;
            transportSpecification.Description = postTransportCreateDto.TransportDescription;
            transportSpecification.WeightCapacity = postTransportCreateDto.WeightCapacity;
            transportSpecification.VolumeCapacity = postTransportCreateDto.VolumeCapacity;

            post.LocationTo = locationTo;
            post.LocationFrom = locationFrom;
            post.Specification = transportSpecification;
            post.Price = postTransportCreateDto.Price;
            PostTransportType postTransportType;
            Enum.TryParse(postTransportCreateDto.PostTransportTypes, true, out postTransportType);
            post.PostTransportType = postTransportType;
            post.DateFrom = postTransportCreateDto.DateFrom;
            post.DateTo = postTransportCreateDto.DateTo;
            post.AdditionalInformation = postTransportCreateDto.AdditionalInfo;

            _postTransportRepository.Update(post);
        }

        public PostTransportDetailsDto GetPostTransportDetailsDto(long Id)
        {
            var post = _postTransportRepository.GetById(Id);
            return Mapper.Map<PostTransportDetailsDto>(post);
        }

        public void DeletePostTransport(long Id)
        {
            var post = _postTransportRepository.GetById(Id);
            _postTransportRepository.Delete(post);
        }

        public void PublishPostTransport(long Id)
        {
            var post = _postTransportRepository.GetById(Id);
            post.Status = true;
            post.PublicationDate = DateTime.Now;
            _postTransportRepository.Update(post);
        }

        public void UnPublishPostTransport(long Id)
        {
            var post = _postTransportRepository.GetById(Id);
            post.Status = false;
            _postTransportRepository.Update(post);
        }

        public IEnumerable<PostTransportDetailsDto> GetAllPublishedPostTransportDetailsDtos()
        {
            var postTransportList = _postTransportRepository.GetAllPublishedPostTransport()
                .OrderByDescending(x => x.PublicationDate);
            return Mapper.Map<IEnumerable<PostTransportDetailsDto>>(postTransportList);
        }

        public PostTransportDetailsDto PostTransportDetailsAuthorized(long Id)
        {
            var post = _postTransportRepository.GetById(Id);
            post.NumberOfViews += 1;
            _postTransportRepository.Update(post);
            return Mapper.Map<PostTransportDetailsDto>(post);
        }

        public IEnumerable<PostTransportDetailsDto> SearchPostTransportDetailsDtos(SearchPostCargoDto searchDto)
        {
            var posts = _postTransportRepository.SearchPostTransportByNameCountryFromCountryTo(searchDto.CountryFrom,
                searchDto.CountryTo);
            return Mapper.Map<IEnumerable<PostTransportDetailsDto>>(posts);
        }
    }
    
}
