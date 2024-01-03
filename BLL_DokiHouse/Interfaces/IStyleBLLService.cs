using BLL_DokiHouse.Models;

using DAL_DokiHouse.DTO;

namespace BLL_DokiHouse.Interfaces
{
    public interface IStyleBLLService
    {
        Task<bool> CreateStyle(StyleBLL style);
        Task<bool> UpdateStyle(StyleBLL style);
    }
}
