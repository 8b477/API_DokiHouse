using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Interfaces
{
    public interface ICategoryBLLService
    {
        Task<bool> Create(CategoryDTO model);
        Task<bool> Update(CategoryDTO model);
    }
}
