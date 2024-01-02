using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using Entities_DokiHouse.Entities;

using System.Reflection;

using static DAL_DokiHouse.UserRepo;

namespace DAL_DokiHouse
{
    public interface IUserRepo : IRepo<User, UserDTO, UserCreateDTO, UserDisplayDTO, int, string>
    {
        Task<User?> Logger(string email, string motDePasse);
        Task<bool> UpdateProfilPicture(int idUser, int idPicture);
        Task<IEnumerable<UserEveryDTO>?> GetEvery();
    }
}
