using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;


namespace BLL_DokiHouse.Interfaces
{
    public interface ICategoryBLLService
    {
        Task<bool> Create(int idBonsai, CategoryBLL model);
        Task<bool> Update(CategoryDTO model);
    }
}
