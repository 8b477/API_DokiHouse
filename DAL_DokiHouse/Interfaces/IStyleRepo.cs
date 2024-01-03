
using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface IStyleRepo
    {
        Task<bool> Create(StyleDTO style);
        Task<bool> Update(StyleDTO style);
        Task<bool> NotValide(int idBonsai);
    }
}
