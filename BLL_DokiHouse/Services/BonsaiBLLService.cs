using BLL_DokiHouse.Interfaces;
using DAL_DokiHouse.DTO;
using DAL_DokiHouse.Interfaces;

namespace BLL_DokiHouse.Services
{
    public class BonsaiBLLService : IBonsaiBLLService
    {
        #region Injection

        private readonly IBonsaiRepo _bonsaiRepo;
        public BonsaiBLLService(IBonsaiRepo bonsaiRepo) => _bonsaiRepo = bonsaiRepo; 

        #endregion


        public async Task<bool> Create(BonsaiCreateDTO model)
        {
            return await _bonsaiRepo.Create(model);
        }


        public async Task<bool> Delete(int id)
        {
            return await _bonsaiRepo.Delete(id);
        }


        public async Task<IEnumerable<BonsaiDisplayDTO>> Get()
        {
            return await _bonsaiRepo.Get();
        }


        public async Task<BonsaiDisplayDTO?> GetByID(int id)
        {
            return await _bonsaiRepo.GetBy(id);
        }


        public async Task<IEnumerable<BonsaiDisplayDTO>?> GetByName(string name)
        {
            return await _bonsaiRepo.GetBy(name);
        }


        public async Task<bool> Update(BonsaiDTO model)
        {
            return await _bonsaiRepo.UpdateBonsai(model);
        }

    }
}
