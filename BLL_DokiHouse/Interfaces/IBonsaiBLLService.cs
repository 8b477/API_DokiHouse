using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository; //-> remove

namespace BLL_DokiHouse.Interfaces
{
    public interface IBonsaiBLLService
    {
        Task<int> Create(BonsaiCreateDTO model);
        Task<IEnumerable<BonsaiDisplayDTO>?> GetByName(string name);
        Task<BonsaiDisplayDTO?> GetByID(int id);
        Task<bool> Update(BonsaiDTO bonsai);
        Task<bool> Delete(int id);
        Task<IEnumerable<BonsaiCateExp>?> Get();
    }
}
