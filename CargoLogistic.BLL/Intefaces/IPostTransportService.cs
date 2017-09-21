using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.BLL.DTO;
using CargoLogistic.DAL.Entities.Users;

namespace CargoLogistic.BLL.Intefaces
{
    public interface IPostTransportService
    {
        IEnumerable<PostTransportDetailsDto> GetAllPostTransportDetailsDtos(string UserId);
        void CreatePostTransport(PostTransportCreateDto postTransportCreateDto, ApplicationUser user);
        PostTransportCreateDto GeTransportCreateDtoById(long Id);
        void EditPostTransport(PostTransportCreateDto postTransportCreateDto);
        PostTransportDetailsDto GetPostTransportDetailsDto(long Id);
        void DeletePostTransport(long Id);
        void PublishPostTransport(long Id);
        void UnPublishPostTransport(long Id);
        IEnumerable<PostTransportDetailsDto> GetAllPublishedPostTransportDetailsDtos();
        PostTransportDetailsDto PostTransportDetailsAuthorized(long Id);
        IEnumerable<PostTransportDetailsDto> SearchPostTransportDetailsDtos(SearchPostCargoDto searchDto);
    }
}
