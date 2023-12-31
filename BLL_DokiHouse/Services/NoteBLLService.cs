using BLL_DokiHouse.Interfaces;

using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class NoteBLLService : INoteBLLService
    {

        #region Injection

        private readonly INoteRepo _noteRepo;

        public NoteBLLService (INoteRepo noteRepo) => _noteRepo = noteRepo;

        #endregion


    }
}
