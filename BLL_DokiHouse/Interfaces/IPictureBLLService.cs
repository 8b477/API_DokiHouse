using Microsoft.AspNetCore.Http;

namespace BLL_DokiHouse.Interfaces
{
    public interface IPictureBLLService
    {
        Task<int> AddPictureProfil(int idUser, IFormFile file);
        Task<int> AddPictureBonsai(IFormFile file);
        Task<byte[]?> GetImageProfil(int idPicture);
        Task<IEnumerable<byte[]?>> GetImageBonsai(int idUser);
    }
}
