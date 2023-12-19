
using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Interfaces
{
    public interface IUserBLLService
    {
        Task<bool> Create(UserCreateDTO model);
        Task<IEnumerable<UserDisplayDTO>> Get();
        Task<IEnumerable<UserDisplayDTO>?> GetByName(string name);
        Task<UserDisplayDTO?> GetByID(int id);
        Task<bool> Update(int id, UserCreateDTO model);
        Task<bool> Delete(int id);
    }
}