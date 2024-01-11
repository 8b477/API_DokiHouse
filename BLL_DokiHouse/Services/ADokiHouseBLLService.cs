

using BLL_DokiHouse.Interfaces;

using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;
using DAL_DokiHouse.Repository;

namespace BLL_DokiHouse.Services
{
    public class ADokiHouseBLLService : IADokiHouseBLLService
    {
        #region Injection
        private readonly IADokiHouseRepo _dokiHouseRepo;
        public ADokiHouseBLLService(IADokiHouseRepo dokiHouseRepo) => _dokiHouseRepo = dokiHouseRepo;
        #endregion

        public Task<IEnumerable<FullJoinDTO>?> GetInfos(CancellationToken cancellationToken)
        {
            return _dokiHouseRepo.Infos(cancellationToken);
        }

        public Task<IEnumerable<FullJoinDTO>?> GetInfosPaginated(int startIndex, int pageSize, CancellationToken cancellationToken)
        {
            return _dokiHouseRepo.InfosPaginated(startIndex, pageSize, cancellationToken);
        }

        public async Task<UserTest?> GetInfosUserWithOwnBonsaisAndDetails(int startIndex, int pageSize, int userId)
        {
            return await _dokiHouseRepo.GetInfosUserWithOwnBonsaisAndDetails(startIndex, pageSize, userId);
        }

        public async Task<PostJoinDTO?> GetPostWithComments(int id)
        {
            return await _dokiHouseRepo.GetPostWithComments(id);
        }

        public async Task<UserTest2?> GetUserInfosWithOwnPostsAndComments(int userId)
        {
            return await _dokiHouseRepo.GetUserInfosWithOwnPostsAndComments(userId);
        }
    }
}
