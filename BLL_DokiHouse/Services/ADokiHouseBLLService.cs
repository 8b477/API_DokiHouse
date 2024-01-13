

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
