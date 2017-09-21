using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoLogistic.BLL.DTO;
using CargoLogistic.DAL.Entities.Users;

namespace CargoLogistic.BLL.Intefaces
{
    public interface IPostCargoService
    {
        void CreatePostCargo(PostCargoCreateDto createPostCargoDto, ApplicationUser user);
        PostCargoEditDto GetPostCargoEditDtoById(long Id);
        void EditPostCargo(PostCargoEditDto postCargoEditDto);
        void DeletePostCargo(long Id);
        PostCargoDetailsDto GetPostCargoDetailsDtoById(long Id);
        IEnumerable<PostCargoDetailsDto> GetAllPostCargoDetailsDtos(string UserId);
        void PublichPostCargo(long Id);
        void UnPublichPostCargo(long Id);
        IEnumerable<PostCargoDetailsDto> GetAllPublishedPostCargoDetailsDtos();
        PostCargoDetailsDto PostCargoDetailsAuthorized(long Id);
        IEnumerable<PostCargoDetailsDto> SearchPostCargoDetailsDtos(SearchPostCargoDto searchDto);

    }
}
