using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    public class PostCargoService : IPostCargoService
    {
        private ICountryRepository _countryRepository;
        private ILocalityRepository _localityRepository;
        private IRepository<Location> _locationRepository;
        private IRepository<CargoSpecification> _cargospecRepository;
        private IPostCargoRepository _postCargoRepository;

        public PostCargoService(ICountryRepository countryRepository, ILocalityRepository localityRepository, 
            IRepository<Location> locationRepository, IRepository<CargoSpecification> cargospecRepository, 
            IPostCargoRepository postCargoRepository)
        {
            _countryRepository = countryRepository;
            _localityRepository = localityRepository;
            _locationRepository = locationRepository;
            _cargospecRepository = cargospecRepository;
            _postCargoRepository = postCargoRepository;
        }

        public void CreatePostCargo(PostCargoCreateDto createPostCargoDto, ApplicationUser user)
        {
            Location locationFrom = new Location()
            {
                Country = _countryRepository.GetByName(createPostCargoDto.CountryFrom),
                Locality = _localityRepository.GetByName(createPostCargoDto.LocalityFrom)
            };

            Location locationTo = new Location()
            {
                Country = _countryRepository.GetByName(createPostCargoDto.CountryTo),
                Locality = _localityRepository.GetByName(createPostCargoDto.LocalityTo)
            };

            CargoSpecification cargoSpecification = new CargoSpecification()
            {
                Description = createPostCargoDto.CargoDescription,
                Weight = createPostCargoDto.CargoWeight,
                Volume = createPostCargoDto.CargoVolume
            };

            var postFactory = new PostFactory();
            var post = postFactory.CreateNewPost(user, createPostCargoDto.DateFrom, createPostCargoDto.DateTo, locationFrom, locationTo,
                createPostCargoDto.PostTransportTypes, createPostCargoDto.Price, createPostCargoDto.AdditionalInfo, cargoSpecification);

            _locationRepository.Save(locationFrom);
            _locationRepository.Save(locationTo);
            _cargospecRepository.Save(cargoSpecification);
            _postCargoRepository.Save(post as PostCargo);
        }

        public PostCargoEditDto GetPostCargoEditDtoById(long Id)
        {
            var post = _postCargoRepository.GetById(Id);
            return Mapper.Map<PostCargoEditDto>(post);
        }

        public void EditPostCargo(PostCargoEditDto postCargoEditDto)
        {
            var post = _postCargoRepository.GetById(postCargoEditDto.PostId);

            Location locationFrom = post.LocationFrom;
            locationFrom.Country = _countryRepository.GetByName(postCargoEditDto.CountryFrom);
            locationFrom.Locality = _localityRepository.GetByName(postCargoEditDto.LocalityFrom);

            Location locationTo = post.LocationTo;
            locationTo.Country = _countryRepository.GetByName(postCargoEditDto.CountryTo);
            locationTo.Locality = _localityRepository.GetByName(postCargoEditDto.LocalityTo);

            CargoSpecification cargoSpecification = post.Specification;
            cargoSpecification.Description = postCargoEditDto.CargoDescription;
            cargoSpecification.Weight = postCargoEditDto.CargoWeight;
            cargoSpecification.Volume = postCargoEditDto.CargoVolume;

            post.LocationTo = locationTo;
            post.LocationFrom = locationFrom;
            post.Specification = cargoSpecification;
            post.Price = postCargoEditDto.Price;
            PostTransportType postTransportType;
            Enum.TryParse(postCargoEditDto.PostTransportTypes, true, out postTransportType);
            post.PostTransportType = postTransportType;
            post.DateFrom = postCargoEditDto.DateFrom;
            post.DateTo = postCargoEditDto.DateTo;
            post.AdditionalInformation = postCargoEditDto.AdditionalInfo;

            _postCargoRepository.Update(post);
        }

        public PostCargoDetailsDto GetPostCargoDetailsDtoById(long Id)
        {
            var post = _postCargoRepository.GetById(Id);
            return Mapper.Map<PostCargoDetailsDto>(post);
        }

        
        public void PublichPostCargo(long Id)
        {
            var post = _postCargoRepository.GetById(Id);
            post.Status = true;
            post.PublicationDate = DateTime.Now;
            _postCargoRepository.Update(post);
        }

        public void UnPublichPostCargo(long Id)
        {
            var post = _postCargoRepository.GetById(Id);
            post.Status = false;
            _postCargoRepository.Update(post);
        }

        
        public void DeletePostCargo(long Id)
        {
            var post = _postCargoRepository.GetById(Id);
            _postCargoRepository.Delete(post);
        }

        public IEnumerable<PostCargoDetailsDto> GetAllPostCargoDetailsDtos(string userId)
        {
            var postCargoList = _postCargoRepository.GetAllPostCargoUser(userId);
            return Mapper.Map<IEnumerable<PostCargoDetailsDto>>(postCargoList);
        }

        public IEnumerable<PostCargoDetailsDto> GetAllPublishedPostCargoDetailsDtos()
        {
            var postCargoList = _postCargoRepository.GetAllPublishedPostCargo()
                .OrderByDescending(x=>x.PublicationDate);
            return Mapper.Map<IEnumerable<PostCargoDetailsDto>>(postCargoList);
        }

        public PostCargoDetailsDto PostCargoDetailsAuthorized(long Id)
        {
            var post = _postCargoRepository.GetById(Id);
            post.NumberOfViews += 1;
            _postCargoRepository.Update(post);

            return Mapper.Map<PostCargoDetailsDto>(post);
        }

        public IEnumerable<PostCargoDetailsDto> SearchPostCargoDetailsDtos(SearchPostCargoDto searchDto)
        {
            var posts = _postCargoRepository.SearchPostCargoByNameCountryFromCountryTo(searchDto.CountryFrom,
                searchDto.CountryTo);
            return Mapper.Map<IEnumerable<PostCargoDetailsDto>>(posts);
        }
    }
}
