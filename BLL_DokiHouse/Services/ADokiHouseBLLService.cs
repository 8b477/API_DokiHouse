

using BLL_DokiHouse.Interfaces;

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class ADokiHouseBLLService : IADokiHouseBLLService
    {
        #region Injection
        private readonly IADokiHouseRepo _dokiHouseRepo;
        public ADokiHouseBLLService(IADokiHouseRepo dokiHouseRepo) => _dokiHouseRepo = dokiHouseRepo;
        #endregion

        public Task<IEnumerable<EveryDTO>?> GetInfos(CancellationToken cancellationToken)
        {
            return _dokiHouseRepo.Infos(cancellationToken);
        }

        public Task<IEnumerable<EveryDTO>?> GetInfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken)
        {
            return _dokiHouseRepo.InfosPaginated(startIndex, pageSize, cancellationToken);
        }
    }
}
