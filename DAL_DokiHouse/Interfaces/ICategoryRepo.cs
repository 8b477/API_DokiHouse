using DAL_DokiHouse.DTO;

namespace DAL_DokiHouse.Interfaces
{
    public interface ICategoryRepo
    {
        Task<bool> Create(CategoryDTO model);
        Task<bool> Update(CategoryDTO model);
    }
}
