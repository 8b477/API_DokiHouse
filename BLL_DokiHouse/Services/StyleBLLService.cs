using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class StyleBLLService : IStyleBLLService
    {

        #region Injection

        private readonly IStyleRepo _stryleRepo;

        public StyleBLLService(IStyleRepo stryleRepo) => _stryleRepo = stryleRepo;

        #endregion

    }
}
