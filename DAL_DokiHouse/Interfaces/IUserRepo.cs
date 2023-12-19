using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse
{
    public interface IUserRepo : IRepo<User, UserDTO, UserCreateDTO, UserDisplayDTO, int, string>
    {
        Task<UserDTO?> Logger(string email, string motDePasse);
    }
}
