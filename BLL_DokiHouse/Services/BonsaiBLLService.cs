using BLL_DokiHouse.Interfaces;
using BLL_DokiHouse.Models;
using BLL_DokiHouse.Tools;
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


        public async Task<bool> Create(BonsaiBLL model)
        {
            BonsaiDTO bonsaiDTO = Mapper.BonsaiBLLToDAL(model);

            return await _bonsaiRepo.Create(bonsaiDTO);
        }


        public async Task<IEnumerable<BonsaiDTO>> Get()
        {
            return await _bonsaiRepo.Get();
        }


        public async Task<IEnumerable<BonsaiDTO>> Get(int idUser)
        {
            return await _bonsaiRepo.Get(idUser);
        }


        public async Task<BonsaiDTO?> GetByID(int id)
        {
            return await _bonsaiRepo.GetBy(id);
        }


        public async Task<IEnumerable<BonsaiDTO>?> GetByName(string name)
        {
            return await _bonsaiRepo.GetBy(name);
        }


        public async Task<bool> Update(BonsaiDTO model)
        {
            return await _bonsaiRepo.Update(model);
        }


        public async Task<bool> Delete(int id)
        {
            return await _bonsaiRepo.Delete(id);
        }


    }
}
