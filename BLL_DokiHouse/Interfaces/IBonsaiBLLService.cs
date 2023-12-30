using DAL_DokiHouse.DTO;


namespace BLL_DokiHouse.Interfaces
{
    public interface IBonsaiBLLService
    {
        Task<bool> Create(BonsaiCreateDTO model);
        Task<IEnumerable<BonsaiDisplayDTO>> Get();
        Task<IEnumerable<BonsaiDisplayDTO>?> GetByName(string name);
        Task<BonsaiDisplayDTO?> GetByID(int id);
        Task<bool> Update(BonsaiDTO bonsai);
        Task<bool> Delete(int id);
    }
}
