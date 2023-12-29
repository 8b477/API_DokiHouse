using Microsoft.AspNetCore.Http;

namespace DAL_DokiHouse.Interfaces
{
    public interface IPictureRepo
    {
        Task<int> AddPictureProfil(IFormFile file);
        Task<int> AddPictureBonsai(IFormFile file);
        Task<byte[]?> GetImageProfil(int idPicture);
        Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser);
    }
}
