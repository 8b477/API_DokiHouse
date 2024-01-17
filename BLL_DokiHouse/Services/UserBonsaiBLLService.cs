using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO.User;
using DAL_DokiHouse.Interfaces;


namespace BLL_DokiHouse.Services
{
    public class UserBonsaiBLLService : IUserBonsaiBLLService
    {

        #region INJECTION
        private readonly IUserBonsaiRepo _userBonsaiRepo;

        public UserBonsaiBLLService(IUserBonsaiRepo userBonsaiRepo) => _userBonsaiRepo = userBonsaiRepo;
        #endregion


        public async Task<IEnumerable<UserAndBonsaiDetails?>> GetInfos(int startIndex, int pageSize)
        {
            return await _userBonsaiRepo.GetInfos(startIndex, pageSize);
        }


        public async Task<UserAndBonsaiDetails?> GetInfosById(int idUser)
        {
            return await _userBonsaiRepo.GetInfosById(idUser);
        }

    }
}
