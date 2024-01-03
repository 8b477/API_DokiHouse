
using BLL_DokiHouse.Models;

namespace BLL_DokiHouse.Interfaces
{

    public interface INoteBLLService
    {
        Task<bool> CreateNote(NoteBLL model);
        Task<bool> UpdateNote(NoteBLL model);
    }

}
