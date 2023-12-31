using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Repository;

using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.Interfaces
{
    public interface IBonsaiRepo : IRepo<Bonsai, BonsaiDTO, BonsaiCreateDTO, BonsaiDisplayDTO, int, string>
    {
        Task<int> CreateBonsai(BonsaiCreateDTO model);
        Task<bool> UpdateBonsai(BonsaiDTO bonsai);
        Task<IEnumerable<BonsaiCateExp>?> GetAllBonsai();
    }
}
