using DAL_DokiHouse.DTO;
using Entities_DokiHouse.Entities;

namespace DAL_DokiHouse.Interfaces
{
    public interface IBonsaiRepo : IRepo<Bonsai, BonsaiDTO, BonsaiCreateDTO, BonsaiDisplayDTO, int, string>
    {
        Task<bool> Create(BonsaiDTO model);
        Task<bool> UpdateBonsai(BonsaiDTO bonsai);
    }
}
