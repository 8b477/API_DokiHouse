using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Interfaces
{
    public interface IBonsaiBLLService
    {
        Task<int> Create(BonsaiCreateDTO model);
        Task<IEnumerable<BonsaiAndChild>?> Get();
        Task<IEnumerable<BonsaiAndChild>> Get(int idUser);
        Task<BonsaiDisplayDTO?> GetByID(int id);
        Task<IEnumerable<BonsaiDisplayDTO>?> GetByName(string name);
        Task<bool> Update(BonsaiDTO bonsai);
        Task<bool> Delete(int id);
    }
}
